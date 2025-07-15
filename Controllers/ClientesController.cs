using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAtencionClientes.Infraestructure.Persistence;
using WebAtencionClientes.Models.Entitites;
using WebAtencionClientes.Services.Contracts;

namespace WebAtencionClientes.Controllers
{

    [Route("[controller]/[action]")] // Esto hace que el controlador se mapee a api/usuarios, por ejemplo
    public class ClientesController : Controller
    {
        private readonly IServiceInfoClients _serviceInfoClients;
        public ClientesController(IServiceInfoClients serviceInfoClients)
        {
            _serviceInfoClients = serviceInfoClients;
        }

        [HttpGet]
        public async Task<IActionResult> ListClients(DateTime? fechaInicio, DateTime? fechaFin)
        {
            List<ATENCION_CLIENTE> clientes = new List<ATENCION_CLIENTE>();

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                clientes = await _serviceInfoClients.GetInfoClientesList(fechaInicio,fechaFin);
            }
            else
            {
                clientes = await _serviceInfoClients.GetInfoClientesList(null,null);
            }
            return View(clientes);
        }
       
        [HttpGet]
        public async Task<IActionResult> AddClients()
        {
            
                return View(new ATENCION_CLIENTE());
       
        }
        [HttpPost]
        public async Task<IActionResult> AddClients(ATENCION_CLIENTE client)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceInfoClients.InsertInfoCliente(client);
                    TempData["AlertMessage"] = "Cliente registrado correctamente";
                    TempData["mensaje"] = "Registro exitoso";                 
                    return RedirectToAction("ListClients");
                }
                
            }
            catch (Exception ex)
            {      
                TempData["mensaje"] = ex.Message;
            }
            return View(client);

        }
       
    }
}
