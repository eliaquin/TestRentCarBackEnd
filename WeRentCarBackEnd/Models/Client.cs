using System.Collections.Generic;

namespace WeRentCarBackEnd.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TypeOfIdId { get; set; }
        public TypeOfId TypeOfId { get; set; }
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public IList<Vehicle> Vehicles { get; set; }
    }
}
