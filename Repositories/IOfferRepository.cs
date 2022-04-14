using Nieruchomości.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nieruchomości.Repositories
{
	public interface IOfferRepository
	{
		public IList<Offer> GetAll();
		public Offer Get(int offerId);
		void Add(Offer offer);
		void Update(int offerId, Offer offer);
		void Delete(int offerId);
	}
}
