
using System.Collections.Generic;
using StructureMap;
using StructureMap.Graph;
using DomainPropertyMatcher.Interfaces;
using DomainPropertyMatcher.Matchers;

namespace DomainPropertyMatcher.Infrastructure
{
    class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            For<IPropertyMatcher>().Add<ContraryRealEstateMatcher>();
            For<IPropertyMatcher>().Add<LocationRealEstateMatcher>();
            For<IPropertyMatcher>().Add<OnlyTheBestRealEstateMatcher>();

            For<IEnumerable<IPropertyMatcher>>().Use(x => x.GetAllInstances<IPropertyMatcher>());
        }
    }
}
