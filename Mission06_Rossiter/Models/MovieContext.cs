using Microsoft.EntityFrameworkCore;

namespace Mission06_Rossiter.Models
{
    //Context page to help create Database
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<AddMovie> Movies { get; set; }
    }
}
