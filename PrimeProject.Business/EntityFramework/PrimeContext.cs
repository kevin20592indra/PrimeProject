using System.Data.Entity;
using PrimeProject.Business.Entity;

namespace PrimeProject.Business.EntityFramework
{
    public class PrimeContext : DbContext
    {
        public DbSet<Item> Items{ get; set; }
        public PrimeContext() : base("name=PrimeContext")
        {

        }
    }
}
