using System.Reflection;
using Autofac;
using NUnit.Framework;

namespace DIBasics
{
    [TestFixture]
    public class TestParameterOverrides
    {
        [Test]
        public void Test_Constructor_Argument_Override()
        {
            //Arrange
            var builder = new ContainerBuilder();
            builder.RegisterType<SimpleConnectionStringProvider>()
                .WithParameter("connectionString", "Custom Connection String")
                .AsImplementedInterfaces();
            var container = builder.Build();
            //Act
            var provider = container.Resolve<IConnectionStringProvider>();
            //Assert
            Assert.That(provider.GetConnectionString(), Is.EqualTo("Custom Connection String"));
        }

        [Test]
        public void Test_Resolve_With_Typed_Parameter()
        {
            //Arrange
            var builder = new ContainerBuilder();
            builder.RegisterType<SimpleConnectionStringProvider>()
                .WithParameter(new TypedParameter(typeof(string), "Custom Connection String"))
                .AsImplementedInterfaces();
            var container = builder.Build();
            //Act
            var provider = container.Resolve<IConnectionStringProvider>();
            //Assert
            Assert.That(provider.GetConnectionString(), Is.EqualTo("Custom Connection String"));

        }
        
        [Test]
        public void Test_Position_Parameter_With_Resolve()
        {
            //Arrange
            var builder = new ContainerBuilder();
            builder.RegisterType<SimpleConnectionStringProvider>()
                .AsImplementedInterfaces();
            var container = builder.Build();
            //Act
            var provider = container
                .Resolve<IConnectionStringProvider>(
                new PositionalParameter(0, "Custom Connection String"));
            //Assert
            Assert.That(provider.GetConnectionString(), Is.EqualTo("Custom Connection String"));
        }
    }
}