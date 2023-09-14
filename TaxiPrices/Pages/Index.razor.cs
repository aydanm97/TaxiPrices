using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using TaxiPrices.Models;

namespace TaxiPrices.Pages
{
    public partial class Index
    {
        string selectedVogn;
        string totalprice;
        decimal minutePrice;

        public TaxiModel model = new TaxiModel();
        public TillaegModel tillaegModel = new TillaegModel();
        public VognModel vognModel = new VognModel();
        private List<decimal> selectedOptions = new List<decimal>();


        public List<TillaegModel> extraOptions = new List<TillaegModel>
    {
        new TillaegModel { Id = "tillæg1", Label = "Cykel", Pris = 30 },
        new TillaegModel { Id = "tillæg2", Label = "Opbæring", Pris = 30 },
        new TillaegModel { Id = "tillæg3", Label = "Lufthavn", Pris = 15 },
        new TillaegModel { Id = "tillæg4", Label = "5-6 passagerer", Pris = 35 },
        new TillaegModel { Id = "tillæg5", Label = "Liftvogn", Pris = 350 },
        new TillaegModel { Id = "tillæg6", Label = "Kørsel over Øresundsbroen", Pris = 350 },
        new TillaegModel { Id = "tillæg7", Label = "Kørsel over Storebæltsbroen", Pris = 540 }
    };
        public List<VognModel> vognChoice = new List<VognModel>
        {
            new VognModel {Id = "almdag", VognType="Almindelig Vogn-Dag",StartPris=37,KmPris=12.75,MinutePris=5.75},
            new VognModel {Id = "almnat", VognType="Almindelig Vogn-Nat",StartPris=47,KmPris=16,MinutePris=7},
            new VognModel {Id = "stordag", VognType="Stor vogn-Dag",StartPris=77,KmPris=17,MinutePris=5.75},
            new VognModel {Id = "stordag", VognType="Stor Vogn-Nat",StartPris=87,KmPris=19,MinutePris=7}
        };
        //presents  the price of the option and checks the checkbox
        //adds and removes from the extraoption list
        public void ToggleOption(ChangeEventArgs e, decimal optionPrice)
        {
            if (e.Value != null && bool.TryParse(e.Value.ToString(), out bool isChecked))
            {
                if (isChecked)
                {
                    selectedOptions.Add(optionPrice); // Add the price to the selected options list
                }
                else
                {
                    selectedOptions.Remove(optionPrice); // Remove the price from the selected options list
                }
            }
        }

        public void HandleValidSubmit()
        {
            var selectedVognModel = vognChoice.FirstOrDefault(v => v.Id == selectedVogn);
            decimal kmPrice = (decimal)selectedVognModel.KmPris;
            minutePrice = (decimal)selectedVognModel.MinutePris;


            decimal selectedOptionsTotal = extraOptions
           .Where(option => option.IsSelected)
           .Sum(option => option.Pris);

            decimal pris = (model.km * kmPrice);
            decimal minuteCost = model.minutes * minutePrice;
            totalprice = (selectedVognModel.StartPris + pris + minuteCost + selectedOptionsTotal).ToString();

        }





    }
}
