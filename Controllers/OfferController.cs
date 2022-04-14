using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nieruchomości.Models;
using Nieruchomości.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nieruchomości.Controllers
{
	public class OfferController : Controller
	{
		private readonly IOfferRepository offerRepository;
		private static IList<Offer> offers = new List<Offer>()
		{
			new Offer{ OfferId = 1, OfferType = "W", EstateType = "M", Number = "MW-1", Area = 90, Price = 367000 },

		};
		public OfferController(IOfferRepository offerRepository)
		{
			this.offerRepository = offerRepository;
		}

		// GET: Offer
		public ActionResult Index()
		{
			return View(offerRepository.GetAll());
		}

		// GET: Offer/Details/5
		public ActionResult Details(int id)
		{
			return View(offerRepository.Get(id));
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
			offerRepository.Add(offer);
			return RedirectToAction(nameof(Index));
		}

		// GET: Offer/Edit/5
		public ActionResult Edit(int id)
		{
			return View(offerRepository.Get(id));
		}

		// POST: Offer/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Offer offer)
		{
			offerRepository.Update(id, offer);
			return RedirectToAction(nameof(Index));
		}

		// GET: Offer/Delete/5
		public ActionResult Delete(int id)
		{
			return View(offerRepository.Get(id));
		}

		// POST: Offer/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Offer offer)
		{
			offerRepository.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
