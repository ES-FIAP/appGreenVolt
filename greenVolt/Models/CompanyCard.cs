using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenVolt.Models
{
    class CompanyCard
    {
        public string ImageUrl { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Price { get; set; } 
        public string BadgeText { get; set; } // Texto do selo (opcional)
    }
}
