using IAS.Domain.Core2.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventware.Domain.Core2.Value_Objects
{
    public class Location
    {
        internal Location(string addressOne, string addressTwo, string city, EBrazilianStates state, string zipCode)
        {
            AddressOne = addressOne;
            AddressTwo = addressTwo;
            City = city;
            this.State = state;
            ZipCode = zipCode;
        }


        public string AddressOne { get; protected set; }

        public string AddressTwo { get; protected set; }

        public string City { get; protected set; }

        public EBrazilianStates State { get; protected set; }

        public string ZipCode { get; protected set; }
    }
}
