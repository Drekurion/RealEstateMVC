using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateMVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMVC.Controllers
{
    public class OfferController : Controller
	{
		private readonly ApplicationDbContext context;
		public OfferController(ApplicationDbContext context)
		{
			this.context = context;
		}

		// GET: Offer
		public async Task<IActionResult> Index(int? page)
		{
			var offers = from s in context.Offers select s;
			int pageSize = 20;
			return View(await PaginatedList<Offer>.CreateAsync(offers.OrderBy(x => x.Number).AsNoTracking(), page ?? 1, pageSize));
		}

		// GET: Offer/Details/5
		public ActionResult Details(int id)
		{
			return View(context.Offers.FirstOrDefault(x => x.OfferId == id));
		}

		// GET: Offer/Create
		public ActionResult Create()
		{
			return View(new Offer());
		}

		// POST: Offer/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Offer offer)
		{
			context.Add(offer);
			context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		// GET: Offer/Edit/5
		public ActionResult Edit(int id)
		{
			return View(context.Offers.FirstOrDefault(x => x.OfferId == id));
		}

		// POST: Offer/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Offer offer)
		{
			Offer result = context.Offers.FirstOrDefault(x => x.OfferId == id);
			if (result != null)
			{
				result.OfferType = offer.OfferType;
				result.EstateType = offer.EstateType;
				result.Number = offer.Number;
				result.Area = offer.Area;
				result.Price = offer.Price;
				context.SaveChanges();
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: Offer/Delete/5
		public ActionResult Delete(int id)
		{
			return View(context.Offers.FirstOrDefault(x => x.OfferId == id));
		}

		// POST: Offer/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Offer offer)
		{
			Offer result = context.Offers.FirstOrDefault(x => x.OfferId == id);
			context.Remove(result);
			context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
