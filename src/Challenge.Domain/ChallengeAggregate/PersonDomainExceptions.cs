using System;

namespace Challenge.Domain.ChallengeAggregate
{
    public class InvalidAgeExceptions : ArgumentException
    {
        public InvalidAgeExceptions(): base("Person cannot be that old.")
        {
        }
    }
}
