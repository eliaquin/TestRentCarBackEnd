namespace WeRentCarBackEnd.Dtos
{
    public class VehicleDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal DailyPrice { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfDoors { get; set; }
    }
}
