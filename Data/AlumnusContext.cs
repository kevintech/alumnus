using Microsoft.EntityFrameworkCore;
using alumnus.Models.Contacts;
using alumnus.Models.Oportunities;
using alumnus.Models.Resources;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace alumnus.Data
{
    public class AlumnusContext : IdentityDbContext<IdentityUser>
    {
        public AlumnusContext(DbContextOptions<AlumnusContext> options)
            : base(options)
        {
        }

        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Oportunities> Oportunities { get; set; }
        public DbSet<Resources> Resources { get; set; }
    }
}