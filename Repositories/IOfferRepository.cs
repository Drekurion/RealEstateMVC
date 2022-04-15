using RealEstateMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMVC.Repositories
{
	public interface IOfferRepository
	{
		public PaginatedList<Offer> GetPage(int currentPage);
		public Offer Get(int offerId);
		void Add(Offer offer);
		void Update(int offerId, Offer offer);
		void Delete(int offerId);
	}
}
