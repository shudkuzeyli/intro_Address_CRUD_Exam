using intro_Address_CRUD_Exam.Context;
using intro_Address_CRUD_Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace intro_Address_CRUD_Exam.Controllers
{
	public class AddressController : Controller
	{
		private readonly DataContext _dataContext;

		public AddressController(Context.DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<IActionResult> SehirGetir(int id)
		{

			var sehirListesi = Json(await _dataContext.City.Where(t => t.CountryId == id).ToListAsync());
			return sehirListesi;
		}

		public async Task<IActionResult> IlceGetir(int id)
		{

			var ilcelistesi = Json(await _dataContext.Ilce.Where(t => t.CityId == id).ToListAsync());
			return ilcelistesi;
		}

		public IActionResult Index()
		{

			var adresler = _dataContext.Address.Include(t => t.Country).Include(i => i.City).Include(g => g.Ilce).ToList();
			return View(adresler);

		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{

			ViewBag.Ulke = new SelectList(await _dataContext.Country.ToListAsync(), "Id", "UlkeKodu");
			return View();

		}

		[HttpPost]
		public IActionResult Create(Address a)
		{
			if (a is null)
			{
				//return RedirectToAction("Index");
				return RedirectToAction(nameof(Index));
			}

			if (ModelState.IsValid != false)
			{
				return View(a);
			}

			_dataContext.Add(a);
			_dataContext.SaveChanges();

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(int? id)
		{
			if (id is null)
				return RedirectToAction(nameof(Index));

			var edit = _dataContext.Address.Where(e => e.Id == id).FirstOrDefault();
			if (edit is null)
				return RedirectToAction(nameof(Index));

			return View(edit);
		}

		[HttpPost]
		public IActionResult Edit(Address a, int? id)
		{
			if (id is null)
				return RedirectToAction(nameof(Index));

			if (a.Id != id)
				return RedirectToAction(nameof(Index));

			if (_dataContext.Address.Any(e => e.Id == id) == false)
				return RedirectToAction(nameof(Index));

			if (ModelState.IsValid == false)
			{
				try
				{
					var dbdekiData = _dataContext.Address.FirstOrDefault(e => e.Id == id);

					dbdekiData.Tanim = a.Tanim;
					dbdekiData.UlkeId = a.UlkeId;
					dbdekiData.SehirId = a.SehirId;
					dbdekiData.Ilce = a.Ilce;
					dbdekiData.AdresAciklama = a.AdresAciklama;
					dbdekiData.Aktif = a.Aktif;

					_dataContext.Update(dbdekiData);
					_dataContext.SaveChanges();
				}
				catch (Exception e)
				{
					//loga yazılacak.
					ModelState.AddModelError("Descp", $"Inner Exep. : {e.Message}");
					return View(a);
				}
			}
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id is null)
				return RedirectToAction(nameof(Index));

			var edit = _dataContext.Address.Where(e => e.Id == id).FirstOrDefault();
			if (edit is null)
				return RedirectToAction(nameof(Index));

			return View(edit);
		}

		[HttpPost, ActionName("DeleteConfirm")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirm(int? id)
		{
			if (id != null)

			{
				try
				{
					var dbdekiData = _dataContext.Address.FirstOrDefault(e => e.Id == id);
					if (dbdekiData is null)
					{
						return RedirectToAction(nameof(Index));
					}

					_dataContext.Remove(dbdekiData);
					_dataContext.SaveChanges();

					return RedirectToAction(nameof(Index));
				}
				catch (Exception e)
				{
					//loga yazılacak.
					ModelState.AddModelError("Tanim", $"Inner Exep. : {e.Message}");
					return View();
				}
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Detail(int? id)
		{
			if (id is null)
				return RedirectToAction(nameof(Index));

			var edit = _dataContext.Address.Where(e => e.Id == id).FirstOrDefault();
			if (edit is null)
				return RedirectToAction(nameof(Index));

			return View(edit);
		}
	}
}
