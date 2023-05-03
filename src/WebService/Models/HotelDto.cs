using System.Text.Json.Serialization;

namespace WebService.Models
{
    public class HotelDto
    {
        [JsonPropertyName("hotelID")]
        public int HotelId { get; set; }

        public int Classification { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("reviewscore")]
        public double ReviewScore { get; set; }
    }
}
