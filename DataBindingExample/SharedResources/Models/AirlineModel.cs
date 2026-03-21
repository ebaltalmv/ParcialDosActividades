using System.Collections.ObjectModel;

namespace DataBindingExample.Models
{
    public class AirlineModel
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public static ObservableCollection<AirlineModel> Airlines { get; set; } = [
            new AirlineModel { Code = "AA", Name = "American Airlines", Country = "United States", Phone = "+1 800-433-7300" },
            new AirlineModel { Code = "BA", Name = "British Airways", Country = "United Kingdom", Phone = "+44 20 8738 5050" },
            new AirlineModel { Code = "DL", Name = "Delta Air Lines", Country = "United States", Phone = "+1 800-221-1212" },
            new AirlineModel { Code = "AF", Name = "Air France", Country = "France", Phone = "+33 9 69 39 36 54" },
            new AirlineModel { Code = "LH", Name = "Lufthansa", Country = "Germany", Phone = "+49 69 86 799 799" }
            ];
    }
}
