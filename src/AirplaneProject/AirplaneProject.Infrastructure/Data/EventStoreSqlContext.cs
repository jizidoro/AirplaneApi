using AirplaneProject.Core.Events;
using AirplaneProject.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;


namespace AirplaneProject.Infrastructure.Data
{ 
    public class EventStoreSqlContext : DbContext
    {
        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options) : base(options) { }

        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}