using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Domain
{
    public class Stadium
    {
        public int? StadiumId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string CorporateNaming { get; set; }

        public int? TeamId { get; set; }

        public Team Team { get; set; }
    }
}
