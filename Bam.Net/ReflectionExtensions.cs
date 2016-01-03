/*
	Copyright © Bryan Apellanes 2015  
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Bam.Net
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Invoke the specified static method of the 
        /// specified (extension method "current") type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T InvokeStatic<T>(this Type type, string methodName, params object[] args)
        {
            Args.ThrowIfNull(type);
            Args.ThrowIfNull(methodName);
            return (T)type.GetMethod(methodName).Invoke(null, args);
        }

        public static bool HasGenericArguments(this Type type)
        {
            Type[] ignore;
            return type.HasGenericArguments(out ignore);
        }
        public static bool HasGenericArguments(this Type type, out Type[] genericArgumentTypes)
        {
            genericArgumentTypes = type.GetGenericArguments();
            return genericArgumentTypes.Length > 0;
        }

        /// <summary>
        /// Invoke the specified method on the specified instance 
        /// using the specified arguments
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="methodName"></param>
        /// <param name="args"></param>
        public static T Invoke<T>(this object instance, string methodName, params object[] args)
        {
            Args.ThrowIfNull(instance, "instance");
            Args.ThrowIfNull(methodName, "methodName");
            return (T)instance.GetType().GetMethod(methodName).Invoke(instance, args);
        }

        /// <summary>
        /// Invoke the specified method on the specified instance 
        /// using the specified arguments
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="methodName"></param>
        /// <param name="args"></param>
        public static void Invoke(this object instance, string methodName, params object[] args)
        {
            Args.ThrowIfNull(instance, "instance");
            Args.ThrowIfNull(methodName, "methodName");
            instance.GetType().GetMethod(methodName).Invoke(instance, args);
        }

        public static bool HasProperty(this object instance, string propertyName)
        {
            Args.ThrowIfNull(instance, "instance");
            PropertyInfo ignore;
            return HasProperty(instance, propertyName, out ignore);
        }

        public static bool HasProperty(this object instance, string propertyName, out PropertyInfo prop)
        {
            Args.ThrowIfNull(instance, "instance");
            Type type = instance.GetType();
            prop = type.GetProperty(propertyName);
            return prop != null;
        }

        /// <summary>
        /// Subscribe the specified handler to the specified event.  This
        /// is mostly useful when the type is ambiguous because
        /// the underlying implementation uses reflection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static T On<T>(this T instance, string eventName, EventHandler handler)
        {
            return Subscribe<T>(instance, eventName, handler);
        }

        /// <summary>
        /// Subscribe the specified handler from the specified event 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static T Subscribe<T>(this T instance, string eventName, EventHandler handler)
        {
            EventInfo eventInfo = typeof(T).GetEvent(eventName);
            Args.ThrowIfNull(eventInfo, "eventName");
            eventInfo.AddEventHandler(instance, handler);
            return instance;
        }

        /// <summary>
        /// Unsubscribe the specified handler from the specified event 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static T Off<T>(this T instance, string eventName, EventHandler handler)
        {
            return UnSubscribe<T>(instance, eventName, handler);
        }

        /// <summary>
        /// Unsubscribe the specified handler from the specified event 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static T UnSubscribe<T>(this T instance, string eventName, EventHandler handler)
        {
            EventInfo eventInfo = typeof(T).GetEvent(eventName);
            Args.ThrowIfNull(eventInfo, "eventName");
            eventInfo.RemoveEventHandler(eventInfo, handler);
            return instance;
        }

        /// <summary>
        /// Get the property of the current instance with the specified name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="propertyName">The name of the property value to retrieve</param>
        /// <returns></returns>
        public static T Property<T>(this object instance, string propertyName, bool throwIfPropertyNotFound = true)
        {
            object value = Property(instance, propertyName, throwIfPropertyNotFound);
            return value == null ? default(T) : (T)value;
        }

        /// <summary>
        /// Get the property of the current instance with the specified name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object Property(this object instance, string propertyName, bool throwIfPropertyNotFound = true)
        {
            Args.ThrowIfNull(instance, "instance");
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperties().FirstOrDefault(pi => pi.Name.ToLowerInvariant().Equals(propertyName.ToLowerInvariant()));
            if (property == null)
            {
                if (throwIfPropertyNotFound)
                {
                    PropertyNotFound(propertyName, type);
                }
                else
                {
                    return null;
                }
            }
            return property.GetValue(instance);
        }

        /// <summary>
        /// Set the property with the specified name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object Property(this object instance, string propertyName, object value, bool throwIfPropertyNotFound = true)
        {
            Args.ThrowIfNull(instance, "instance");
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty(propertyName);
            if (property == null && throwIfPropertyNotFound)
            {
                PropertyNotFound(propertyName, type);
            }

            if (property != null)
            {
                if (value == DBNull.Value)
                {
                    value = null;
                }
                property.SetValue(instance, value, null);
            }

            return instance;
        }

        public static void EachPropertyInfo(this object instance, Action<PropertyInfo> action)
        {
            Type type = instance.GetType();
            PropertyInfo[] properties = type.GetProperties();
            properties.Each(action);
        }

        public static void EachPropertyInfo(this object instance, Action<PropertyInfo, int> action)
        {
            Type type = instance.GetType();
            PropertyInfo[] properties = type.GetProperties();
            properties.Each(action);
        }

        public static void EachPropertyValue(this object instance, Action<PropertyInfo, object> action)
        {
            instance.EachPropertyInfo(pi =>
            {
                object value = pi.GetValue(instance, null);
                action(pi, value);
            });
        }

        public static void EachPropertyValue(this object instance, Action<PropertyInfo, object, int> action)
        {
            instance.EachPropertyInfo((pi, i) =>
            {
                object value = pi.GetValue(instance, null);
                action(pi, value, i);
            });
        }

        /// <summary>
        /// Return the Type as the string that can be used to 
        /// declare it in code
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToTypeString(this Type type, bool includeNamespace = true)
        {
            StringBuilder output = new StringBuilder();
            if (includeNamespace)
            {
                output.AppendFormat("{0}.", type.Namespace);
            }
            output.Append(type.Name.DropTrailingNonLetters());
            if (type.IsGenericType)
            {
                output.AppendFormat("<{0}>", type.GetGenericArguments().ToDelimited(t => includeNamespace ? "{0}.{1}"._Format(t.Namespace, t.Name): t.Name));
            }
            if (type.IsArray)
            {
                output.Append("[]");
            }
            return output.ToString();
        }

        private static void PropertyNotFound(string propertyName, Type type)
        {
            Args.Throw<InvalidOperationException>("Specified property ({0}) was not found on object of type ({1})", propertyName, type.Name);
        }

    }
}