using B3.FixedIncome.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace B3.FixedIncome.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CdbController : Controller
    {       
        private readonly IMediator _mediator;
        public CdbController(IMediator mediator)
        {         
            _mediator = mediator;
        }

        /// <summary>
        /// Realiza o cálculo do investimento CDB no final de meses informados
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("calculation")]
        public async Task<IActionResult> Calculate(CalculateCdbCommand request)
        {
            var response = await _mediator.Send(request);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response.Data);
        }
    }
}
