using CTC.Application.PaymentCommand;
using CTC.Application.PaymentCommand.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceHost.Payment
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentCommand _paymentCommand;


        public PaymentController(IPaymentCommand paymentCommand)
        {
            _paymentCommand = paymentCommand;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PaymentDTO command) => Ok(await _paymentCommand.Handle(command));
    }
}
