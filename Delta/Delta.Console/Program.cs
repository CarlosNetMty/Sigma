using System;
using Delta.Core;
using sys = System;
using Delta.Core.Observables;
using Delta.Core.Observables.Collections;
using Delta.Core.Observables.Notifications;

namespace Delta.Console
{
    class Program
    {
        class User : ObservableEntity
        {
            public string Name { get; set; }
            public int Age { get; set; }

            DateTime birthday;
            public DateTime Birthday
            {
                get => birthday;
                set => this.HandleProperty(value, out birthday);
            }
            public object NotObservableProperty { get; set; }
            public User() : base()
            {
                Roles = new ObservableEntityCollection<Role>(this);
            }
            public ObservableEntityCollection<Role> Roles { get; set; }
        }
        class Role : ObservableEntity
        {
            readonly string name;
            public string Name { get => name; }

            DateTime propertyValue;
            public DateTime Property {
                get => propertyValue;
                set => this.HandleProperty<DateTime>(value, out propertyValue);
            }
            public Role(string name)
            {
                this.name = name;
            }
        }
        static void Main(string[] args)
        {
            sys.Console.WriteLine("Hello World!");

            //var config = Configuration.RegisterType<User>()
            //    .RegisterProperty((usr) => usr.Name)
            //    .RegisterProperty((usr) => usr.Age);

            //Configuration.ScanTypeForConfiguration<User>();

            var user = new User();
            var role = new Role("User");

            user.ObservablePropertyValueChanged += OnObservablePropertyChanged;
            user.ObservableCollectionChanged += OnObservableCollectionChanged;
            role.ObservablePropertyValueChanged += OnObservablePropertyChanged;

            user.Birthday = DateTime.UtcNow.AddYears(-30);
            user.Roles.Add(role);
            role.Property = DateTime.Now;

            foreach (var item in user.Changes)
                sys.Console.WriteLine(item.Type);

            sys.Console.Read();
        }
        static void OnObservableCollectionChanged(ObservableEntity sender, ObservableCollectionChangedEventArgs e)
        {
            sys.Console.WriteLine($"{e.Action}");
            //sys.Console.WriteLine($"Items");
            //foreach (var item in e.NewItems)
            //    sys.Console.WriteLine($"{item}");
        }
        static void OnObservablePropertyChanged(ObservableEntity sender, ObservablePropertyValueChangedEventArgs e)
        {
            sys.Console.WriteLine($"PropertyName: {e.PropertyName}, Value: {e.Value}");
        }
    }
}