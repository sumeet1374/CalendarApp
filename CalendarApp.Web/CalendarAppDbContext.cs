using CalendarApp.Db;
using CalendarApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Web
{
    public class CalendarAppDbContext:CalendarDbContext
    {
        private const string DBPATH = @"Db\Calendar.db";

        public IUnitOfWork Get()
        {
            return this;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole() { Id = 1, Name = "Admin", Deleted = false },
                new AppRole() { Id = 2, Name = "Organizer", Deleted = false },
                  new AppRole() { Id = 3, Name = "Participant", Deleted = false }
                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            var actualPath = Path.Combine(Directory.GetCurrentDirectory(), DBPATH);
            optionsBuilder.UseSqlite(string.Format("Data Source = {0}", actualPath));
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
