using Delta.Core.Observables.Collections;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Delta.Core.Observables.Notifications
{
    public static class ObservableEntityHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        /// <param name="container"></param>
        /// <param name="propertyName"></param>
        public static void HandleProperty<TValue>(this ObservableEntity sender, TValue value, out TValue container,
            [CallerMemberName] string propertyName = "")
        {
            sender.OnPropertyChanging(new PropertyChangingEventArgs(propertyName));
            container = value;
            sender.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            sender.OnObservablePropertyValueChanged(new ObservablePropertyValueChangedEventArgs(propertyName, value));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="callback"></param>
        public static void ObserveAndPersistChanges<T>(this T entity, Action<ObservablePropertyValueChangedEventArgs> callback = null) where T : ObservableEntity
        {
            if (entity == null) throw new ArgumentException();
            entity.ObservablePropertyValueChanged += OnObservablePropertyValueChanged;

            if(callback != null)
                entity.ObservablePropertyValueChanged += (sender, args) => { callback?.Invoke(args); };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void OnObservablePropertyValueChanged
            (ObservableEntity sender, ObservablePropertyValueChangedEventArgs e)
        => sender.Changes.Append(e);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void OnObservableCollectionChanged
            (ObservableEntity sender, ObservableCollectionChangedEventArgs e)
        => sender.Changes.Append(e);
    }
}
