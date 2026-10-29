using CarteiraDigital.Core.Interfaces.Applications;
using CarteiraDigital.Core.Models.inputModels;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigital.Api.Controllers
{
    public class  ClienteController(ICadastrarClienteApplication cadastrarClienteApplication) : MainController
    {
        private readonly ICadastrarClienteApplication _cadastrarClienteApplication = cadastrarClienteApplication;

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync([FromBody] ClienteInputModel inputModel) 
        {
            var id = await _cadastrarClienteApplication.CadastrarAsync(inputModel);

            return Ok(id);
        }
    }
}
