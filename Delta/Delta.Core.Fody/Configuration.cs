using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Delta.Core.Fody
{
    public static class Configuration
    {
        internal static IConfigurationContext context = Factory.GetContext();
        public static IClassConfiguration<T> RegisterType<T>() where T : class, new()
        {
            return context.AppendOrRetrieve<T>();
        }
        public static bool ScanTypeForConfiguration<T>() where T : class, new()
        {
            var typeInfo = typeof(T).GetTypeInfo();

            if (typeInfo.GetCustomAttribute<ClassConfigurationAttribute>() 
                as ClassConfigurationAttribute != null)
            {
                RegisterType<T>().ScanTypeForConfiguration(typeInfo);
                return true;
            }
            return false;
        }
        public static void Validate()
        {
            TryValidate(() => { throw new InvalidOperationException(); });
        }
        public static bool TryValidate(Action onFailPredicate)
        {
            //TODO: append validate process (maybe using specification pattern?)
            bool processResult = true;
            if (!processResult && onFailPredicate != null)
                onFailPredicate();
                
            return processResult;
        }
    }
    public interface IClassConfiguration
    {
        string TypeName { get; }
    }
    public interface IClassConfiguration<T> : IClassConfiguration
    {
        IClassConfiguration<T> RegisterProperty<U>(Expression<Func<T, U>> expr);
        IClassConfiguration<T> ScanTypeForConfiguration(TypeInfo typeInfo);
    }
    public class ClassConfiguration<T> : IClassConfiguration<T>
    {
        internal readonly IClassConfigurationContext context;
        public string TypeName { get => typeof(T).FullName; }
        public ClassConfiguration()
        {
            this.context = Factory.GetContext(this);
        }
        public IClassConfiguration<T> RegisterProperty<U>(Expression<Func<T, U>> expr)
        {
            var member = expr.Body as MemberExpression;
            var unary  = expr.Body as UnaryExpression;
            var memberInfo = (member ?? (unary != null ? unary.Operand as MemberExpression : null)).Member;

            context.AppendOrRetrieve(this, memberInfo);
            return this;
        }
        public IClassConfiguration<T> ScanTypeForConfiguration(TypeInfo typeInfo)
        {
            var properties = typeInfo.GetProperties(
                BindingFlags.CreateInstance |
                BindingFlags.Default        |
                BindingFlags.Instance       |
                BindingFlags.Public
            ).Where((prop) => prop.GetCustomAttribute<PropertyConfigurationAttribute>() != null);

            foreach (var prop in properties)
                context.AppendOrRetrieve(this, prop);
            
            return this;
        }
    }
    public interface IPropertyConfiguration
    {
        string Name { get; }
    }
    public class PropertyConfiguration : IPropertyConfiguration
    {
        internal readonly IClassConfiguration parent;
        internal readonly PropertyInfo info;
        public PropertyConfiguration(IClassConfiguration parent, MemberInfo memberInfo)
        {
            this.parent = parent;
            this.info = memberInfo as PropertyInfo;
        }
        public string Name { get => this.info.Name; }
    }
    [AttributeUsage(AttributeTargets.Class)] public class ClassConfigurationAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Property)] public class PropertyConfigurationAttribute : Attribute { }
}