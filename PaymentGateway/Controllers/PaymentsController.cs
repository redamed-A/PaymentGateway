using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Queries;
using System;
using System.Threading.Tasks;
using PaymentGateway.Commands;

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("ProcessPayment", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var query = new GetAllPaymentsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{paymentId}")]
        public async Task<IActionResult> GetPayment(Guid paymentId)
        {
            var query = new GetPaymentByIdQuery(paymentId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}