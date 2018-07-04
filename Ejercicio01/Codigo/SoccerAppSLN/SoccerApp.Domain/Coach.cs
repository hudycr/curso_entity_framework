using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Domain
{
    public class Coach : Staff
    {
        public DateTime? DebutDate { get; set; }

        public string CountryName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
