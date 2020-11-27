using System;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DependencyResolution
{
    public static class InstanceProvider
    {
        private static readonly ConditionalWeakTable<IInputElement, IInjector> Injectors =
            new ConditionalWeakTable<IInputElement, IInjector>();

        public static Action ProvideInstance(this IInputElement instanceProvider, in IInjector injector)
        {
            Injectors.Add(instanceProvider, injector);
            var resolver = CreateResolver(injector);
            instanceProvider.AddHandler(RequestInstance.RequestInstanceEvent, resolver);
            return () =>
            {
                Injectors.Remove(instanceProvider);
                instanceProvider.RemoveHandler(RequestInstance.RequestInstanceEvent, resolver);
            };
        }

        private static RequestInstanceEventHandler CreateResolver(IInjector instances)
        {
            return delegate(object sender, RequestInstance e)
            {
                var instance = instances.ResolveInstance(e.InstanceType);
                if (instance == null) return;
                e.Instance = instance;
                e.Handled = true;
            };
        }
    }
}