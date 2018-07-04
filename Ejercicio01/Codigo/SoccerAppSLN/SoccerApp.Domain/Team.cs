using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Domain
{
    public class Team
    {
        public int? TeamId { get; set; }
        
        public string Name { get; set; }
        
        public string CountryName { get; set; }
        
        public DateTime? Founded { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public bool? Active { get; set; }
        
        public byte[] RowVersion { get; set; }

        public int? StadiumId { get; set; }

        public Stadium Stadium { get; set; }

        public int? TournamentId { get; set; }

        public Tournament Tournament { get; set; }
    }
}
