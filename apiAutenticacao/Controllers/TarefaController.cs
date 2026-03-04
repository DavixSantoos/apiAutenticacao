using apiAutenticacao.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using apiAutenticacao.Models;
using apiAutenticacao.Models.DTO;

namespace apiAutenticacao.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly AppDbContext _context;
        
           
            public TarefaController(AppDbContext context)
            {
                _context = context;
             }
        private int ObterUsuarioLogadoId()
        {
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(claimId!);
        }

        [HttpPost]

        public async Task<IActionResult> CadastrarTarefa([FromBody] TarefaResponseDTO dto)
        {
            var tarefa = new Tarefa
            {
                Descricao = dto.Descricao,
                DataHora = dto.DataHora,
                UsuarioId = ObterUsuarioLogadoId()
            };
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ListarTarefas), new { id = tarefa.Id }, new { tarefa.Id, tarefa.Descricao, tarefa.DataHora });
        }
        [HttpGet]
        public async Task<IActionResult> ListarTarefas()
        {
            var usuarioId = ObterUsuarioLogadoId();
            var tarefas = await _context.Tarefas
                .Where(t => t.UsuarioId == usuarioId)
                .Select(t => new TarefaResponseDTO
                {
                    Id = t.Id,
                    Descricao = t.Descricao,
                    DataHora = t.DataHora
                })
                .ToListAsync();
            return Ok(tarefas);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarTarefa(int id)
        {
            var usuarioId = ObterUsuarioLogadoId();
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id && t.UsuarioId == usuarioId);
            if (tarefa == null)
            {
                return NotFound();
            }
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }


}
