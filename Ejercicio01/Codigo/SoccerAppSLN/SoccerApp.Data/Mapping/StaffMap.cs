using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SoccerApp.Domain;

namespace SoccerApp.Data.Mapping
{
    internal class StaffMap : EntityTypeConfiguration<Staff>
    {
        public StaffMap()
        {
            ToTable("Staffs");
            HasKey(s => s.StaffId);
            Property(s => s.StaffId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Map<Coach>(c => c.Requires("Tipo").HasValue("Entrenador"));
            Map<Medical>(c => c.Requires("Tipo").HasValue("CuerpoMedico"));
        }
    }
}
