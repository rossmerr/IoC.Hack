using System;
using System.Collections.Generic;
using System.Linq;

namespace IoC.Hack
{
    public class ContainerDependency : IContainerDependency
    {
        private readonly IContainer _container;
        private readonly Type _type;

        public ContainerDependency(IContainer container, Type type)
        {
            _container = container;
            _type = type;
        }

        public void To<T>()
        {
            _container.Register(_type, () => CreateInstance(typeof(T)));            
        }

        private object CreateInstance(Type type)
        {
            var args = ResolveConstructorParameters(type);
            return Activator.CreateInstance(type, args.ToArray());
        }

        private static IEnumerable<Type> ConstructorParameters(Type type)
        {
            var constructorInfo = type.GetConstructors().First();
            return constructorInfo.GetParameters().Select(parameter => parameter.ParameterType);
        }

        private IEnumerable<object> ResolveConstructorParameters(Type type)
        {
            var coll = ConstructorParameters(type);

            return coll.Select(o => _container.Create(o));
        }
    }
}