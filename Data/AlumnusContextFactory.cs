using Microsoft.EntityFrameworkCore;

namespace alumnus.Data
{
    public static class AlumnusContextFactory
    {
        public static AlumnusContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AlumnusContext>();
            optionsBuilder.UseMySQL(connectionString);
            var context = new AlumnusContext(optionsBuilder.Options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}