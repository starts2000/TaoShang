using System.Configuration;

namespace Starts2000.Net.Configuration
{
    internal sealed class SessionConfigurationCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "add"; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SessionConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SessionConfigurationElement)element).Key;
        }
    }
}
