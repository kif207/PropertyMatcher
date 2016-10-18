using System;
using DomainPropertyMatcher.Entities;
using System.Device.Location;

namespace DomainPropertyMatcher.Utilities.Extensions
{
    static class PropertyExtentions
    {
        public static double DistanceTo(this Property baseProperty, Property targetProperty)
        {
            var baseCoord = new GeoCoordinate(Convert.ToDouble(baseProperty.Latitude), Convert.ToDouble(baseProperty.Longitude));
            var targetCoord = new GeoCoordinate(Convert.ToDouble(targetProperty.Latitude), Convert.ToDouble(targetProperty.Longitude));

            return baseCoord.GetDistanceTo(targetCoord);
        }    
    }
}
