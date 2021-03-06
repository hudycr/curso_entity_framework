﻿using SoccerApp.Data;
using SoccerApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Services
{
    public class TeamService
    {

        private SoccerAppContext ctx;

        public TeamService(SoccerAppContext contexto)
        {
            //this.contexto = contexto !=  null ? contexto : new SoccerAppContext();
            //misma instruccion que la de arriba:
            this.ctx = contexto ?? new SoccerAppContext();
        }

        public void Insert(Team team)
        {
            
            #region validaciones
            //el equipo debe tener al menos un jugador
            if (team == null)
                throw new ArgumentNullException("Team", "No se permite valor nulo");
            //el equipo debe tener lista inicializada de jugadores
            if (team.Players == null)
                throw new ArgumentNullException("Team.Players", "No se permite una lista nula de jugadores");
            //el equipo debe tene al menos un jugador en su listado 
            if (team.Players.Count == 0)
                throw new ArgumentException("La lista de jugadores no puede estar vacia");
            //nombre no repetido en el mismo torneo
            var equipoRepetido = ctx.Teams
                .FirstOrDefault(t => t.Name == team.Name
                    && t.TournamentId == team.TournamentId);
            if (equipoRepetido != null)
                throw new ArgumentException("El nombre del equipo ya existe");
            #endregion

            ctx.Teams.Add(team);
            ctx.SaveChanges();
            
        }
    }
}
