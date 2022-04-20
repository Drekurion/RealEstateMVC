using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstateMVC.Models
{
    public class Offer
	{
		public int OfferId { get; set; }

		[DisplayName("Typ oferty")]
		[Required(ErrorMessage = "Wprowadź typ oferty.")]
		public string OfferType { get; set; }

		[DisplayName("Typ nieruchomości")]
		[Required(ErrorMessage = "Wprowadź typ nieruchomości.")]
		public string EstateType { get; set; }

		[DisplayName("Numer")]
		[Required(ErrorMessage = "Wprowadź numer nieruchomości.")]
		public string Number { get; set; }

		[DisplayName("Powierzchnia")]
		[Required(ErrorMessage = "Wprowadź powierzchnię.")]
		public double Area { get; set; }

		[DisplayName("Cena")]
		[Required(ErrorMessage = "Wprowadź cenę.")]
		public int Price { get; set; }
	}
}
