using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using GOOS_Sample.Models;
using GOOS_Sample.Models.dataModels;


namespace GOOS_Sample
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IBudgetService, BudgetService>();
            container.RegisterType<IRepository<Budgets>, BudgetRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}