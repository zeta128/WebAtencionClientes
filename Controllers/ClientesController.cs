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
        public async Task<IActionResult> ListClients()
        {
            return View(await _serviceInfoClients.GetInfoClientesList());
        }
        [HttpGet]
        public async Task<IActionResult> AddClients()
        {
            
                return View(new ATENCION_CLIENTE { FECHA_ALTA = DateTime.Now });
       
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
                    return RedirectToAction("ListClients");
                }
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");
            }
            return View(client);

        }
       
    }
}
