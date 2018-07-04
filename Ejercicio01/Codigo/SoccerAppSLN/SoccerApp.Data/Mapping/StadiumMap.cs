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
    internal class StadiumMap :EntityTypeConfiguration<Stadium>
    {
        public StadiumMap()
        {
            ToTable("Estadios");
            HasKey(t => t.StadiumId);
            Property(t => t.StadiumId).HasColumnName("EstadioId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("NombreEstadio").HasMaxLength(100).IsRequired();
            Property(t => t.Country).HasColumnName("Pais").HasMaxLength(100).IsOptional();
            Property(t => t.CorporateNaming).HasColumnName("NombreCoorporativo").HasMaxLength(100).IsOptional();
            Property(t => t.TeamId).HasColumnName("EquipoId");
        }

    }
}
