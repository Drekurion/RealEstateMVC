using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMVC.Models
{
	public class Offer
	{
		public int OfferId { get; set; }

		[DisplayName("Typ oferty")]
		public string OfferType { get; set; }

		[DisplayName("Typ nieruchomości")]
		public string EstateType { get; set; }

		[DisplayName("Numer")]
		public string Number { get; set; }

		[DisplayName("Powierzchnia")]
		public double Area { get; set; }

		[DisplayName("Cena")]
		public int Price { get; set; }
	}
}
