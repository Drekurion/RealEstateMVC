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
		public async Task<IActionResult> Index(string sortOrder, int? page)
		{
			ViewData["CurrentSort"] = sortOrder;
			ViewData["NumberSortParam"] = string.IsNullOrEmpty(sortOrder) ? "Number_desc" : "";
			ViewData["OfferTypeSortParam"] = sortOrder == "OfferType" ? "OfferType_desc" : "OfferType";
			ViewData["EstateTypeSortParam"] = sortOrder == "EstateType" ? "EstateType_desc" : "EstateType";
			ViewData["AreaSortParam"] = sortOrder == "Area" ? "Area_desc" : "Area";
			ViewData["PriceSortParam"] = sortOrder == "Price" ? "Price_desc" : "Price";
			var offers = from x in context.Offers select x;
			switch(sortOrder)
            {
				case "Number_desc":
					offers = offers.OrderByDescending(x => x.Number);
					break;
				case "OfferType":
					offers = offers.OrderBy(x => x.OfferType);
					break;
				case "OfferType_desc":
					offers = offers.OrderByDescending(x => x.OfferType);
					break;
				case "EstateType":
					offers = offers.OrderBy(x => x.EstateType);
					break;
				case "EstateType_desc":
					offers = offers.OrderByDescending(x => x.EstateType);
					break;
				case "Area":
					offers = offers.OrderBy(x => x.Area);
					break;
				case "Area_desc":
					offers = offers.OrderByDescending(x => x.Area);
					break;
				case "Price":
					offers = offers.OrderBy(x => x.Price);
					break;
				case "Price_desc":
					offers = offers.OrderByDescending(x => x.Price);
					break;
				default:
					offers = offers.OrderBy(x => x.Number);
					break;
            }
			int pageSize = 20;
			return View(await PaginatedList<Offer>.CreateAsync(offers.AsNoTracking(), page ?? 1, pageSize));
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
