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

		public IActionResult Edit(int id)
		{
			Villa? villa = _dbContext.Villas.Find(id);

			if (villa is null)
			{
				return RedirectToAction("Error", "Home");

			}
			return View(villa);
		}

		[HttpPost]
		public IActionResult Edit(Villa villa)
		{
			if (ModelState.IsValid && villa.Id > 0)
			{
				_dbContext.Update(villa);

				_dbContext.SaveChanges();

				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Delete(int id)
		{
			Villa? villa = _dbContext.Villas.Find(id);

			if (villa is null)
			{
				return RedirectToAction("Error", "Home");
			}

			return View(villa);
		}

		[HttpPost]
		public IActionResult Delete(Villa villa)
		{
			Villa? ObjFromDb = _dbContext.Villas.FirstOrDefault(v => v.Id == villa.Id);

			if (ObjFromDb is not null)
			{
				_dbContext.Remove(ObjFromDb);
				_dbContext.SaveChanges();
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", "Can't Delete this villa please try again");

			return View(villa);
		}
	}
}
