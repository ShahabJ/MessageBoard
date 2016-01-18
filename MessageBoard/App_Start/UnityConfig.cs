using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using System.Web.Http;
using MessageBoard.Data;
using MessageBoard.Service;

namespace MessageBoard
{
    public static class UnityConfig
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

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}