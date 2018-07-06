using SoccerApp.Data;
using SoccerApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Services
{
    public class TournamentService
    {
        private SoccerAppContext ctx;

        public TournamentService(SoccerAppContext context)
        {
            this.ctx = context ?? new SoccerAppContext();
        }

        public void Insert(Tournament tournament)
        {
            #region validaciones
            if (string.IsNullOrEmpty(tournament.Name))
                throw 
                    new ArgumentNullException("Tournament.Name", "El nombre del torneo es requerido");

            //no permitir repetir nombre
            var torneoRepetido = ctx.Tournaments
                .FirstOrDefault(t => t.Name.CompareTo(tournament.Name) == 0);
            if (torneoRepetido != null)
                throw new ArgumentException("Nombre de torneo repetido", "Tournament.Name");
            #endregion

            ctx.Tournaments.Add(tournament);
            ctx.SaveChanges();
            
        }

        public List<Stadium> GetStadiumByTournamentId(Tournament tournament)
        {
            //consulta con sintaxis de consulta
            var resultado = from torneo in ctx.Tournaments
                            from equipo in torneo.Teams
                            where torneo.TournamentId == tournament.TournamentId
                            && equipo.StadiumId != null
                            orderby equipo.Name
                            select equipo.Stadium;

            return resultado.ToList();
        }

        public List<Stadium> GetStadiumByTournamentName(Tournament tournament)
        {
            //consulta con sintaxis de metodo
            var resultado = ctx.Tournaments
                .Where(t => t.Name == tournament.Name)
                .SelectMany(t => t.Teams)
                .Where(e => e.StadiumId != null)
                .Select(e => e.Stadium);

            return resultado.ToList();
        }

        public List<Stadium> GetStadiumSoccerGameByTournamentId(Tournament tournament)
        {
            var resultado = from torneo in ctx.Tournaments
                            from games in torneo.Games
                            where torneo.TournamentId == tournament.TournamentId
                            && games.LocalTeam.StadiumId != null
                            select games.LocalTeam.Stadium;


            return resultado.ToList();
        }
    }
}
