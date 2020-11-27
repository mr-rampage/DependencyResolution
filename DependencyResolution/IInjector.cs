using System;

namespace DependencyResolution
{
    public interface IInjector
    {
        IInjector AddInstance<TInstance>(TInstance dependency);
        object? ResolveInstance(Type key);
    }
}