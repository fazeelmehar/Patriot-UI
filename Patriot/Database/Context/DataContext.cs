using Microsoft.EntityFrameworkCore;
using Patriot.Database.Domain;

namespace Patriot.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
