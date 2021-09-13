using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace DIBasics
{
    [TestFixture]
    public class TestJsonConfiguration
    {
        [Test]
        public void Test_JsonConfiguration()
        {
            //Arrange
            var builder = new ContainerBuilder();
            var config = new ConfigurationBuilder();
            config.AddJsonFile("my.json");
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);

            var container = builder.Build();

            //Act
            var provider = container.Resolve<IConnectionStringProvider>();
            //Assert
            Assert.That(provider.GetConnectionString(), Is.EqualTo("cs"));
        }
    }
}