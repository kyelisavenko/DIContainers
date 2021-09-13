using System;
using Autofac;
using Microsoft.Build.Framework;

namespace Foo
{
    interface IRepository
    {
        BondData GetBondData();
    }

    internal class BondData
    {
    }

    class SqlRepository : IRepository
    {
        public BondData GetBondData()
        {
            throw new NotImplementedException();
        }
    }

// ПЛОХО! Класс облигации использует конкретный класс SqlRepository
class Bond1
{
    private readonly SqlRepository _repository = new SqlRepository();
    public Bond1()
    {
        var bondData = _repository.GetBondData();
    }
}

// ПЛОХО! Класс облигации использует "абстракцию" IRepository
class Bond2
{
    private readonly IRepository _repository;
    public Bond2(IRepository repository)
    {
        _repository = repository;
        var bondData = _repository.GetBondData();
    }
}

// ХОРОШО! Класс облигации ничего не знает о слое доступа к данным!
class Bond3
{
    public Bond3(BondData bondData)
    {}
}


}

namespace DIPatterns.Ddd
{
    

    public class ClassWithServiceLocator
    {
        private readonly ILogger _logger;
        private readonly ISmartTracer _smartTracer;
        private readonly INotifier _notifier;
        private readonly IViewModelBase _viewModelBase;
        private readonly IRepository _repository;
        
        public ClassWithServiceLocator(IContainer container)
        {
            _logger = container.Resolve<ILogger>();
            _smartTracer = container.Resolve<ISmartTracer>();
            _notifier = container.Resolve<INotifier>();
            _viewModelBase = container.Resolve<IViewModelBase>();
            _repository = container.Resolve<IRepository>();
        }
    }

    internal interface IRepository
    {
    }

    internal interface IViewModelBase
    {
    }

    internal interface INotifier
    {
    }

    internal interface ISmartTracer
    {
    }
}