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
        public async Task<List<ATENCION_CLIENTE>> GetInfoClientesList(DateTime? fechaIni, DateTime? fechaFin)
        {
            if (fechaIni.HasValue && fechaFin.HasValue)
            {              
                return _clients.Where(c =>
                  c.FECHA_ALTA.Date >= fechaIni.Value.Date &&
                  c.FECHA_ALTA.Date <= fechaFin.Value.Date
              ).ToList();
            }
            else
            {
                return _clients.ToList();
            }
            //Obtener listado desde base de datos
            /* return await _context.InfoCliente.Where(c =>
            c.FECHA_ALTA.Date >= fechaIni.Value.Date &&
            c.FECHA_ALTA.Date <= fechaFin.Value.Date
              ).ToListAsync();*/
        }

        public async Task<ATENCION_CLIENTE> InsertInfoCliente(ATENCION_CLIENTE cliente)
        {
            if (_clients.Any(c => c.CELULAR == cliente.CELULAR && c.FECHA_ALTA.Date == DateTime.Now.Date) )
            {
                throw new Exception("El teléfono introducido en el formulario Web, existe y además ya se ha registrado alguna acción de Incidencia, Queja o Reclamación en el día actual.");
            }
            int nuevoId = _clients.Any() ? _clients.Max(c => c.Id) + 1 : 1;
            cliente.Id = nuevoId;
            cliente.FECHA_ALTA = DateTime.Now;
            _clients.Add(cliente);
            return cliente;
            //Conexión con base de datos y guardado
            /*var clienteRegister = await _context.InfoCliente.AddAsync(cliente);
            _context.SaveChanges();
            return clienteRegister.Entity;*/
        }
    }
}
