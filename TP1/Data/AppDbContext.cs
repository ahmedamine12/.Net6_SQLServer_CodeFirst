using Microsoft.EntityFrameworkCore;

namespace TP1.Data
{
    public class AppDbContext : DbContext
    {
        // Adjust the constructor to accept DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Etudiant> Etudiants { get; set; }
    }
}