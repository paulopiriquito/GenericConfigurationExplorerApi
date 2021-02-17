using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using IConfigurationSection = ConfigurationExplorer.Models.DynamicModels.IConfigurationSection;

namespace ConfigurationExplorer.Application.DynamicControllerGenerator.Generics
{
    public class Generic<T> : Controller where T : class, IConfigurationSection, new()
    {
        private readonly T _stored;
        
        public Generic(IConfiguration configuration)
        {
            _stored = configuration.GetSection(typeof(T).Name).Get<T>();
        }
 
        [HttpGet]
        public T Get()
        {
            return _stored;
        }
    }
}