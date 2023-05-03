using System.Text.Json;

namespace WebService.Options
{
    public class UpperCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToUpper();
    }
}
