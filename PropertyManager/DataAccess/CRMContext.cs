using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.Context
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options) : base(options) { }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Property> Property { get; set; }

        public DbSet<PropertyOwnership> PropertyOwnership { get; set; }

        public DbSet<Log> Log { get; set; }

        public DbSet<UsageLog> UsageLog { get; set; }
    }
}
