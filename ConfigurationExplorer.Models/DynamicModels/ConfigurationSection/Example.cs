using ConfigurationExplorer.Models.Attributes;

namespace ConfigurationExplorer.Models.DynamicModels.ConfigurationSection
{
    [DynamicController("api/ExampleConfiguration")]
    public class Example : IConfigurationSection
    {
        public string StringProperty { get; set; }
        public int IntegerProperty { get; set; }
        public bool BooleanProperty { get; set; }
        
        public InnerConfiguration SubConfiguration { get; set; }
        
        public class InnerConfiguration
        {
            public string SubStringProperty { get; set; }
            public int SubIntegerProperty { get; set; }
            public bool SubBooleanProperty { get; set; }
        }
    }
}