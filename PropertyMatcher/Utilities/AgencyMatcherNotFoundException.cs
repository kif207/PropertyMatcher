using System;

namespace DomainPropertyMatcher.Utilities
{
    public class AgencyMatcherNotFoundException : Exception
    {
        public AgencyMatcherNotFoundException()
        {
        }

        public AgencyMatcherNotFoundException(string message)
            : base(message)
        {
        }

        public AgencyMatcherNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
