using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IoC.Hack.Tests
{
    public interface IRepository
    {
        
    }

    public class ConcreteRepository : IRepository
    {
        
    }

    public interface IService
    {

    }

    public class ConcreteService : IService
    {
        public ConcreteService(IRepository repository)
        {
            
        }
    }

    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void Register()
        {
            var container = new Container();

            container.Register<IRepository>(() => new ConcreteRepository());

            Assert.That(container.Create<IRepository>(), Is.TypeOf<ConcreteRepository>());
            
        }

        [Test]
        public void BindTo()
        {
            var container = new Container();
            container.Bind<IRepository>().To<ConcreteRepository>();

            Assert.That(container.Create<IRepository>(), Is.TypeOf<ConcreteRepository>());

        }
        [Test]
        public void Dependency()
        {
            var container = new Container();
            container.Bind<IRepository>().To<ConcreteRepository>();
            container.Bind<IService>().To<ConcreteService>();

            Assert.That(container.Create<IService>(), Is.TypeOf<ConcreteService>());
        }
    }
}
