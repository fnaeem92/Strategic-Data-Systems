using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DeveloperSample.Container
{
    public class Container
    {
        // Dictionary to hold bindings of interfaces to concrete types
        private readonly Dictionary<Type, Type> _bindings = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (interfaceType == null || implementationType == null)
                throw new ArgumentNullException("Both interface and implementation types must be provided.");

            if (!interfaceType.IsInterface)
                throw new ArgumentException("The interfaceType parameter must be an interface.");

            _bindings[interfaceType] = implementationType;
        }

        // Get an instance of the requested type, resolving constructor dependencies
        public T Get<T>()
        {
            return (T)Get(typeof(T)); 
        }

        // Get an instance of the requested type
        public object Get(Type type)
        {
            if (!_bindings.ContainsKey(type))
                throw new InvalidOperationException($"No binding found for {type}");

            var implementationType = _bindings[type];

            var constructor = implementationType.GetConstructors().FirstOrDefault();

            if (constructor == null)
                throw new InvalidOperationException("No valid constructor found for " + implementationType);

            var parameters = constructor.GetParameters();

            var parameterInstances = parameters.Select(p => Get(p.ParameterType)).ToArray();

            return constructor.Invoke(parameterInstances);
        }
    }
}