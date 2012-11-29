namespace IoC.Hack
{
    public static class ContainerExtension
    {
        public static IContainerDependency Bind<T>(this IContainer container)
        {
            return new ContainerDependency(container, typeof(T));
        }
    }
}