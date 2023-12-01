using System;
using System.Collections.Generic;

namespace CoffeeShop.Model
{
    public partial class Employee
    {
        public Employee()
        {
            Bills = new HashSet<Bill>();
        }

        public int IdEm { get; set; }
        public byte[]? ImageData { get; set; }
        public string? NameEm { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string? PhoneNum { get; set; }
        public string? AddressEm { get; set; }
        public string? Sex { get; set; }
        public string? NameRole { get; set; }
        public string? Username { get; set; }
        public string? Pass { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
