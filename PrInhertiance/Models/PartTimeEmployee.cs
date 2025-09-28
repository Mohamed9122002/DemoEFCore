using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrInhertiance.Models
{
    public class PartTimeEmployee :Employee
    {
        public decimal HourlyRate { get; set; }
        public int CountOfHours { get; set; }
    }
}
