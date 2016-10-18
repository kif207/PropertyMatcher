using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainPropertyMatcher.Interfaces
{
    public interface IHandlesAgency
    {
        bool CanHandle(string AgencyCode);
    }
}
