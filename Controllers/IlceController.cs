using intro_Address_CRUD_Exam.Context;
using intro_Address_CRUD_Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace intro_Address_CRUD_Exam.Controllers
{
	public class IlceController : Controller
	{

		private readonly DataContext _dataContext;

		public IlceController(Context.DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public IActionResult Index()
		{
			var ilceler = _dataContext.Ilce.Include(t => t.City).ThenInclude(i => i.Country).ToList();
			return View(ilceler);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			ViewBag.Ulke = new SelectList(await _dataContext.Country.ToListAsync(), "Id", "UlkeKodu");
			return View();
		}
		//[HttpPost]
		//public async Task<IActionResult> Create(Ilce i)
		//{
		//	ViewBag.Ulke = new SelectList(await _dataContext.Country.ToListAsync(), "Id", "UlkeKodu");
		//	return View();
		//}
		public async Task<IActionResult> SehirGetir(int id)
		{

			var sehirListesi = Json(await _dataContext.City.Where(t => t.CountryId == id).ToListAsync());
			return sehirListesi;
		}
	}
}
