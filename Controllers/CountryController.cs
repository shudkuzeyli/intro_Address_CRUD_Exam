using intro_Address_CRUD_Exam.Context;
using intro_Address_CRUD_Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace intro_Address_CRUD_Exam.Controllers
{
	public class CountryController : Controller
	{

		private readonly DataContext _dataContext;

		public CountryController(Context.DataContext dataContext)
		{
			_dataContext = dataContext;
		}


		public IActionResult Index()
		{
		//	var countries = _dataContext.Country.ToList();
			//return View(countries);

			var ulkeler=_dataContext.Country.Include(t=>t.CityList).ThenInclude(i=>i.IlceList).ToList();	
			return View(ulkeler);			
		}

		[HttpGet]
		public IActionResult Create() 
		{ 
		return View();
		}

		[HttpPost]
		public IActionResult Create(Country c)
		{
			if (c is null)
			{
				//return RedirectToAction("Index");
				return RedirectToAction(nameof(Index));
			}

			if (ModelState.IsValid != false)
			{
				return View(c);
			}
			//Eğer kullanici tarafından gönderilen Kullanici modelindeki email bilgisi veritabanında var mı? kontrolü yapıyoruz.
			//Linq -> nesneler içerisinde arama/sorgulama yapmamıza yarayan betik işlemler kümesi.

			var ulkeliste = _dataContext.Country.Where(t => t.Descp == c.Descp).FirstOrDefault();
			if (ulkeliste != null)
			{
				//gönerilen mail adresi zaten veritabanında varmış.
				ModelState.AddModelError("Descp", "Bu ülke listede mevcut.");
				return View(c);
			}

			//_dataContext.Kullanici.Add(k);
			_dataContext.Add(c);
			_dataContext.SaveChanges();

			return RedirectToAction(nameof(Index));
		}


		public IActionResult Edit(int? id)
		{
			if (id is null)
				return RedirectToAction(nameof(Index));

			var edit = _dataContext.Country.Where(e => e.Id == id).FirstOrDefault();
			if (edit is null)
				return RedirectToAction(nameof(Index));

			return View(edit);
		}

		[HttpPost]
		public IActionResult Edit(Country c ,int? id)
		{
			if (id is null)
				return RedirectToAction(nameof(Index));

			if (c.Id != id)
				return RedirectToAction(nameof(Index));

			if (_dataContext.Country.Any(e => e.Id == id) == false)
				return RedirectToAction(nameof(Index));

			if (_dataContext.Country.Any(t => t.Descp == c.Descp.Trim() && t.Id != c.Id))
			{
				ModelState.AddModelError("Descp", "Ülke listede mevcut");
				return View(c);
			}

			if (ModelState.IsValid == false)
			{
				try
				{
					var dbdekiData = _dataContext.Country.FirstOrDefault(e => e.Id == id);

					dbdekiData.Descp = c.Descp;					
					dbdekiData.Aktif = c.Aktif;

					_dataContext.Update(dbdekiData);
					_dataContext.SaveChanges();
				}
				catch (Exception e)
				{
					//loga yazılacak.
					ModelState.AddModelError("Descp", $"Inner Exep. : {e.Message}");
					return View(c);
				}
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id is null)
				return RedirectToAction(nameof(Index));

			var edit = _dataContext.Country.Where(e => e.Id == id).FirstOrDefault();
			if (edit is null)
				return RedirectToAction(nameof(Index));

			return View(edit);
		}

		[HttpPost, ActionName ("DeleteConfirm")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirm(int? id)
		{
			if (id != null)

			{
				try
				{
					var dbdekiData = _dataContext.Country.FirstOrDefault(e => e.Id == id);
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
					ModelState.AddModelError("Descp", $"Inner Exep. : {e.Message}");
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

			var edit = _dataContext.Country.Where(e => e.Id == id).FirstOrDefault();
			if (edit is null)
				return RedirectToAction(nameof(Index));

			return View(edit);
		}
	}
}
