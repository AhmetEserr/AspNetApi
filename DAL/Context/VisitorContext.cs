using ApiWorking.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiWorking.DAL.Context
{
    public class VisitorContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CSNBAHMETESER\\SQLEXPRESS01; Database=ApiDb; integrated security=true; Trusted_Connection=True;" +
                "MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
