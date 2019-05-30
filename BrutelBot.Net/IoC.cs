using Discord;
using Discord.Commands;
using Discord.WebSocket;
using BrutelBot.Discord;
using BrutelBot.Storage;
using BrutelBot.Storage.Implementations;
using System;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using BrutelBot.Discord.Modules;
using BrutelBot.Music;

namespace BrutelBot
{
    public static class IoC
    {
        private static UnityContainer _container;

        public static UnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    RegisterTypes();
                }
                return _container;
            }
        }

        public static void RegisterTypes()
        {
            //Creating a unitycontainer to register singletons and factories
            _container = new UnityContainer();

            //SINGLETONS
            //Whenever an interface is needed unity uses the here defined implementation
            _container.RegisterSingleton<IDataStorage, JsonStorage>();
            _container.RegisterSingleton<ILogger, Logger>();
            //Injecting objects into the constructor of the registered types
            _container.RegisterSingleton<DiscordSocketClient>(new InjectionConstructor(typeof(DiscordSocketConfig)));
            _container.RegisterSingleton<CommandService>(new InjectionConstructor(typeof(CommandServiceConfig)));
            //Registering these types as singletons so there will always only be one
            _container.RegisterSingleton<Connection>();
            _container.RegisterSingleton<CommandHandler>();

            //FACTORIES
            //Creating an object with an factory to be used when needed
            _container.RegisterFactory<DiscordSocketConfig>(x => SocketConfig.GetDefault());
            _container.RegisterFactory<MusicModule>(x => _container.Resolve<MusicService>());

        }

        public static T Resolve<T>()
        {
            //Missing 2 parameters that are used in the tutorial, may break it but CompositeResolverOverride seems unaccesable
            return (T)Container.Resolve(typeof(T));
        }
    }
}

