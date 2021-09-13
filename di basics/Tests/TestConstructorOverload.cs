using Autofac;
using Autofac.Core;
using NUnit.Framework;

namespace DIBasics
{
    class Foo
    {
        public Foo(int i)
        {
            CheckMessage = "Instantiated from ctor with parameter";
        }

        public Foo()
        {
            CheckMessage = "Instantiated from parameterless ctor";
        }

        public string CheckMessage { get; private set; }
    }

        [TestFixture]
        public class TestConstructorOverload
        {
            [Test]
            public void Test_Call_Specific_Constructor()
            {
                //Arrange
                var builder = new ContainerBuilder();
                // Регистрируем конструктор Foo(int)
                builder.RegisterType<Foo>().UsingConstructor(typeof(int)).AsSelf();
                var container = builder.Build();
                
                //Act
                var foo = container.Resolve<Foo>(new PositionalParameter(0, 42));
                //Assert
                Assert.That(foo.CheckMessage, Is.EqualTo("Instantiated from ctor with parameter"));
            }

            [Test]
            public void Test_Call_Parameterless_Constructor()
            {
                //Arrange
                var builder = new ContainerBuilder();
                // Регистрируем Foo()
                builder.RegisterType<Foo>().UsingConstructor().AsSelf();
                var container = builder.Build();
                
                //Act
                var foo = container.Resolve<Foo>();

                //Assert
                Assert.That(foo.CheckMessage, Is.EqualTo("Instantiated from parameterless ctor"));
        }
    }
}