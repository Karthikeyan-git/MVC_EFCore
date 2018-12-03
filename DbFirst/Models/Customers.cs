using System;
using System.Collections.Generic;

namespace DbFirst.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }


        public ICollection<Orders> Orders { get; set; }
    }
}
