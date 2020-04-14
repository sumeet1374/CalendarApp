using CalendarApp.Model;
using Microsoft.EntityFrameworkCore;

namespace CalendarApp.Db
{
    public class CalendarDbContext :DbContext, IUnitOfWork
    {
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<AppRole>().ToTable("AppRole").HasKey(x=>x.Id);
            modelBuilder.Entity<AppUser>().ToTable("AppUser").HasKey(x => x.Id);
            modelBuilder.Entity<EventSchedule>().ToTable("EventSchedule").HasKey(x => x.Id);
            modelBuilder.Entity<EventScheduleExecution>().ToTable("EventScheduleExecution").HasKey(x => x.Id);
            modelBuilder.Entity<Participation>().ToTable("Participation").HasKey(x => x.Id);

        }

        public void Commit()
        {
            this.SaveChanges();
        }

        public T GetContext<T>() where T : class
        {
            return (this as T);
        }
    }
}
