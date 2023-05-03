using System.Text.Json.Serialization;

namespace WebService.Models
{
    public class HotelRateDto
    {
        public int Adults { get; set; }

        [JsonPropertyName("los")]
        public int StayLength { get; set; }

        public Price Price { get; set; }

        public string RateDescription { get; set; }

        [JsonPropertyName("rateID")]
        public string RateId { get; set; }

        public string RateName { get; set; }

        public List<RateTag> RateTags { get; set; }

        public DateTime TargetDay { get; set; }
    }
}
