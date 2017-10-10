using System;
using System.Collections.Generic;
using System.Reflection;

namespace Delta.Core.Fody
{
    public interface IConfigurationContext
    {
        IClassConfiguration<T> AppendOrRetrieve<T>() where T : class, new();
        IClassConfiguration this[Type type] { get; }
        ICollection<IClassConfiguration> Content { get; }
    }
    public class ConfigurationContext : IConfigurationContext
    {
        internal readonly IConfigurationContextContent content;
        public IClassConfiguration this[Type type] { get => content[type]; }
        public ConfigurationContext()
        {
            this.content = Factory.GetContent(this);
        }
        public ICollection<IClassConfiguration> Content { get => content.Values; }
        public IClassConfiguration<T> AppendOrRetrieve<T>() where T : class, new()
        {
            Type type = typeof(T);

            if (!content.ContainsKey(type))
                content.Add(type, Factory.GetConfiguration<T>());

            return this[type] as ClassConfiguration<T>;
        }
    }
    public interface IClassConfigurationContext
    {
        IPropertyConfiguration AppendOrRetrieve(IClassConfiguration parent, MemberInfo memberInfo);
        IPropertyConfiguration this[string name] { get; }
        ICollection<IPropertyConfiguration> Content { get; }
        IClassConfiguration Parent { get; }
    }
    public class ConfigurationContextContent : Dictionary<Type, IClassConfiguration>, IConfigurationContextContent
    {
        internal readonly IConfigurationContext parent;
        public ConfigurationContextContent(IConfigurationContext parent)
        {
            this.parent = parent;
        }
        public IConfigurationContext Parent { get => parent; }
    }
    public interface IConfigurationContextContent : IDictionary<Type, IClassConfiguration>
    {
        IConfigurationContext Parent { get; }
    }
    public class ClassConfigurationContext : IClassConfigurationContext
    {
        internal readonly IClassConfiguration parent;
        internal readonly IClassConfigurationContextContent content;
        public IPropertyConfiguration this[string name] { get => content[name]; }
        public ClassConfigurationContext(IClassConfiguration parent)
        {
            this.parent = parent;
            this.content = Factory.GetContent(this);
        }
        public ICollection<IPropertyConfiguration> Content { get => content.Values; }
        public IClassConfiguration Parent { get => parent; }
        public IPropertyConfiguration AppendOrRetrieve(IClassConfiguration parent, MemberInfo memberInfo)
        {
            if (!content.ContainsKey(memberInfo.Name))
                content.Add(memberInfo.Name, Factory.GetConfiguration(parent, memberInfo));

            return this[memberInfo.Name];
        }
        public IPropertyConfiguration Retrieve(string name)
        {
            return content[name];
        }
    }
    public class ClassConfigurationContextContent : Dictionary<string, IPropertyConfiguration>, IClassConfigurationContextContent
    {
        internal readonly IClassConfigurationContext parent;
        public ClassConfigurationContextContent(IClassConfigurationContext parent)
        {
            this.parent = parent;
        }
        public IClassConfigurationContext Parent { get => parent; }
    }
    public interface IClassConfigurationContextContent : IDictionary<string, IPropertyConfiguration>
    {
        IClassConfigurationContext Parent { get; }
    }
}