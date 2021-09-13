using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace DIBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SqlRepository>().As<IRepository>();
            builder.RegisterType<SimpleConnectionStringProvider>()
                .WithParameter("connectionString", "Custom Connection String")
                .AsImplementedInterfaces();
            builder.RegisterType<EditPersonViewModel>().AsSelf();
            var container = builder.Build();

            var repository = container.Resolve<EditPersonViewModel>();

        }
    }
}
