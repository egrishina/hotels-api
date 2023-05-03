using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebService.Models;
using WebService.Options;

namespace WebService.Tests
{
    public class HotelsControllerTests
    {
        private const string apiHotelsPath = "/hotels";

        private WebApplicationFactory<Startup> _factory = new();
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:7104")
            });
        }

        [Test]
        public async Task FindHotelRatesByFilter_CorrectEndpoint()
        {
            var requestUri = apiHotelsPath + "/7294?arrivalDate=2016-03-15T00:00:00";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task FindHotelRatesByFilter_CorrectOutput()
        {
            var requestUri = apiHotelsPath + "/7294?arrivalDate=2016-03-15T00:00:00";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await _client.SendAsync(request);

            var jsonBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters =
                {
                    new JsonStringEnumConverter(new UpperCaseNamingPolicy())
                }
            };

            var hotelInfo = JsonSerializer.Deserialize<List<HotelInfoDto>>(jsonBody, options);

            response.EnsureSuccessStatusCode();
            Assert.That(hotelInfo!.All(h => h.Hotel.HotelId == 7294));
            Assert.That(hotelInfo!.All(h => h.HotelRates.All(hr => hr.TargetDay.Date == new DateTime(2016, 3, 15))));
        }
    }
}