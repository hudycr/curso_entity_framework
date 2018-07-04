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
    internal class GoalMap : EntityTypeConfiguration<Goal>
    {
        public GoalMap()
        {
            ToTable("Goles");
            HasKey(t => t.GoalId);
            Property(t => t.GoalId).HasColumnName("GolId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.GameId).HasColumnName("JuegoId");

            #region map Scorer one-to-many
            HasRequired(goal => goal.Scorer)
                .WithMany(p => p.Goals)
                .HasForeignKey(goal => goal.ScorerId)
                .WillCascadeOnDelete(false); //para que no elimine el player solo el gol
            #endregion
        }
    }
}
