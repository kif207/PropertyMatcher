using DomainPropertyMatcher.Entities;

namespace DomainPropertyMatcher.Interfaces
{
    public interface IPropertyMatcher
    {
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }

}
