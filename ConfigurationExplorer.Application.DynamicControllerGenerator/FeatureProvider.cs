using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ConfigurationExplorer.Application.DynamicControllerGenerator.Generics;
using ConfigurationExplorer.Models.Attributes;
using ConfigurationExplorer.Models.DynamicModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace ConfigurationExplorer.Application.DynamicControllerGenerator
{
    public class FeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(IConfigurationSection).Assembly;
            var candidates = currentAssembly.GetExportedTypes().Where(x => 
                x.GetCustomAttributes<DynamicControllerAttribute>().Any());
            
            foreach (var candidate in candidates)
            {
                feature.Controllers.Add(
                    typeof(Generic<>).MakeGenericType(candidate).GetTypeInfo()
                );
            }
        }
    }
}