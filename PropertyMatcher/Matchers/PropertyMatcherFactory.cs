using System.Collections.Generic;
using System.Linq;
using DomainPropertyMatcher.Interfaces;
using DomainPropertyMatcher.Entities;


namespace DomainPropertyMatcher.Matchers
{
    class PropertyMatcherFactory
    {
        private readonly IEnumerable<IPropertyMatcher> matchers;

        public PropertyMatcherFactory(IEnumerable<IPropertyMatcher> matchers)
        {
            this.matchers = matchers;
        } 

        public IPropertyMatcher GetPropertyMatcher(string AgencyCode)
        {
            try
            {
                return (from m in this.matchers
                        let handles = m as IHandlesAgency
                        where handles != null
                        && handles.CanHandle(AgencyCode)
                        select m).First();
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }

}
