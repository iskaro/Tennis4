using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tennis4.Models;

namespace Tennis4.DAL
{
    public class TennisContext : DbContext
    {
        public TennisContext() : base("TennisContext")
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<CompetitionEnrollment> CompetitionEnrollments { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionRow> CompetitionRows { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<AttackerOddEven> AttackerOddEven { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}