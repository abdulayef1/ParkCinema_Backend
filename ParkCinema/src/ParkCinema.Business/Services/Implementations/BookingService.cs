using ParkCinema.Application.Abstraction.Payment;
using ParkCinema.Application.DTOs.Payment;
using ParkCinema.Business.DTOs.Booking;
using ParkCinema.Business.Services.Interfaces;

namespace ParkCinema.Business.Services.Implementations;

public class BookingService : IBookingService
{

    private readonly IPaymentService _paymentService;

    public BookingService(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }



    public async Task<bool> CreateCharge(BookingDTO bookingDTO, CancellationToken cancellationToken)
    {
               
        CreateCardResource cardResource = new CreateCardResource
        (
             bookingDTO.Name,
             bookingDTO.Number,
             bookingDTO.ExpiryYear,
             bookingDTO.ExpiryMonth,
             bookingDTO.Cvc
        );

        CreateCustomerResource customerResource = new CreateCustomerResource
        (
            bookingDTO.ReceiptEmail,
            bookingDTO.Name,
            cardResource
        );


         var response=await _paymentService.CreateCustomer(customerResource, cancellationToken);

        long totalAmount = 10;
        string filmName = "Avatar";

        CreateChargeResource chargeResource = new CreateChargeResource
            ("USD",
            totalAmount,
            response.CustomerId,
            response.Email,
            filmName
            );

         await _paymentService.CreateCharge(chargeResource, cancellationToken);
        return true;
    }

}
