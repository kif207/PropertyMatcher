using DomainPropertyMatcher.Interfaces;
using DomainPropertyMatcher.Entities;
using DomainPropertyMatcher.Utilities.Extensions;

namespace DomainPropertyMatcher.Matchers
{
    class OnlyTheBestRealEstateMatcher : IPropertyMatcher, IHandlesAgency
    {
        readonly string agencyCode = "OTBRE";

        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            if (agencyProperty.Name == null || agencyProperty.Address == null || databaseProperty.Name == null || databaseProperty.Address == null)
                return false;

            return 
                (agencyProperty.AgencyCode.ToUpper() == this.agencyCode) &&
                (agencyProperty.Name.RemovePunctuations().ToUpper() == databaseProperty.Name.RemovePunctuations().ToUpper()) &&
                (agencyProperty.Address.RemovePunctuations().ToUpper() == databaseProperty.Address.RemovePunctuations().ToUpper());
        }

        public bool CanHandle(string AgencyCode)
        {
            return AgencyCode.ToUpper() == agencyCode;
        }
    }
}
