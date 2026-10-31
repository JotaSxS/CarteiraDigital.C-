using CarteiraDigital.Application.Applications;
using CarteiraDigital.Core.Interfaces.Applications;
using CarteiraDigital.Core.Models.inputModels;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigital.Api.Controllers
{
    public class  ClienteController(
        ICadastrarClienteApplication cadastrarClienteApplication,
        IBuscarClientesApplication buscarClientesApplication,
        IBuscarClientePorIdApplication buscarClientePorIdApplication,
        IAtualizarClienteApplication atualizarClienteApplication
        ) : MainController
    {
      
        [HttpPost]
        public async Task<IActionResult> CadastrarAsync([FromBody] ClienteInputModel inputModel) 
        {
            var id = await cadastrarClienteApplication.CadastrarAsync(inputModel);

            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarAsync()
        {
            var clientes = await buscarClientesApplication.BuscarAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorIdAsync([FromRoute] Guid id) 
        {
            var cliente = await buscarClientePorIdApplication.BuscarPorIdAsync(id);

            if (cliente == null) 
            {
                return NotFound();
            }

            return Ok(cliente);

        }

        [HttpPut(("{id}"))]
        public async Task<IActionResult> AtualizarAsync([FromRoute] Guid id, [FromBody] AtualizarClienteInputModel inputModel)
        {
            await atualizarClienteApplication.AtualizarAsync(id, inputModel);
            return NoContent();
        }
    }
}
