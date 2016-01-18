using MessageBoard.Data;
using MessageBoard.Service;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace MessageBoard
{
    public static class aUnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<MessageBoardContext, MessageBoardContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMessageBoardRepository, MessageBoardRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMailService, MockMailService>(new ContainerControlledLifetimeManager());
            container.RegisterType<MessageBoardContext, MessageBoardContext>(new ContainerControlledLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);


            
        }
    }
}