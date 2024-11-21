using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenVolt.Models
{
    public class MainViewModel
    {
        public ObservableCollection<Company> Companies { get; set; }
        public MainViewModel()
        {
            Companies = new ObservableCollection<Company>
        {
            new Company
            {
                Name = "NeoEnergia",
                Description = "Energia solar para sua casa",
                Price = "R$ 500,00",
                BadgeText = "Promoção",
                ImageUrl = "sumpanel.png"
            },
            new Company
            {
                Name = "SolarPower",
                Description = "Soluções de energia renovável",
                Price = "R$ 700,00",
                BadgeText = "Desconto",
                ImageUrl = "sumpanel.png"
            }
        };
        }
    }
}
