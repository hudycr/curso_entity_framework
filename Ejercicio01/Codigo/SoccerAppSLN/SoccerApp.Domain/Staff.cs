using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Domain
{
    public abstract class Staff
    {
        public int? StaffId { get; set; }

        public string Name { get; set; }

        public bool? Active { get; set; }
    }
}
