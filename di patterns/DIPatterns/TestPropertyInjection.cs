using Autofac;
using NUnit.Framework;

namespace DIPatterns.PropertyInjection
{
    // Dependency.dll
    public interface IDependency
    { }

    // CustomService.dll (!)
    internal class DefaultDependency : IDependency
    { }

    internal class NonDefaultDependency : IDependency
    {}

    // CustomService.dll
    public class CustomService
    {
        public CustomService()
        {
            Dependency = new DefaultDependency();
        }

        public IDependency Dependency { get; set; }
    }

    [TestFixture]
    public class TestPropertyInjection
    {
        [Test]
        public void Test_PropertyInjectionSetter()
        {
            // Arrange
            var builder = new ContainerBuilder();
            builder.RegisterType<NonDefaultDependency>().AsImplementedInterfaces();
            builder
                .RegisterType<CustomService>()
                .AsSelf()
                .OnActivated(args => args.Instance.Dependency = args.Context.Resolve<IDependency>());

            // Act
            var container = builder.Build();
            var customService = container.Resolve<CustomService>();
            
            // Assert
            Assert.IsInstanceOf<NonDefaultDependency>(customService.Dependency);
        }
    }
}