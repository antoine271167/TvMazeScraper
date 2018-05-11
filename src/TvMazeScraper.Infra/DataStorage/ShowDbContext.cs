#region [ Using ]

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using TvMazeScraper.Infra.DataStorage.Entities;

#endregion

namespace TvMazeScraper.Infra.DataStorage
{
    public class ShowDbContext : DbContext
    {
        public ShowDbContext() : base(DatabaseConnectionNames.ShowData)
        {
            Database.SetInitializer<ShowDbContext>(null);
        }

        public DbSet<Show> Shows { get; set; }
        public DbQuery<Show> ShowsNoTracking => Set<Show>().AsNoTracking();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema(SchemaNames.TvMazeSchema);
            modelBuilder.Entity<Show>();
            base.OnModelCreating(modelBuilder);
        }
    }
}