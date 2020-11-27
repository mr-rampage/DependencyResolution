using System.Windows.Controls;

namespace DependencyResolution.Test
{
    internal class FakeInstanceProvider : ContentControl
    {
        public FakeInstanceProvider(IInjector injector)
        {
            this.ProvideInstance(injector);
        }
    }
}