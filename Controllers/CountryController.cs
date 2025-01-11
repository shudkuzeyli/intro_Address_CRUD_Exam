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
		public IActionResult Crete() 
		{ 
		return View();
		}

		[HttpPost]
		public IActionResult Crete(Country c)
		{
			return View();
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
