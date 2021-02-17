using System;

namespace ConfigurationExplorer.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DynamicControllerAttribute : Attribute
    {
        public DynamicControllerAttribute(string route)
        {
            Route = route;
        }

        public string Route { get; set; }
    }
}