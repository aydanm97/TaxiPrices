using System.ComponentModel.DataAnnotations;

namespace TaxiPrices.Models
{
    public class TaxiModel
    {
        [Required(ErrorMessage = "Indtast antal km")]

        public int km { get; set; }
        public int vogntype { get; set; }
        public int dogntillaeg { get; set; }
        public bool tillaeg { get; set; }

        [Required(ErrorMessage = "Indtast hvor mange min. din destination tager")]
        public decimal minutes { get; set; }
    }
}
