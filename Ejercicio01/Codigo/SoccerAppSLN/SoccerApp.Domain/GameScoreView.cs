using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Domain
{
    public class GameScoreView
    {
        public int? SoccerGameId { get; set; }

        public int? TournamentId { get; set; }

        public int? LocalTeamId { get; set; }

        public int? VisitTeamId { get; set; }

        public string LocalTeam { get; set; }

        public string VisitTeam { get; set; }

        public int? LocalScore { get; set; }

        public int? VisitScore { get; set; }

    }
}
