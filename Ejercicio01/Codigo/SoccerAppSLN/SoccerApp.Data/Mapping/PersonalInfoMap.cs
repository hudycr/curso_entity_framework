using SoccerApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Data.Mapping
{
    internal class PersonalInfoMap : ComplexTypeConfiguration<PersonalInfo>
    {
        public PersonalInfoMap()
        {
            Property(p => p.Height).HasColumnName("Altura").HasPrecision(20, 4);
            Property(p => p.Address).HasColumnName("Direccion");
        }
    }
}
