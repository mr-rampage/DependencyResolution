using System;
using System.Windows;

namespace DependencyResolution
{
    internal delegate void RequestInstanceEventHandler(object sender, RequestInstance e);

    internal sealed class RequestInstance : RoutedEventArgs
    {
        internal static readonly RoutedEvent RequestInstanceEvent = EventManager.RegisterRoutedEvent(
            nameof(RequestInstance), RoutingStrategy.Bubble, typeof(RequestInstanceEventHandler),
            typeof(RequestInstance));

        public RequestInstance(Type instanceType) : base(RequestInstanceEvent)
        {
            InstanceType = instanceType;
        }

        public Type InstanceType { get; }
        public object Instance { get; internal set; }
    }
}