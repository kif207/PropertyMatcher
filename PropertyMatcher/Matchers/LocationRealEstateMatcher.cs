using DomainPropertyMatcher.Interfaces;
using DomainPropertyMatcher.Entities;
using DomainPropertyMatcher.Utilities.Extensions;

namespace DomainPropertyMatcher.Matchers
{
    class LocationRealEstateMatcher : IPropertyMatcher, IHandlesAgency
    {
        readonly string agencyCode = "LRE";
        readonly double allowedDistance = 200; // meters 

        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            if (databaseProperty.AgencyCode == null)
                return false;

            return 
                (agencyProperty.AgencyCode.ToUpper() == this.agencyCode) &&
                (agencyProperty.AgencyCode.ToUpper() == databaseProperty.AgencyCode.ToUpper()) &&
                (agencyProperty.DistanceTo(databaseProperty) <= this.allowedDistance);
        }

        public bool CanHandle(string AgencyCode)
        {
            return AgencyCode.ToUpper() == agencyCode;
        }
    }
}
