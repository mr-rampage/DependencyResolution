using System.Windows;

namespace DependencyResolution
{
    public static class InstanceRequester
    {
        public static T RequestInstance<T>(this IInputElement element)
        {
            var requestInstance = new RequestInstance(typeof(T));
            element.RaiseEvent(requestInstance);
            return (T) requestInstance.Instance;
        }
    }
}