﻿using System;
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
                new Player{FirstName="Ivan",LastName="Škaro",Email="ivan@email.com",DayOfBirth=DateTime.Parse("3.3.1986."),TelephoneNumber="+385958101986"},
                new Player{FirstName="Ana",LastName="Lauš",Email="ana@email.com",DayOfBirth=DateTime.Parse("13.5.1987."),TelephoneNumber="+385999208144"},
                new Player{FirstName="Viktor",LastName="Škaro",Email="viktor@email.com",DayOfBirth=DateTime.Parse("29.8.1979."),TelephoneNumber="+3851234567"},
                new Player{FirstName="Milenko",LastName="Škaro",Email="milenko@email.com",DayOfBirth=DateTime.Parse("3.9.1955."),TelephoneNumber="+38598339307"},
                new Player{FirstName="Kruno",LastName="Stražanac",Email="kruno@email.com",DayOfBirth=DateTime.Parse("1.1.1985."),TelephoneNumber="+38598123456"},
                new Player{FirstName="Milan",LastName="Marinić",Email="milan@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Goran",LastName="Ore",Email="goran@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Marko",LastName="Dukmenic",Email="marko@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Vatroslav",LastName="Mileusnic",Email="vatroslav@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Matija",LastName="Kopic",Email="matija@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Vedran",LastName="Sikic",Email="vedran@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Tomislav",LastName="Matijevic",Email="tomislav@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Daniel",LastName="Ferenc",Email="daniel@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Slaven",LastName="Stražanac",Email="slaven@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Davor",LastName="Grubelic",Email="davor@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Igor",LastName="Bedek",Email="igor@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Damir",LastName="Šmigovec",Email="damir@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Maja",LastName="Skalamera",Email="maja@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Krešimir",LastName="Marić",Email="kresimir@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Vanja",LastName="Paulik",Email="vanja@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Ivan",LastName="Lozić",Email="ivan.lozic@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Nandino",LastName="Lončar",Email="nandino@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Ivor",LastName="Banović",Email="ivor@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
                new Player{FirstName="Stjepan",LastName="Dorešić",Email="stjepan@email.com",DayOfBirth=DateTime.Parse("10.7.1977."),TelephoneNumber="+38591522245"},
            };
            players.ForEach(s => context.Players.Add(s));
            context.SaveChanges();

            var attackerOddEven = new List<AttackerOddEven>
            {
                new AttackerOddEven{ID=1, Name="Neparni napada"},
                new AttackerOddEven{ID=2, Name="Parni napada"},
            };
            attackerOddEven.ForEach(s => context.AttackerOddEven.Add(s));
            context.SaveChanges();



            var competitions = new List<Competition>
            {
                new Competition{CompetitionName="Ljetna piramida 2014", RowCapacity = 4, SetsNumber = 1, GamesNumber = 9},
                new Competition{CompetitionName="Zimska piramida 2014", RowCapacity = 6, SetsNumber = 1, GamesNumber = 9},
            };
            competitions.ForEach(s => context.Competitions.Add(s));
            context.SaveChanges();


            var rounds = new List<Round>
            {
                new Round{CompetitionID=1, RoundNumber=1, AttackerOddEvenID=2, DateFrom=DateTime.Parse("1.6.2014."), DateTo=DateTime.Parse("7.6.2014.")},
                new Round{CompetitionID=2, RoundNumber=1, AttackerOddEvenID=2, DateFrom=DateTime.Parse("30.10.2014."), DateTo=DateTime.Parse("5.11.2014.")},
            };
            rounds.ForEach(s => context.Rounds.Add(s));
            context.SaveChanges();



            var competitionRows = new List<CompetitionRow>
            {
                //Competition 1
                new CompetitionRow{RowNumber=1, RoundID=1},
                new CompetitionRow{RowNumber=2, RoundID=1},
                new CompetitionRow{RowNumber=3, RoundID=1},
                new CompetitionRow{RowNumber=4, RoundID=1},
                new CompetitionRow{RowNumber=5, RoundID=1},

                //Competition 2
                new CompetitionRow{RowNumber=1, RoundID=2},
                new CompetitionRow{RowNumber=2, RoundID=2},
                new CompetitionRow{RowNumber=3, RoundID=2},
                new CompetitionRow{RowNumber=4, RoundID=2},
            };
            competitionRows.ForEach(s => context.CompetitionRows.Add(s));
            context.SaveChanges();




            var competitionEnrollments = new List<CompetitionEnrollment>
            {
                //Competition 1
                new CompetitionEnrollment{PlayerID=1, CompetitionRowID=1, CompetitionRowPosition=1},
                new CompetitionEnrollment{PlayerID=2, CompetitionRowID=1, CompetitionRowPosition=2},
                new CompetitionEnrollment{PlayerID=3, CompetitionRowID=1, CompetitionRowPosition=3},
                new CompetitionEnrollment{PlayerID=4, CompetitionRowID=1, CompetitionRowPosition=4},
                new CompetitionEnrollment{PlayerID=5, CompetitionRowID=2, CompetitionRowPosition=1},
                new CompetitionEnrollment{PlayerID=6, CompetitionRowID=2, CompetitionRowPosition=2},
                new CompetitionEnrollment{PlayerID=7, CompetitionRowID=2, CompetitionRowPosition=3},
                new CompetitionEnrollment{PlayerID=8, CompetitionRowID=2, CompetitionRowPosition=4},
                new CompetitionEnrollment{PlayerID=9, CompetitionRowID=3, CompetitionRowPosition=1},
                new CompetitionEnrollment{PlayerID=10, CompetitionRowID=3, CompetitionRowPosition=2},
                new CompetitionEnrollment{PlayerID=11, CompetitionRowID=3, CompetitionRowPosition=3},
                new CompetitionEnrollment{PlayerID=12, CompetitionRowID=3, CompetitionRowPosition=4},
                new CompetitionEnrollment{PlayerID=13, CompetitionRowID=4, CompetitionRowPosition=1},
                new CompetitionEnrollment{PlayerID=14, CompetitionRowID=4, CompetitionRowPosition=2},
                new CompetitionEnrollment{PlayerID=15, CompetitionRowID=4, CompetitionRowPosition=3},
                new CompetitionEnrollment{PlayerID=16, CompetitionRowID=4, CompetitionRowPosition=4},
                new CompetitionEnrollment{PlayerID=17, CompetitionRowID=5, CompetitionRowPosition=1},
                new CompetitionEnrollment{PlayerID=18, CompetitionRowID=5, CompetitionRowPosition=2},
                new CompetitionEnrollment{PlayerID=19, CompetitionRowID=5, CompetitionRowPosition=3},
                new CompetitionEnrollment{PlayerID=20, CompetitionRowID=5, CompetitionRowPosition=4},

                //Competition 2
                new CompetitionEnrollment{PlayerID=1, CompetitionRowID=6, CompetitionRowPosition=1},
                new CompetitionEnrollment{PlayerID=2, CompetitionRowID=6, CompetitionRowPosition=2},
                new CompetitionEnrollment{PlayerID=3, CompetitionRowID=6, CompetitionRowPosition=3},
                new CompetitionEnrollment{PlayerID=4, CompetitionRowID=6, CompetitionRowPosition=4},
                new CompetitionEnrollment{PlayerID=5, CompetitionRowID=6, CompetitionRowPosition=5},
                new CompetitionEnrollment{PlayerID=6, CompetitionRowID=6, CompetitionRowPosition=6},
                new CompetitionEnrollment{PlayerID=7, CompetitionRowID=7, CompetitionRowPosition=1},
                new CompetitionEnrollment{PlayerID=8, CompetitionRowID=7, CompetitionRowPosition=2},
                new CompetitionEnrollment{PlayerID=9, CompetitionRowID=7, CompetitionRowPosition=3},
                new CompetitionEnrollment{PlayerID=10, CompetitionRowID=7, CompetitionRowPosition=4},
                new CompetitionEnrollment{PlayerID=11, CompetitionRowID=7, CompetitionRowPosition=5},
                new CompetitionEnrollment{PlayerID=12, CompetitionRowID=7, CompetitionRowPosition=6},
                new CompetitionEnrollment{PlayerID=13, CompetitionRowID=8, CompetitionRowPosition=1},
                new CompetitionEnrollment{PlayerID=14, CompetitionRowID=8, CompetitionRowPosition=2},
                new CompetitionEnrollment{PlayerID=15, CompetitionRowID=8, CompetitionRowPosition=3},
                new CompetitionEnrollment{PlayerID=16, CompetitionRowID=8, CompetitionRowPosition=4},
                new CompetitionEnrollment{PlayerID=17, CompetitionRowID=8, CompetitionRowPosition=5},
                new CompetitionEnrollment{PlayerID=18, CompetitionRowID=8, CompetitionRowPosition=6},
                new CompetitionEnrollment{PlayerID=19, CompetitionRowID=9, CompetitionRowPosition=1},
                new CompetitionEnrollment{PlayerID=20, CompetitionRowID=9, CompetitionRowPosition=2},
                new CompetitionEnrollment{PlayerID=21, CompetitionRowID=9, CompetitionRowPosition=3},
                new CompetitionEnrollment{PlayerID=22, CompetitionRowID=9, CompetitionRowPosition=4},
                new CompetitionEnrollment{PlayerID=23, CompetitionRowID=9, CompetitionRowPosition=5},
                new CompetitionEnrollment{PlayerID=24, CompetitionRowID=9, CompetitionRowPosition=6},
            };
            competitionEnrollments.ForEach(s => context.CompetitionEnrollments.Add(s));
            context.SaveChanges();

            var results = new List<Result>
            {
                new Result{RoundID=2, Player1ID=7, Player2ID=1, Player1SetOneScore=9, Player2SetOneScore=7},
                new Result{RoundID=2, Player1ID=8, Player2ID=2, Player1SetOneScore=7, Player2SetOneScore=9},
                new Result{RoundID=2, Player1ID=9, Player2ID=3, Player1SetOneScore=2, Player2SetOneScore=9},
                new Result{RoundID=2, Player1ID=10, Player2ID=4, Player1SetOneScore=9, Player2SetOneScore=4},
                new Result{RoundID=2, Player1ID=11, Player2ID=5, Player1SetOneScore=9, Player2SetOneScore=5},
                new Result{RoundID=2, Player1ID=12, Player2ID=6, Player1SetOneScore=2, Player2SetOneScore=9},
                new Result{RoundID=2, Player1ID=19, Player2ID=13, Player1SetOneScore=9, Player2SetOneScore=7},
                new Result{RoundID=2, Player1ID=20, Player2ID=14, Player1SetOneScore=8, Player2SetOneScore=9},
                new Result{RoundID=2, Player1ID=21, Player2ID=15, Player1SetOneScore=9, Player2SetOneScore=1},
                new Result{RoundID=2, Player1ID=22, Player2ID=16, Player1SetOneScore=1, Player2SetOneScore=9},
                new Result{RoundID=2, Player1ID=23, Player2ID=17, Player1SetOneScore=9, Player2SetOneScore=3},
                new Result{RoundID=2, Player1ID=24, Player2ID=18, Player1SetOneScore=8, Player2SetOneScore=9},
            };
            results.ForEach(s => context.Results.Add(s));
            context.SaveChanges();

        }
    }
}