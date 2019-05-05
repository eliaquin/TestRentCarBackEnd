using System;

namespace WeRentCarBackEnd.Models
{
    public class VehicleNote
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
    }
}
