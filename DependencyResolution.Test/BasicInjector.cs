using System;
using System.Collections.Generic;

namespace DependencyResolution.Test
{
    public class BasicInjector : IInjector
    {
        private readonly IDictionary<Type, object> _instances = new Dictionary<Type, object>();

        public IInjector AddInstance<TInstance>(TInstance dependency)
        {
            if (dependency != null)
                _instances.Add(typeof(TInstance), dependency);
            return this;
        }

        public object? ResolveInstance(Type key)
        {
            return _instances.ContainsKey(key) ? _instances[key] : null;
        }
    }
}