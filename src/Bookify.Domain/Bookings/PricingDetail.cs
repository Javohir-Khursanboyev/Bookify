using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public record PricingDetail(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);