using intro_Address_CRUD_Exam.Context;
using intro_Address_CRUD_Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace intro_Address_CRUD_Exam.Controllers
{
	public class CityController : Controller
	{

		private readonly DataContext _dataContext;

		public CityController(Context.DataContext dataContext)
		{
			_dataContext = dataContext;
		}


		public IActionResult Index()
		{
			//	var countries = _dataContext.City.ToList();
			//return View(countries);

			var sehirler = _dataContext.City.Include(t => t.Country).ToList();
			return View(sehirler);
		}

		[HttpGet]
		public IActionResult Create()
		{
			//server dan client a liste gödnermek
			ViewBag.Ulke = new SelectList(_dataContext.Country.OrderBy(t=> t.Descp).ToList(), "Id", "UlkeKodu"); 
			return View();
		}

		[HttpPost]
		public IActionResult Create(City c)
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

			var sehirliste = _dataContext.City.Where(t => t.Descp == c.Descp).FirstOrDefault();
			if (sehirliste != null)
			{
				//gönerilen mail adresi zaten veritabanında varmış.
				ModelState.AddModelError("Descp", "Bu şehir listede mevcut.");
				return View(c);
			}

			//_dataContext.Kullanici.Add(k);
			_dataContext.Add(c);
			_dataContext.SaveChanges();

			return RedirectToAction(nameof(Index));
		}


		public IActionResult Edit(int? id)
		{
			return View();
		}


		[HttpPost]
		public IActionResult Edit(City c, int? id)
		{
			return View();
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			return View();
		}

		[HttpPost, ActionName("DeleteConfirm")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirm(int? id)
		{
			return View();
		}
	}
}
