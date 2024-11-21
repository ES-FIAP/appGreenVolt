using greenVolt.Aplicacao;
using greenVolt.Dominio;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empresa = await _service.ObterPorId(id);
            if (empresa == null) return NotFound();
            return Ok(empresa);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Empresa novaEmpresa)
        {
            try
            {
                var empresaCriada = await _service.Adicionar(novaEmpresa);
                return CreatedAtAction(nameof(GetById), new { id = empresaCriada.id_empresa }, empresaCriada);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro interno do servidor.", detalhe = ex.Message });
            }
        }

    }
}
