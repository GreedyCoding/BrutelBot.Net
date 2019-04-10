using Discord.Commands;
using Discord.WebSocket;
using DiscordBotCore.Discord;
using DiscordBotCore.Storage;
using DiscordBotCore.Storage.Implementations;
using System;
using Unity;
using Unity.Injection;
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
            _container.RegisterSingleton<IDataStorage, JsonStorage>();
            _container.RegisterSingleton<ILogger, Logger>();
            //Using a factory to get a SocketConfig to use as DiscordSocketConfig, InjectionFactory is going to be deprecated
            //_container.RegisterFactory<DiscordSocketClient>(typeof(DiscordSocketConfig), "DefaultConfig", i => SocketConfig.GetDefault(), null);
            _container.RegisterType<DiscordSocketConfig>(new InjectionFactory(i => SocketConfig.GetDefault()));
            _container.RegisterSingleton<DiscordSocketClient>(new InjectionConstructor(typeof(DiscordSocketConfig)));
            _container.RegisterSingleton<CommandService>(new InjectionConstructor(typeof(CommandServiceConfig)));
            _container.RegisterSingleton<Discord.Connection>();
        }

        public static T Resolve<T>()
        {
            //Missing 2 parameters that are used in the tutorial, may break it but CompositeResolverOverride seems unaccesable
            return (T)Container.Resolve(typeof(T));
        }
    }
}
