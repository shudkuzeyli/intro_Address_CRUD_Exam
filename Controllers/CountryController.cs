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
			return View();
		}


		[HttpPost]
		public IActionResult Edit(Country c ,int? id)
		{
			return View();
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			return View();
		}

		[HttpPost, ActionName ("DeleteConfirm")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirm(int? id)
		{
			return View();
		}
	}
}
