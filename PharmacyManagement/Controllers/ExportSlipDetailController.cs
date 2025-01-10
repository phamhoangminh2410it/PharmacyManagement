using Microsoft.AspNetCore.Mvc;
using PharmacyManagement.Models.Entities;
using PharmacyManagement.Services;

namespace PharmacyManagement.Controllers
{
    [Route("Api/[Controller]")]
    public class ExportSlipDetailController : Controller
    {
        PharmacyManagementContext _context;
        IExportSlipDetailServices _services;

        public ExportSlipDetailController(PharmacyManagementContext context, IExportSlipDetailServices services)
        {
            _context = context;
            _services = services;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Modify")]
        public async Task<dynamic> Modify([FromBody] Chitietphieuxuat ctphieuxuat)
        {
            var result = await _services.Modify(ctphieuxuat);
            return Ok(result);
        }

        [HttpPost("Read")]
        public async Task<dynamic> Read()
        {
            var result = await _services.Read();
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<dynamic> Delete(int id)
        {
            var result = await _services.Delete(id);
            return Ok(result);
        }
    }
}
