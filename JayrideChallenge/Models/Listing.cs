namespace JayrideChallenge.Models
{
    public class Listing
    {
        public double TotalPrice { get; set; }
        public string Name { get; set; }
        public double PricePerPassenger { get; set; }

        public VehicleType VehicleType { get; set; }
    }

    public class VehicleType    
    {
        public string Name { get; set; }
        public double MaxPassengers { get; set; }
    }
}
