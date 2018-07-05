using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Domain
{
    public abstract class Directive
    {
        public int? DirectiveId { get; set; }

        public String Name { get; set; }

        public String Activity { get; set; }

        public String Departament { get; set; }

        public int? ParentDirectiveId { get; set; }

        public virtual ICollection<Directive> Subordinates { get; set; }
    }
}
