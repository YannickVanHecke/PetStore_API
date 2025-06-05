using Microsoft.EntityFrameworkCore;
using PetStore.Data.Model;

namespace PetStore.Data
{
    public class PetStoreContext : DbContext
    {
        public PetStoreContext(DbContextOptions<PetStoreContext> options) : base(options)
        {
            
        }

        public DbSet<Pet> Pets { get; set; }
    }
}
