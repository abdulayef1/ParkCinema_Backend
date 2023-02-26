using ParkCinema.Application.DTOs.Payment;
using ParkCinema.Business.DTOs.Booking;

namespace ParkCinema.Business.Services.Interfaces;

public interface IBookingService
{
    Task<bool> CreateCharge(BookingDTO bookingDTO, CancellationToken cancellationToken);
}
