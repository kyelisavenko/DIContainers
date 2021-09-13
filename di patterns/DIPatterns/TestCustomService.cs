using Autofac;
using Autofac.Builder;
using NUnit.Framework;

namespace DIPatterns
{
    interface IDependency
    {
        void DoSomething();
    }

    class Dependency : IDependency
    {
        public void DoSomething()
        {
            throw new System.NotImplementedException();
        }
    }

    class CustomService
    {
        private readonly IDependency _dependency;

        public CustomService(IDependency dependency)
        {
            _dependency = dependency;
        }

        public void DoSomeWork()
        {
            _dependency.DoSomething();
        }
    }

    [TestFixture]
    public class TestCustomService
    {
        [Test]
        public void Test_Simple_Constructor_Injection()
        {
            //Arrange
            var builder = new ContainerBuilder();
            builder.RegisterType<Dependency>().AsImplementedInterfaces();
            builder.RegisterType<CustomService>().AsSelf();

            var container = builder.Build();
            //Act
            var customService = container.Resolve<CustomService>();
            //Assert
            Assert.IsNotNull(customService);
        }
    }
}