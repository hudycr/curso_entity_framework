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
    internal class TournamentMap : EntityTypeConfiguration<Tournament>
    {
        public TournamentMap()
        {
            ToTable("Torneos");
            HasKey(t => t.TournamentId);
            Property(t => t.TournamentId).HasColumnName("TorneoId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("NombreTorneo").HasMaxLength(200).IsRequired();
            Property(t => t.CreationDate).HasColumnName("FechaCreacion").IsOptional();

            #region configuracion desde Tournamet one-to-many de equipos
            HasMany(tournament => tournament.Teams)
                .WithRequired(team => team.Tournament)
                .HasForeignKey(team => team.TournamentId);
            #endregion

            #region configuracion one-to-many de games
            HasMany(t => t.Games)
                .WithRequired(g => g.Tournament)
                .HasForeignKey(g => g.TournamentId);
            #endregion
        }
    }
}
