using System.ComponentModel.DataAnnotations;

namespace TaxiPrices.Models
{
    public class VognModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Vælg venligst vogntype")]
        public string VognType { get; set; }
        public int StartPris { get; set; }
        public double KmPris { get; set; }
        public double MinutePris { get; set; }
    }
}
