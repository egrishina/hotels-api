using System.Text.Json;
using System.Text.Json.Serialization;
using WebService.Models;
using WebService.Options;

namespace WebService.Storage
{
    public class HotelRatesStorage : IHotelRatesStorage
    {
        public async Task<List<HotelInfoDto>> FindHotelRatesByFilter(
            int hotelId,
            DateTime arrivalDate,
            CancellationToken cancellationToken)
        {
            var allHotelRates = await ReadHotelRatesFromFile();

            var filteredHotelRates = allHotelRates
                .Where(hr => hr.Hotel.HotelId == hotelId)
                .Select(hr => new HotelInfoDto()
                {
                    Hotel = hr.Hotel,
                    HotelRates = hr.HotelRates.Where(r => r.TargetDay.Date == arrivalDate.Date).ToList()
                })
                .ToList();

            return filteredHotelRates;
        }

        private async Task<List<HotelInfoDto>> ReadHotelRatesFromFile()
        {
            var inputPath = Path.GetFullPath(
                Path.Combine(
                    AppContext.BaseDirectory,
                    @"..\..\..\..\..\src\WebService\Resources\task 3 - hotelsrates.json"));

            if (!File.Exists(inputPath))
            {
                throw new FileNotFoundException(inputPath);
            }

            var jsonString = await File.ReadAllTextAsync(inputPath);
            var hotelInfo = DeserializeJsonString(jsonString);
            return hotelInfo;
        }

        private List<HotelInfoDto> DeserializeJsonString(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters =
                {
                    new JsonStringEnumConverter(new UpperCaseNamingPolicy())
                }
            };

            var hotelInfo = JsonSerializer.Deserialize<List<HotelInfoDto>>(jsonString, options);
            return hotelInfo;
        }
    }
}
