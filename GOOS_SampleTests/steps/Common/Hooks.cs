using FluentAutomation;
using GOOS_Sample.Models;
using GOOS_SampleTests.DataModelsForIntegrationTest;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.steps.Common
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeTestRun()]
        public static void RegisterDIContainer()
        {
            UnityContainer = new UnityContainer();
            UnityContainer.RegisterType<IBudgetService, BudgetService>();
            //UnityContainer.RegisterType<IRepository<Budgets>, BudgetRepository>();
        }
        public static IUnityContainer UnityContainer
        {
            get;
            set;
        }

        [BeforeScenario]
        [Scope(Tag = "web")]
        public void BeforeScenario()
        {
             SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }


        [BeforeScenario()]
        [AfterScenario()]
        public void BeforeScenarioCleanTable()
        {
            CleanTableByTags();
        }


        [AfterFeature()]
        public static void AfterFeatureCleanTable()
        {
            CleanTableByTags();
        }


        private static void CleanTableByTags()
        {
            var tags = ScenarioContext.Current.ScenarioInfo.Tags
                .Where(x => x.StartsWith("Clean"))
                .Select(x => x.Replace("Clean", ""));

            if (!tags.Any())
            {
                return;
            }

            using (var dbcontext = new goosEntities())
            {
                foreach (var tag in tags)
                {
                    dbcontext.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{tag}]");
                }

                dbcontext.SaveChangesAsync();
            }
        }

    }
}
