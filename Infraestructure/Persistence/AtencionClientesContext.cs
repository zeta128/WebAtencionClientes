using Microsoft.EntityFrameworkCore;
using WebAtencionClientes.Models.Entitites;

namespace WebAtencionClientes.Infraestructure.Persistence
{
    public class AtencionClientesContext: DbContext
    {
        public AtencionClientesContext(DbContextOptions<AtencionClientesContext> options): base(options)
        {
            
        }
        public DbSet<ATENCION_CLIENTE> InfoCliente { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
