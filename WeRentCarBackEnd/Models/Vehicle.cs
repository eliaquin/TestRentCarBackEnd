using System;
using System.Collections.Generic;

namespace WeRentCarBackEnd.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string ImageName { get; set; }
        public DateTime? LastRented { get; set; }
        public DateTime? LastReturned { get; set; }
        public decimal DailyPrice { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfDoors { get; set; }
        public IList<VehicleNote> Notes { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}
