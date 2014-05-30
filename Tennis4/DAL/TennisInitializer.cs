using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Tennis4.Models;

namespace Tennis4.DAL
{
    public class TennisInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TennisContext>
    {
        protected override void Seed(TennisContext context)
        {
            var players = new List<Player>
            {
                new Player{FirstName="Ivan",LastName="Škaro",DayOfBirth=DateTime.Parse("3.3.1986."),TelephoneNumber="+385958101986"},
                new Player{FirstName="Ana",LastName="Lauš",DayOfBirth=DateTime.Parse("13.5.1987."),TelephoneNumber="+385999208144"},
                new Player{FirstName="Viktor",LastName="Škaro",DayOfBirth=DateTime.Parse("29.8.1979."),TelephoneNumber="+3851234567"},
                new Player{FirstName="Milenko",LastName="Škaro",DayOfBirth=DateTime.Parse("3.9.1955."),TelephoneNumber="+38598339307"},
                new Player{FirstName="Kruno",LastName="Stražanac",DayOfBirth=DateTime.Parse("1.1.1985."),TelephoneNumber="+38598123456"},
                new Player{FirstName="Milan",LastName="Marinić",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"}
            };
            players.ForEach(s => context.Players.Add(s));
            context.SaveChanges();
            



            var competitions = new List<Competition>
            {
                new Competition{CompetitionName="Ljetna piramida 2014"},
                new Competition{CompetitionName="Zimska piramida 2014"},
            };
            competitions.ForEach(s => context.Competitions.Add(s));
            context.SaveChanges();




            var competitionRows = new List<CompetitionRow>
            {
                new CompetitionRow{Row=1},
                new CompetitionRow{Row=2},
                new CompetitionRow{Row=3},
            };
            competitionRows.ForEach(s => context.CompetitionRows.Add(s));
            context.SaveChanges();




            var competitionEnrollments = new List<CompetitionEnrollment>
            {
                new CompetitionEnrollment{PlayerID=1, CompetitionID=1, CompetitionRowID=1},
                new CompetitionEnrollment{PlayerID=2, CompetitionID=1, CompetitionRowID=1},
                new CompetitionEnrollment{PlayerID=3, CompetitionID=1, CompetitionRowID=2},
                new CompetitionEnrollment{PlayerID=4, CompetitionID=1, CompetitionRowID=2},
                new CompetitionEnrollment{PlayerID=5, CompetitionID=1, CompetitionRowID=3},
                new CompetitionEnrollment{PlayerID=6, CompetitionID=1, CompetitionRowID=3},
            };
            competitionEnrollments.ForEach(s => context.CompetitionEnrollments.Add(s));
            context.SaveChanges();
        }
    }
}