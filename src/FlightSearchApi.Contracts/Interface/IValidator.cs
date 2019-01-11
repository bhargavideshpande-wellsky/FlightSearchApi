using FlightSearchApi.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FlightSearchApi.Contracts
{
    public interface IValidator
    {
        void Validate(AchorFlightSearchRequest input);
    }
}
