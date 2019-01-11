using FlightSearchApi.Contracts;
using System.Net;

namespace FlightSearchApi.Core.Validator
{
    public class SearchByFlightNumberValidator:IValidator
    {
        public void Validate(AchorFlightSearchRequest input)
        {
            var flightNumber = input.FlightNumber as string;

            if (IsValid(flightNumber) == false)
                throw new BadRequestException("BadRequest!");
        }

        private bool IsValid(string flightNumber)
        {
            return string.IsNullOrWhiteSpace(flightNumber) == false
                && flightNumber.Length > 1 && flightNumber.Length < 5;
        }
    }
}
