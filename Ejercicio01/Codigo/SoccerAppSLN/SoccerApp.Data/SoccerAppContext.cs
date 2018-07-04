using SoccerApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using SoccerApp.Data.Mapping;

namespace SoccerApp.Data
{
    public class SoccerAppContext : DbContext
    {
        public SoccerAppContext() : base("name=SoccerAppContext")
        {

        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<SoccerGame> SoccerGames { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Official> Officials { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region mapping Tournament
            modelBuilder.Configurations.Add(new TournamentMap());
            
            #endregion

            #region mapping SoccerGame
            modelBuilder.Configurations.Add(new SoccerGameMap());
            #endregion

            #region mapping Teams
            modelBuilder.Configurations.Add(new TeamMap());
            //configuracion desde Team one-to-many
            /*modelBuilder.Entity<Team>().HasRequired(team => team.Tournament)
                .WithMany(tournament => tournament.Teams)
                .HasForeignKey(team => team.TournamentId);*/
            #endregion

            #region Player
            modelBuilder.Configurations.Add(new PlayerMap());
            #endregion

            #region Goals
            modelBuilder.Configurations.Add(new GoalMap());
            #endregion

            #region Stadium
            modelBuilder.Configurations.Add(new StadiumMap());
            #endregion

            #region Staff
            modelBuilder.Configurations.Add(new StaffMap());
            #endregion
        }
    }
}
