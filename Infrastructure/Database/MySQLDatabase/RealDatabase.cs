﻿using Domain.Models;
using Domain.Models.User;
using Infrastructure.Database.DatabaseHelpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.MySQLDatabase
{
    public class RealDatabase : DbContext
    {
        public RealDatabase() { }
        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options) { }

        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string hidden = "\"Server=NM-FRONTEDGE\\\\SQLEXPRESS; Database=api_project_db; Trusted_Connection=true; TrustServerCertificate=true;\""
            optionsBuilder.UseSqlServer(hidden).AddInterceptors(new CommandLoggingInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Call the SeedData method from the external class
            DatabaseSeedHelper.SeedData(modelBuilder);
        }
    }
}