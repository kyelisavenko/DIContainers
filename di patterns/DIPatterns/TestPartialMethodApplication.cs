using System;
using Autofac;
using NUnit.Framework;

namespace DIPatterns
{

    // Задает "стратегию" форматирования отчета
    interface IReportFormatter
    { 
        string GetFormatString();
    }

    class DefaultReportFormatter : IReportFormatter
    {
        public string GetFormatString()
        {
            return "$1";
        }
    }

    class ReportService
    {
        // ReportService
        public static string CreateReport(IReportFormatter reportFormatter, double data)
        {
            return default(string);
        }
    }

    [TestFixture]
    public class TestPartialMethodApplication
    {
        [Test]
        public void Test_Partial_Application()
        {
            //Arrange
            var builder = new ContainerBuilder();
            builder.RegisterType<DefaultReportFormatter>()
                .AsImplementedInterfaces();

            var container = builder.Build();
            
            Func<IReportFormatter, double, string> createReportWithFormatter = 
                ReportService.CreateReport;
            
            Func<double, string> createReport =
                d => createReportWithFormatter(container.Resolve<IReportFormatter>(), d);

            //Act
            // Теперь можем использовать createReport так:
            string report = createReport(42);
            //Assert
            Assert.That(report, Is.EqualTo(default(string)));
        }
    }
}