using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Domain
{
    public class Player
    {
        public Player()
        {
            this.PersonalInfo = new PersonalInfo();
        }

        public int PlayerId { get; set; }

        public string Name { get; set; }
        
        public int Number { get; set; }

        public bool? Active { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Goal> Goals { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }

        public PersonalInfo PersonalInfo { get; set; }
    }
}
