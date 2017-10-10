using System;
using System.Collections.Generic;
using System.Reflection;

namespace Delta.Core.Fody
{
    public static class Factory
    {
        public static IConfigurationContext GetContext()
        {
            return new ConfigurationContext();
        }
        public static IClassConfigurationContext GetContext(IClassConfiguration parent)
        {
            return new ClassConfigurationContext(parent);
        }
        public static IConfigurationContextContent GetContent(IConfigurationContext parent)
        {
            return new ConfigurationContextContent(parent);
        }
        public static IClassConfigurationContextContent GetContent(IClassConfigurationContext parent)
        {
            return new ClassConfigurationContextContent(parent);
        }
        public static IClassConfiguration GetConfiguration<T>() where T : class, new()
        {
            //Parent of class configuration would be root (static) configuration class
            return new ClassConfiguration<T>();
        }
        public static IPropertyConfiguration GetConfiguration(IClassConfiguration classConfig, MemberInfo memberInfo)
        {
            return new PropertyConfiguration(classConfig, memberInfo);
        }
    }
}
