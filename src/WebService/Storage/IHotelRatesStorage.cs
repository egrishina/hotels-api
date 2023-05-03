using WebService.Models;

namespace WebService.Storage
{
    public interface IHotelRatesStorage
    {
        Task<List<HotelInfoDto>> FindHotelRatesByFilter(int hotelId, DateTime arrivalDate, CancellationToken cancellationToken);
    }
}
