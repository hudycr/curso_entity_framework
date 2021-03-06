﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoccerApp.Data;
using SoccerApp.Domain;
using System.Data.Entity;
using SoccerApp.Services;

namespace SoccerApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //iniciar datos de team
            Team t = new Team
            {
                Active = true,
                CountryName = "Belgica",
                Founded = DateTime.Now,
                Name = "Belgica",
                TournamentId = 1
            };
            List<Player> jugadores = new List<Player>();
            jugadores.Add(new Player
            {
                Active = true,
                Name = "Player Belgica 10",
                DateOfBirth = DateTime.Now,
                Number = 10,
                PersonalInfo = new PersonalInfo
                {
                    Address = "Direccion X",
                    Height = Convert.ToDecimal("1.70"),// new Decimal(1.70),
                    Nationality = "Belgica",
                    Photo = "Player01.jpg"
                }
            });

            t.Players = jugadores;
            //iniciar datos staff
            Staff medico = new Medical
            {
                Name = "Preparador Físico Francia",
                Speciality = "Fisica",
                PersonalInfo = new PersonalInfo { Address = "Direccion 01" }
            };

            using (var ctx = new SoccerAppContext())
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    //instruccion para que escriba en consola los comandos SQL
                    ctx.Database.Log = Console.Write;

                    try
                    {
                        TeamService teamService = new TeamService(ctx);
                        StaffService staffService = new StaffService(ctx);

                        //crear equipo
                        Console.WriteLine("Crear equipo --------------------------------");
                        teamService.Insert(t);
                        Console.WriteLine("Registro de equipo exitoso");

                        //crear staff
                        Console.WriteLine("Crear staff --------------------------------");
                        staffService.Insert(medico);
                        Console.WriteLine("Registro de equipo exitoso");
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error {0}", ex);
                    }
                }
            }
            Console.ReadLine();
        }

        void PruebaConsulta()
        {
            using (var ctx = new SoccerAppContext())
            {
                //instruccion para que escriba en consola los comandos SQL
                ctx.Database.Log = Console.Write;

                Tournament t = new Tournament
                {
                    TournamentId = 1,
                    Name = "Rusia 2018"
                };
                try
                {
                    TournamentService service = new TournamentService(ctx);
                    //consultar por identificador de torneo
                    var estadios = service.GetStadiumByTournamentName(t);

                    foreach (var estadio in estadios)
                    {
                        Console.WriteLine("Equipo: {0} - Estadio: {1}", estadio.Name, estadio.Team.Name);
                    }
                    //consultar por nombre de torneo
                    estadios = service.GetStadiumByTournamentId(t);
                    foreach (var estadio in estadios)
                    {
                        Console.WriteLine("Equipo: {0} - Estadio: {1}", estadio.Name, estadio.Team.Name);
                    }

                    var estadiosConJuegos = service.GetStadiumSoccerGameByTournamentId(t);

                    foreach (var estadio in estadiosConJuegos)
                    {
                        Console.WriteLine("Equipo: {0} - Estadio: {1}", estadio.Name, estadio.Team.Name);
                    }

                    Console.WriteLine(" ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error {0}", ex);
                }
            }
            Console.ReadLine();
        }

        void PruebaStaffs()
        {
            Staff coach = new Coach
            {
                Name = "Entrenador Francia",
                Active = true,
                CountryName = "Francia",
                DebutDate = DateTime.Now,
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                PersonalInfo = new PersonalInfo
                {
                    Address = "Direccion"
                }
            };

            Staff medico = new Medical
            {
                Name = "Nutriologo Francia",
                Speciality = "Nutrición",
                PersonalInfo = new PersonalInfo { Address = "Direccion 01" }
            };
            using (var ctx = new SoccerAppContext())
            {
                //instruccion para que escriba en consola los comandos SQL
                ctx.Database.Log = Console.Write;

                try
                {
                    StaffService service = new StaffService(ctx);
                    service.Insert(medico);
                    Console.WriteLine("Registro exitoso");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error {0}", ex);
                }
            }
            Console.ReadLine();
        }
        void PruebaDirectivos()
        {
            Directive presidente = new President
            {
                Name = "Presidente FIFA",
                Departament = "FIFA",
                Email = "presidente@email.com",
                Subordinates = new List<Directive>()
            };

            Directive director = new Director
            {
                Name = "Director FIFA",
                Departament = "FIFA",
                Phone = "9999 123456",
                Subordinates = new List<Directive>()
            };

            presidente.Subordinates.Add(director);

            Directive secretario = new Secretary
            {
                Name = "Secretario FIFA",
                Departament = "FIFA",
                Fax = "NA"
            };
            director.Subordinates.Add(secretario);

            using (var ctx = new SoccerAppContext())
            {
                //instruccion para que escriba en consola los comandos SQL
                ctx.Database.Log = Console.Write;

                try
                {
                    DirectiveService service = new DirectiveService(ctx);
                    service.Insert(presidente);
                    Console.WriteLine("Registro exitoso");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error {0}", ex);
                }
            }
            Console.ReadLine();
        }
        void PruebaTeamService()
        {
            Team t = new Team
            {
                Active = true,
                CountryName = "Croacia",
                Founded = DateTime.Now,
                Name = "Croacia",
                TournamentId = 1
            };
            List<Player> jugadores = new List<Player>();
            jugadores.Add(new Player
            {
                Active = true,
                Name = "Player Croacia 10",
                DateOfBirth = DateTime.Now,
                Number = 10,
                PersonalInfo = new PersonalInfo
                {
                    Address = "Direccion X",
                    Height = Convert.ToDecimal("1.70"),// new Decimal(1.70),
                    Nationality = "Croata",
                    Photo = "Player01.jpg"
                }
            });

            t.Players = jugadores;
            TeamService service = new TeamService(null);
            try
            {
                service.Insert(t);
                Console.WriteLine("Registro exitoso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error {0}", ex.Message);
            }
            Console.ReadLine();
        }

        void PruebaTournamentService()
        {
            Tournament t = new Tournament
            {
                CreationDate = DateTime.Now,
                Name = "RusíA 2018"
            };

            TournamentService service = new TournamentService(null);
            try
            {
                service.Insert(t);
                Console.WriteLine("Registro exitoso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error {0}", ex.Message);
            }
            Console.ReadLine();
        }

        void PruebaVista()
        {
            #region insertar equipo
            using (var ctx = new SoccerAppContext())
            {
                Team alemania = new Team
                {
                    Active = true,
                    CountryName = "Alemania",
                    Founded = DateTime.Now,
                    Name = "Alemania",
                    /*Stadium = new Stadium
                    {
                        CorporateNaming = "Olimpico Berlín",
                        Name = "Olimpico Berlín",
                        Country = "Alemania"
                    },*/
                    TournamentId = 1,
                    Players = new List<Player>
                    {
                        new Player { Name ="Toni Kross", Active = true, DateOfBirth = DateTime.Now, Number = 10 },
                        new Player { Name ="Thomas Muller", Active = true, DateOfBirth = DateTime.Now, Number = 7 },
                        new Player { Name ="Ozil", Active = true, DateOfBirth = DateTime.Now, Number = 13 }
                    }
                };
                try
                {
                    ctx.Teams.Add(alemania);
                    //ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            #endregion

            using (var ctx = new SoccerAppContext())
            {
                var marcadores = ctx.GameScoreViews;

                foreach (var m in marcadores)
                {
                    Console.WriteLine("{0} {1}  - {2} {3}",
                        m.LocalTeam, m.LocalScore, m.VisitScore, m.VisitTeam);
                }
            }
            Console.ReadKey();
        }
        void pruebaAnotaciones()
        {
            using (var ctx = new SoccerAppContext())
            {
                Team team1 = new Team
                {
                    Name = "México",
                    CountryName = "MX",
                    Founded = DateTime.Now,
                    Players = new List<Player>()
                };

                team1.Players.Add(new Player { Name = "Player1", Number = 10 });
                team1.Players.Add(new Player { Name = "Player2", Number = 7, DateOfBirth = DateTime.Now });

                ctx.Teams.Add(team1);
                ctx.SaveChanges();
            }
        }
    
        void eliminar()
        {
            //eliminar un jugador de un equipo
            using (var ctx = new SoccerAppContext())
            {
                Team team1 = new Team
                {
                    Name = "México",
                    CountryName = "MX",
                    Founded = DateTime.Now,
                    Players = new List<Player>()
                };

                team1.Players.Add(new Player { Name = "Player1", Number = 10 });
                team1.Players.Add(new Player { Name = "Player2", Number = 7, DateOfBirth = DateTime.Now });

                var necaxa = ctx.Teams.Where(t => t.TeamId == 5)
                    .Include(t => t.Players)
                    .FirstOrDefault();

                if (necaxa != null)
                {

                    try
                    {
                        //necaxa.Players.Remove(necaxa.Players.First());
                        Player player = ctx.Players.Where(p => p.PlayerId == 9)
                            .Include(p => p.Goals).FirstOrDefault();

                        //ctx.Players.Remove(necaxa.Players.First());
                        ctx.Goals.RemoveRange(player.Goals);
                        ctx.Players.Remove(player);
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                        if (ex.InnerException != null)
                            Console.WriteLine("Error {0}", ex.InnerException);
                    }
                }
            }

        }

        void AgregarUnGolAJuego()
        {
            //Agregar un jugador al equipo
            /**using (var ctx = new SoccerAppContext())
            {
                Team necaxa = ctx.Teams.Where(t => t.Name.Contains("Necaxa")).Include(t => t.Players).FirstOrDefault();
                necaxa.Players.Add(new Player { Name = "Player 01", DateOfBirth = DateTime.Now, Active = true, Number = 10 });

                ctx.SaveChanges();
            }**/


            //agregar un gol a un juego del torneo ID =4
            using (var ctx = new SoccerAppContext())
            {
                var tournament = ctx.Tournaments.Where(t => t.TournamentId == 4)
                    .Include(t => t.Teams)
                    .Include(t => t.Games)
                    .FirstOrDefault();

                if (tournament != null)
                {
                    //consultamos el id del team
                    //int necaxaId = tournament.Teams.FirstOrDefault(t => t.Name.Contains("Necaxa")).TeamId;
                    Team necaxa = tournament.Teams.FirstOrDefault(t => t.Name.Contains("Necaxa"));
                    //int necaxaId = necaxa.TeamId.Value;
                    //consultamos los jugadores
                    //var plyLts = ctx.Teams.Where(t => t.TeamId == necaxaId).Include(t => t.Players).SelectMany(t => t.Players).ToList();
                    var plyLts = necaxa.Players;
                    // agregar un gol a juego
                    SoccerGame soccerGame = tournament.Games.ElementAt(0);
                    //soccerGame.Goals = new List<Goal>();
                    soccerGame.Goals.Add(new Goal { Scorer = plyLts.FirstOrDefault(), ScoringTime = 79 });
                    try
                    {
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                        if (ex.InnerException != null)
                            Console.WriteLine("Error {0}", ex.InnerException);
                    }
                }
            }
        }

        void AgregarJuegoATorneo()
        {
            //crear un torneo con dos equipos
            /*using (var ctx = new SoccerAppContext())
            {
                Tournament t = new Tournament
                {
                    Name = "Liga MX",
                    CreationDate = DateTime.Now,
                    Teams = new List<Team>()
                };

                t.Teams.Add(new Team { Name = "Necaxa", Active = true, CountryName = "MX", Founded = DateTime.Now });
                t.Teams.Add(new Team { Name = "Guadalajara", Active = true, CountryName = "MX", Founded = DateTime.Now });
                t.Teams.Add(new Team { Name = "Monterrey", Active = true, CountryName = "MX", Founded = DateTime.Now });

                ctx.Tournaments.Add(t);
                ctx.SaveChanges();
            }*/


            //agregar un juego al torneo
            using (var ctx = new SoccerAppContext())
            {
                //Consulta el torneo
                var tournameLst = from t in ctx.Tournaments
                                  where t.Name.CompareTo("Liga MX") == 0
                                  select t;
                var tournament = tournameLst.FirstOrDefault();

                if (tournament != null)
                {

                    //consultar los equipos
                    var necTeam = ctx.Teams.FirstOrDefault(team => team.Name.CompareTo("Necaxa") == 0);
                    var guaTeam = ctx.Teams.FirstOrDefault(team => team.Name.CompareTo("Guadalajara") == 0);
                    //var teamLst = ctx.Tournaments.Where(t => t.TournamentId == tournament.TournamentId).Include(t => t.Teams).SelectMany(x => x.Teams).ToList();
                    //crear el juego
                    SoccerGame scg = new SoccerGame
                    {
                        Date = DateTime.Now,
                        LocalTeam = necTeam,
                        VisitTeam = guaTeam,
                        GameNumber = 3
                    };

                    try
                    {
                        tournament.CreationDate = DateTime.Now;
                        tournament.Games = new List<SoccerGame>();
                        tournament.Games.Add(scg);

                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                        if (ex.InnerException != null)
                            Console.WriteLine("Error {0}", ex.InnerException);
                    }
                }
            }
        }

        void ConsultarTorneos()
        {
            using (var ctx = new SoccerAppContext())
            {
                var teamLst = from t in ctx.Tournaments
                              where t.TournamentId >= 1 || t.Name.Contains("rus")
                              select t.Teams;

                var teamLst2 = ctx.Tournaments.Where(t => t.Name.Contains("rus"))
                    .Select(t => t.Teams);

                foreach (var teams in teamLst2)
                {
                    foreach (var innerTeam in teams)
                    {
                        Console.WriteLine("Equipo: {0} - {1}", innerTeam.TeamId, innerTeam.Name);
                    }
                }
                Console.ReadKey();
            }
        }

        public static void InsertNewTeam()
        {
            using (var ctx = new SoccerAppContext())
            {
                
                Console.ReadKey();
            }
        }

        public static void InsertData()
        {
            using (var ctx = new SoccerAppContext())
            {
                Tournament tourn = new Tournament
                {
                    Name = "Mundial Rusia 2018",
                    CreationDate = DateTime.Now,
                    Teams = new List<Team>()
                };

                Team team1 = new Team
                {
                    Name = "México",
                    CountryName = "MX",
                    Founded = DateTime.Now,
                    Players = new List<Player>()
                };

                team1.Players.Add(new Player { Name = "Player1", Number = 10 });
                team1.Players.Add(new Player { Name = "Player2", Number = 7, DateOfBirth = DateTime.Now });
                tourn.Teams.Add(team1);

                ctx.Tournaments.Add(tourn);
                ctx.SaveChanges();

            }
        }
    }
}
