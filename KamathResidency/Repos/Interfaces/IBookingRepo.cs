using System;
using KamathResidency.DTO;
using KamathResidency.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KamathResidency.Repos.Interfaces;

public interface IBookingRepo
{
    Task<List<BookingsDto>> GetAllRoomBookings(DateTime? fromDate, DateTime? toDate);
    Task<Booking> AddBooking(CreateBookingsDto details);
    Task<Booking> UpdateBooking(Guid bId, BookingsDto updatedData);
    Task<Booking> GetBookingDetailsById(Guid BId);


}
