using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyResolution.Test
{
    [TestClass]
    public class TestDependencyResolution
    {
        [TestMethod]
        public void TestProvidesInstance()
        {
            var service = new FakeService();
            var child = new ContentControl();

            var fixture = new FakeInstanceProvider(new BasicInjector()
                .AddInstance(service)
            ) {Content = child};

            var actual = child.RequestInstance<FakeService>();
            Assert.AreSame(service, actual);
        }

        [TestMethod]
        public void TestBubblesRequests()
        {
            var service1 = new FakeService();
            var service2 = new FakeService2();

            var grandChild = new ContentControl();
            var child = new ContentControl {Content = grandChild};
            var parent = new FakeInstanceProvider(new BasicInjector().AddInstance(service1)) {Content = child};
            var fixture = new FakeInstanceProvider(new BasicInjector().AddInstance(service2)) {Content = parent};

            var actual = grandChild.RequestInstance<FakeService2>();
            Assert.AreSame(service2, actual);
        }

        [TestMethod]
        public void TestNoInstance()
        {
            var child = new ContentControl();
            var fixture = new FakeInstanceProvider(new BasicInjector()) {Content = child};
            var actual = child.RequestInstance<FakeService>();
            Assert.IsNull(actual);
        }

        private class FakeService
        {
        }

        private class FakeService2
        {
        }
    }
}