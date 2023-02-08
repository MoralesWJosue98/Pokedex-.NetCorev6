using Microsoft.EntityFrameworkCore;

namespace Pokedex.Repository
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }



    }
}
