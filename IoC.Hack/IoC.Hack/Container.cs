using System;
using System.Collections.Generic;

namespace IoC.Hack
{
    public class Container : IContainer
    {
        private readonly Dictionary<Type, Func<object>> _typeToCreator = new Dictionary<Type,Func<object>>();

        public void Register<T>(Func<object> creator)
        {
            Register(typeof(T), creator);
        }

        public void Register(Type t, Func<object> creator)
        {
            _typeToCreator.Add(t, creator);
        }

        public T Create<T>()
        {
            return (T) _typeToCreator[typeof (T)].Invoke();
        }

        public object Create(Type t)
        {
            return _typeToCreator[t].Invoke();
        }
    }
}
