using Microsoft.EntityFrameworkCore;


namespace MyAPIProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Etudiant> Etudiants { get; set; }
    }
}