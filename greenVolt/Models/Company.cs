using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenVolt.Models
{
    public class Company
    {
        public int CompanyId { get; set; } 
        public string Name { get; set; } 
        public string TaxId { get; set; } 
        public string Description { get; set; } 
        public string Category { get; set; } 
        public string Contact { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public string EnergySourceType { get; set; } 
        public double Price { get; set; } 
    }
}
