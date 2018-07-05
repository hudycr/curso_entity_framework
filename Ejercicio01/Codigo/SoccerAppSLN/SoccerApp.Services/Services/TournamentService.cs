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
        public void Insert(Tournament tournament)
        {
            using(var ctx = new SoccerAppContext())
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
        }
    }
}
