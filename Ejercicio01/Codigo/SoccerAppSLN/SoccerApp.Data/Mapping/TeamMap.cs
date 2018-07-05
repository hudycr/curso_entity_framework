using SoccerApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Data.Mapping
{
    internal class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            ToTable("Equipos");
            HasKey(t => t.TeamId);
            Property(t => t.TeamId).HasColumnName("EquipoId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("Nombre").HasMaxLength(500).IsRequired();
            Property(t => t.CountryName).HasColumnName("Pais").HasMaxLength(100).IsRequired();
            Property(t => t.RowVersion).IsRowVersion();
            //no mapee la propiedad [NotMapped]
            Ignore(t => t.Active);

            Property(t => t.TournamentId).HasColumnName("TorneoId");

            #region Mapeo relacion One-to-One con Stadium
            Property(t => t.StadiumId).HasColumnName("EstadioId");
            //HasOptional(t => t.Stadium) //hace opcional stadium en Team
            //    .WithRequired(st => st.Team); //hace requerido Team para Stadium

            HasRequired(t => t.Stadium) //hace requerido stadium en team
            .WithRequiredPrincipal(st => st.Team);
            #endregion

            #region map Team one-to-many Player solo con propiedad FK
            HasMany(t => t.Players).WithRequired(p => p.Team).HasForeignKey(p => p.TeamId);
            #endregion
        }
    }
}
