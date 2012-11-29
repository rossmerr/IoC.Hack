using System;

namespace IoC.Hack
{
    public interface IContainer
    {
        void Register<T>(Func<object> creator);
        void Register(Type t, Func<object> creator);
        T Create<T>();
        object Create(Type t);
    }
}