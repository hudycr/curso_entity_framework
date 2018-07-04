using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Domain
{
    public class Tournament
    {
        public int TournamentId { get; set; }

        public string Name { get; set; }

        public DateTime? CreationDate { get; set; }

        //[ForeignKey ("TorneoId")]
        public virtual ICollection<SoccerGame> Games { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
