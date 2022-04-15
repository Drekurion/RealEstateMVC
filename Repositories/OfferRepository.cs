using Microsoft.EntityFrameworkCore;
using RealEstateMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMVC.Repositories
{
	public class OfferRepository : IOfferRepository
	{
		private readonly ApplicationDbContext context;
		public OfferRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public PaginatedList<Offer> GetPage(int currentPage)
        {
			int pageSize = 20;
			var offers = context.Offers.AsNoTracking().OrderBy(x => x.OfferId);
			PaginatedList<Offer> result = PaginatedList<Offer>.Create(offers, currentPage, pageSize);
			return result;
        }

		public Offer Get(int offerId)
		{
			return context.Offers.FirstOrDefault(x => x.OfferId == offerId);
		}

		public void Add(Offer offer)
		{
			context.Add(offer);
			context.SaveChanges();
		}

		public void Update(int offerId, Offer offer)
		{
			Offer result = context.Offers.FirstOrDefault(x => x.OfferId == offerId);
			if(result != null)
			{
				result.OfferType = offer.OfferType;
				result.EstateType = offer.EstateType;
				result.Number = offer.Number;
				result.Area = offer.Area;
				result.Price = offer.Price;
				context.SaveChanges();
			}
		}

		public void Delete(int offerId)
		{
			Offer result = context.Offers.FirstOrDefault(x => x.OfferId == offerId);
			context.Remove(result);
			context.SaveChanges();
		}	
	}
}
