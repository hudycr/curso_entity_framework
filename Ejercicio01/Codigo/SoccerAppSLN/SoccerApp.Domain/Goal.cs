using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Domain
{
    [Table ("Golazos")]
    public class Goal
    {
        public int GoalId { get; set; }

        [Required]
        public int? ScoringTime { get; set; }

        public int ScorerId { get; set; }

        //[ForeignKey ("ScorerId")]
        public virtual Player Scorer { get; set; }

        public int? GameId { get; set; }

        public SoccerGame Game { get; set; }
    }
}
