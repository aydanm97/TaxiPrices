using System.ComponentModel.DataAnnotations;

namespace TaxiPrices.Models
{
    public class TillaegModel
    {
        
            public string Id { get; set; }
            public string Label { get; set; }
            public decimal Pris { get; set; }
            [Required(ErrorMessage = "Vælg venligst ekstra tillæg")]
            public bool IsSelected { get; set; }
        
    }
}
