using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;
using Autofac;
using NUnit.Framework;
using System.Linq;

namespace DIBasics
{
    interface IDependency
    {}

    class DependencyImpl1 : IDependency
    {}

    class DependencyImpl2 : IDependency
    {}
    
    [TestFixture]
    public class TestAutoRegistration
    {
        [Test]
        public void Test_Register_All_IConnectionStringProvider()
        {
            //Arrange
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(IDependency).Assembly)
                .Where(t => t.Name.StartsWith("DependencyImpl"))
                .AsImplementedInterfaces();

            var container = builder.Build();
            //Act
            var connStringProviders = container.Resolve<IEnumerable<IDependency>>();
            //Assert
            Assert.That(connStringProviders.Count(), Is.EqualTo(2));
        }
    }
}