using WebAtencionClientes.Models.Entitites;

namespace WebAtencionClientes.Services.Contracts
{
    public interface IServiceInfoClients
    {
        Task<ATENCION_CLIENTE> InsertInfoCliente(ATENCION_CLIENTE cliente);
        Task<List<ATENCION_CLIENTE>> GetInfoClientesList(DateTime? fechaIni, DateTime? fechaFin);

    }
}
