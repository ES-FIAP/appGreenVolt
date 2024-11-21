using greenVolt.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace greenVolt.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaService _service;
        public EmpresaController(EmpresaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empresas = await _service.ObterTodas();
            return Ok(empresas);
        }
    }
}
