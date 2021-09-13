using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DIPatterns
{
    class Program
    {
public interface ICurrencyRate
{
    int GetCurrencyRate(string currency);
}

// PaymentService 
public static Money CalculatePayment(ICurrencyRate currencyRate)
{
    return new Money();
}
        static void Main(string[] args)
        {
            // Использование контекста для передачи данных в другой поток.
            var context = new CustomViewModel();
            var thread = new Thread(o =>
            {
                var localContext = (CustomViewModel)o;
            });
            thread.Start(context);
        }

    }

    internal class CustomViewModel
    {
    }

    internal class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }

    internal class Money
    {
    }
}
