using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission
{
    internal class Customer
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string City { get; }
        public bool IsVip { get; }
        public Customer(int id, string name, string email, string city, bool isVip)
        {
            Id = id;
            Name = name;
            Email = email;
            City = city;
            IsVip = isVip;
        }
    }
}
