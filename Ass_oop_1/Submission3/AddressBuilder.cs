using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission3
{
    internal class AddressBuilder
    {
        private string _street;
        private string _city;

        public AddressBuilder WithStreet(string street)
        {
            _street = street;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(_street) || string.IsNullOrEmpty(_city))
                throw new InvalidOperationException("Address is incomplete!");
        }
    }
}
