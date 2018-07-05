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
    internal class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            ToTable("Jugadores");
            HasKey(t => t.PlayerId);
            Property(t => t.PlayerId).HasColumnName("JugadorId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("NombreJugador").HasMaxLength(100).IsRequired();
            Property(t => t.Number).HasColumnName("NumeroJugador").IsOptional();
            Property(t => t.DateOfBirth).HasColumnName("FechaNacimiento").IsOptional();

            #region player one-to-many con goals
            HasMany(p => p.Goals)
                .WithRequired(g => g.Scorer)
                .HasForeignKey(g => g.ScorerId);
            #endregion


        }
    }
}
