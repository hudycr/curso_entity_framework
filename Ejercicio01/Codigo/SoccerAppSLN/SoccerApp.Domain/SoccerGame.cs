using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Domain
{
    public class SoccerGame
    {
        public int SoccerGameId { get; set; }

        public DateTime? Date { get; set; }

        public int GameNumber { get; set; }

        //[ForeignKey ("LocalTeam")]
        public int? LocalTeamId { get; set; }

        public virtual Team LocalTeam { get; set; }

        //[ForeignKey ("VisitTeam")]
        public int? VisitTeamId { get; set; }

        public virtual Team VisitTeam { get; set; }

        //[ForeignKey ("GameId")]
        public virtual ICollection<Goal> Goals { get; set; }

        public int? TournamentId { get; set; }

        public virtual Tournament Tournament { get; set; }

        public virtual ICollection<Official> Officials { get; set; }
    }
}
