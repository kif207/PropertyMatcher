using System.Collections.Generic;
using System.Linq;
using DomainPropertyMatcher.Interfaces;
using DomainPropertyMatcher.Entities;
using DomainPropertyMatcher.Infrastructure;
using DomainPropertyMatcher.Utilities;
using StructureMap;
using StructureMap.Graph;


namespace DomainPropertyMatcher.Matchers
{
    public class PropertyMatcher : IPropertyMatcher
    {
        private PropertyMatcherFactory matcherFactory;

        public PropertyMatcher()
        {
            var container = new Container(new StructureMapRegistry());
            matcherFactory = new PropertyMatcherFactory(container.GetInstance<IEnumerable<IPropertyMatcher>>());
        }

        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            if (agencyProperty == null || databaseProperty == null || agencyProperty.AgencyCode == null)
                return false;

            IPropertyMatcher matcher = matcherFactory.GetPropertyMatcher(agencyProperty.AgencyCode);
            if (matcher == null) throw new AgencyMatcherNotFoundException(string.Format("No matcher found for Agency: '{0}'", agencyProperty.AgencyCode));

            return matcher.IsMatch(agencyProperty, databaseProperty);
        }
    }
}
