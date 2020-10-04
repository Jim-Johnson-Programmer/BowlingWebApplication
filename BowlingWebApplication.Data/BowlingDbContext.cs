using System;
using System.IO;
using BowlingWebApplication.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BowlingWebApplication.Data
{
    public class BowlingDbContext:DbContext
    {
        public DbSet<Frame> Frames { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<FrameStatus> FrameStatuses { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }
        public DbSet<Player> Players { get; set; }


        public BowlingDbContext() 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BowlingDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
