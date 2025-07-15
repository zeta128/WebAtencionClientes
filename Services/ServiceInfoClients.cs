using Microsoft.EntityFrameworkCore;
using WebAtencionClientes.Infraestructure.Persistence;
using WebAtencionClientes.Models.Entitites;
using WebAtencionClientes.Services.Contracts;

namespace WebAtencionClientes.Services
{
    public class ServiceInfoClients : IServiceInfoClients
    {
        private readonly AtencionClientesContext _context;
        private static List<ATENCION_CLIENTE> _clients = new List<ATENCION_CLIENTE>();
        public async Task<List<ATENCION_CLIENTE>> GetInfoClientesList()
        {
            return _clients.ToList();
            //Obtener listado desde base de datos
          // return await _context.InfoCliente.ToListAsync();
        }

        public async Task<ATENCION_CLIENTE> InsertInfoCliente(ATENCION_CLIENTE cliente)
        {

            _clients.Add(cliente);
            return cliente;
            //Conexión con base de datos y guardado
            /*var clienteRegister = await _context.InfoCliente.AddAsync(cliente);
            _context.SaveChanges();
            return clienteRegister.Entity;*/
        }
    }
}
