using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Domain
{
    public class Official
    {
        public int? OfficialId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SoccerGame> Games { get; set; }
    }
}
