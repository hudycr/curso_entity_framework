SELECT        j.JuegoId AS SoccerGameId, j.TorneoId AS TournamentId, j.EquipoLocalId AS LocalTeamId, j.EquipoVisitanteId AS VisitTeamId, eLocal.Nombre AS LocalTeam, eVisitante.Nombre AS VisitTeam, COUNT(juLocal.JugadorId) 
                         AS LocalScore, COUNT(juVisitante.JugadorId) AS VisitScore
FROM            dbo.Juegos AS j INNER JOIN
                         dbo.Equipos AS eLocal ON eLocal.EquipoId = j.EquipoLocalId INNER JOIN
                         dbo.Equipos AS eVisitante ON eVisitante.EquipoId = j.EquipoVisitanteId LEFT OUTER JOIN
                         dbo.Goles AS g ON g.JuegoId = j.JuegoId LEFT OUTER JOIN
                         dbo.Jugadores AS juLocal ON juLocal.JugadorId = g.ScorerId AND juLocal.TeamId = j.EquipoLocalId LEFT OUTER JOIN
                         dbo.Jugadores AS juVisitante ON juVisitante.JugadorId = g.ScorerId AND juVisitante.TeamId = j.EquipoVisitanteId
GROUP BY j.JuegoId, j.TorneoId, j.EquipoLocalId, j.EquipoVisitanteId, eLocal.Nombre, eVisitante.Nombre