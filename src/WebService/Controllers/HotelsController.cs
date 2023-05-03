using Microsoft.AspNetCore.Mvc;
using WebService.Models;
using WebService.Storage;

namespace WebService.Controllers
{
    [Controller]
    [Route("hotels")]
    public class HotelsController : Controller
    {
        private readonly IHotelRatesStorage _storage;

        public HotelsController(IHotelRatesStorage storage)
        {
            _storage = storage;
        }

        // https://localhost:7104/hotels/7294?arrivalDate=2016-03-15T00:00:00
        [HttpGet]
        [Route("{hotelId}")]
        public async Task<ActionResult<List<HotelInfoDto>>> FindHotelRatesByFilter(
            int hotelId,
            [FromQuery] DateTime arrivalDate,
            CancellationToken cancellationToken)
        {
            var hotelRates = await _storage.FindHotelRatesByFilter(hotelId, arrivalDate, cancellationToken);
            return new ActionResult<List<HotelInfoDto>>(hotelRates);
        }
    }
}
