using DiscordBotCore.Storage;
using DiscordBotCore.Storage.Implementations;
using System;
using Unity;
using Unity.Lifetime;

namespace DiscordBotCore
{
    public static class Unity
    {
        private static UnityContainer _container;

        public static UnityContainer Container
        {
            get
            {
                if(_container == null)
                {
                    RegisterTypes();
                }
                return _container;
            }
        }

        public static void RegisterTypes()
        {
            _container = new UnityContainer();
            //ContainerControlledLifetimeManager makes sure only one InMemoryStorage will be used for all IDataStorages
            _container.RegisterType<IDataStorage, InMemoryStorage>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ILogger, Logger>(new ContainerControlledLifetimeManager());
            _container.RegisterType<Discord.Connection>(new ContainerControlledLifetimeManager());
        }

        public static T Resolve<T>()
        {
            //Missing 2 parameters that are used in the tutorial, may break it but CompositeResolverOverride seems unaccesable
            return (T)Container.Resolve(typeof(T));
        }
    }
}
