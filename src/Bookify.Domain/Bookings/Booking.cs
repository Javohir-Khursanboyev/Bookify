using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;

namespace Bookify.Domain.Bookings;

public sealed class Booking : Entity
{
    public Booking(
        Guid id,
        Guid appartmentId,
        Guid userId,
        DateRange duration,
        Money priceForPeriod,
        Money cleaningFee,
        Money amentiesUpCharge,
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUtc) 
        : base(id)
    {
        ApartmentId = appartmentId;
        UserId = userId;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        CleaningFee = cleaningFee;
        AmenitiesUpCharge = amentiesUpCharge;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUtc = createdOnUtc;
    }

    public Guid ApartmentId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange Duration { get; private set; }
    public Money PriceForPeriod { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateTime? RejectedOnUtc { get; private set; }
    public DateTime? CancelledOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
}