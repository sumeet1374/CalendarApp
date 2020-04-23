using CalendarApp.Db;
using Microsoft.EntityFrameworkCore;

namespace CalendarApp.Service.Test
{
    public class MemoryDbContext: CalendarDbContext
    {
        private string _databaseName;
        public MemoryDbContext(string databaseName)
        {
            _databaseName = databaseName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: _databaseName);
        }
    }
}
