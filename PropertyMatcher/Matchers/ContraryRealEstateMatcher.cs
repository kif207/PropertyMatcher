using System.Linq;
using DomainPropertyMatcher.Interfaces;
using DomainPropertyMatcher.Entities;
using DomainPropertyMatcher.Utilities.Extensions;

namespace DomainPropertyMatcher.Matchers
{
    class ContraryRealEstateMatcher : IPropertyMatcher, IHandlesAgency
    {
        readonly string agencyCode = "CRE";

        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            if (agencyProperty.Name == null || databaseProperty.Name == null)
                return false;

            return
                (agencyProperty.AgencyCode.ToUpper() == this.agencyCode) &&
                (agencyProperty.Name.Reverse().ToUpper() == databaseProperty.Name.ToUpper());
        }

        public bool CanHandle(string AgencyCode)
        {
            return AgencyCode.ToUpper() == agencyCode;
        }
    }
}
