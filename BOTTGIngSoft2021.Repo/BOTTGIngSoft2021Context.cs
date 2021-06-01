using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Data.Maps;
using Microsoft.EntityFrameworkCore;

namespace BOTTGIngSoft2021.Repo
{
    public class BOTTGIngSoft2021Context : DbContext
    {
        public BOTTGIngSoft2021Context(DbContextOptions<BOTTGIngSoft2021Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new IntentMap(modelBuilder.Entity<Intent>());
            new UsersBotMap(modelBuilder.Entity<UsersBot>());
            new ExampleMap(modelBuilder.Entity<Example>());
        }
    }
}
