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
    internal class GameScoreViewMap : EntityTypeConfiguration<GameScoreView>
    {
        public GameScoreViewMap()
        {
            ToTable("MarcadorJuegosView");
            HasKey(s => s.SoccerGameId);
        }
    }
}
