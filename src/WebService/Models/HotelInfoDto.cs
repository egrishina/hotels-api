namespace WebService.Models
{
    public class HotelInfoDto
    {
        public HotelDto Hotel { get; set; }

        public List<HotelRateDto> HotelRates { get; set; }
    }
}
