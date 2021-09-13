using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Framework;
using System.Linq;

namespace DIBasics
{
    [TestFixture]
    public class TestDuplicates
    {
        private IContainer _container;
        [SetUp]
        public void TestSetup()
        {
            var builder = new ContainerBuilder();
            builder
                .RegisterType<SimpleConnectionStringProvider>()
                .WithParameter(new PositionalParameter(0, "cs"))
                .AsImplementedInterfaces()
                .Named<IConnectionStringProvider>("simple");

            builder
                .RegisterType<AppConfigConnectionStringProvider>()
                .AsImplementedInterfaces()
                .Named<IConnectionStringProvider>("appConfig");

            _container = builder.Build();
        }

        [Test]
        public void Test_Resolve_All_Instances()
        {
            //Arrange
            //Act
            var sequence = _container.Resolve<IEnumerable<IConnectionStringProvider>>();
            //Assert
            Assert.That(sequence.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Test_Second_Register_Wins()
        {
            //Arrange
            //Act
            var provider = _container.Resolve<IConnectionStringProvider>();
            //Assert
            Assert.That(provider.GetType(), Is.EqualTo(typeof(AppConfigConnectionStringProvider)));

        }
    }
}