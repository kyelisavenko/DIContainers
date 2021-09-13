using System;
using System.IO;
using System.Text;
using Autofac;
using NUnit.Framework;

namespace DIBasics
{

    interface ICustomDependency
    {
        void Foo();
    }

    class CustomDependencyImpl : ICustomDependency
    {
        public void Foo()
        {
            throw new System.NotImplementedException();
        }
    }


    [TestFixture]
    public class ContainerBasicsTests
    {
        [Test]
        public void Test_Register_Interface()
        {
            // Arrange
            var builder = new ContainerBuilder();
            // Регистрация CustomDependencyImpl -> Singleton CustomDependencyImpl

            builder.RegisterType<CustomDependencyImpl>().AsSelf().SingleInstance();
            var container = builder.Build();

            // Act
            var dependency1 = container.Resolve<CustomDependencyImpl>();
            var dependency2 = container.Resolve<CustomDependencyImpl>();

            Console.WriteLine(object.ReferenceEquals(dependency1, dependency2));

            // Assert
            Assert.That(ReferenceEquals(dependency1, dependency2), Is.True);
        }

        [Test]
        public void Test_Register_Abstract_Class()
        {
            // Arrange
            var builder = new ContainerBuilder();
            // Регистрация Stream -> MemoryStream
            builder.RegisterType<MemoryStream>().As<Stream>();
            var container = builder.Build();

            // Act
            Stream stream = (Stream)container.Resolve(typeof(Stream));
            // Assert
            Assert.IsNotNull(stream);
            Assert.That(stream.GetType() == typeof(MemoryStream), Is.True);
        }

        [Test]
        public void Test_Register_Concrete_Class()
        {
            //Arrange
            var builder = new ContainerBuilder();
            // Регистрация StringBuilder -> StringBuilder
            builder.RegisterType<StringBuilder>().As<StringBuilder>();
            var container = builder.Build();

            //Act
            var sb1 = container.Resolve<StringBuilder>();
            var sb2 = container.Resolve<StringBuilder>();
            //Assert
            Assert.IsNotNull(sb1);
            Assert.IsNotNull(sb2);
            Assert.That(ReferenceEquals(sb1, sb2), Is.Not.True);
        }

    }
}