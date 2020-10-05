using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Questions.Domain.Models;

namespace Questions.Services.Data
{
    
    public class QuestionsContext : DbContext
    {
        public QuestionsContext() { }

        public QuestionsContext(DbContextOptions<QuestionsContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choice { get; set; }
        
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Question && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((Question)entityEntry.Entity).PublishedAt = DateTime.Now;
            }

            return base.SaveChanges();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("LocalConnection"));
        }
    }
}