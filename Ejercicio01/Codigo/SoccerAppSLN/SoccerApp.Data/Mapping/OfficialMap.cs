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
    internal class OfficialMap : EntityTypeConfiguration<Official>
    {
        public OfficialMap()
        {
            ToTable("Oficiales");
            HasKey(t => t.OfficialId);
            Property(t => t.OfficialId).HasColumnName("OficialId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("NombreOficial").HasMaxLength(100);
        }
    }
}
