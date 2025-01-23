using Microsoft.AspNetCore.Mvc;
using VillaBooking.Core.Entities;
using VillaBooking.Infrastructure.Data;

namespace VillaBooking.Web.Controllers
{
	public class VillaController : Controller
	{
		private readonly AppDbContext _dbContext;
		public VillaController(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
		{
			var villas = _dbContext.Villas.ToList();

			return View(villas);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Villa villa)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Villas.Add(villa);

				_dbContext.SaveChangesAsync();

				return RedirectToAction("Index");
			}
			return View(villa);
		}
	}
}
