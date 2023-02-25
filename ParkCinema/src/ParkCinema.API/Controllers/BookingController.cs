using Microsoft.AspNetCore.Mvc;
using ParkCinema.Application.Abstraction.Payment;
using ParkCinema.Application.DTOs.Payment;

namespace ParkCinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public BookingController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("customer")]
        public async Task<ActionResult<CustomerResource>> CreateCustomer([FromBody] CreateCustomerResource resource,
                                                                                    CancellationToken cancellationToken)
        {
            
            
            var response = await _paymentService.CreateCustomer(resource, cancellationToken);
            
            return Ok(response);
        }


        [HttpPost("charge")]
        public async Task<ActionResult<ChargeResource>> CreateCharge([FromBody] CreateChargeResource resource, 
                                                                                CancellationToken cancellationToken)
        {
                
            var response = await _paymentService.CreateCharge(resource, cancellationToken);
            return Ok(response);
        }


    }
}
