using Microsoft.EntityFrameworkCore;
using clientes.API.Models;

namespace clientes.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :
            base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
