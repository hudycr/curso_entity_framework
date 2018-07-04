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
    internal class SoccerGameMap : EntityTypeConfiguration<SoccerGame>
    {
        public SoccerGameMap()
        {
            ToTable("Juegos");
            HasKey(s => s.SoccerGameId);
            Property(s => s.SoccerGameId).HasColumnName("JuegoId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(s => s.Date).HasColumnName("Fecha").IsRequired();
            Property(s => s.TournamentId).HasColumnName("TorneoId");

            #region soccergame one-to-many con goal
            HasMany(s => s.Goals)
                .WithRequired(goal => goal.Game)
                .HasForeignKey(goal => goal.GameId);
            #endregion

            #region soccerGame one-to-many con LocalTeam
            Property(s => s.LocalTeamId).HasColumnName("EquipoLocalId");
            HasRequired(s => s.LocalTeam)
                .WithMany()
                .HasForeignKey(s => s.LocalTeamId)
                .WillCascadeOnDelete(false);
            #endregion

            #region soccerGame one-to-many con VisitTeam
            Property(s => s.VisitTeamId).HasColumnName("EquipoVisitanteId");
            HasRequired(s => s.VisitTeam)
                .WithMany().HasForeignKey(s => s.VisitTeamId)
                .WillCascadeOnDelete(false);
            #endregion

            #region soccerGame many-to-many con Official
            HasMany(s => s.Officials)
                .WithMany(o => o.Games)
                .Map(s => {
                    s.MapRightKey("OficialId");
                    s.MapLeftKey("JuegoId");
                    s.ToTable("OficialesJuegos");
                });
            #endregion

        }
    }
}
