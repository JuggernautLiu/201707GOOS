using System;
using GOOS_Sample.Models.ViewModels;
using GOOS_Sample.Models.dataModels;

namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
        private IRepository<Budgets> _budgetRepositoryStub;
        //private IRepository<global::GOOS_SampleTests.DataModelsForIntegrationTest.Budgets> _budgetRepositoryStub1;

        public BudgetService(IRepository<Budgets> budgetRepositoryStub)
        {
            _budgetRepositoryStub = budgetRepositoryStub;
        }

        //public BudgetService(IRepository<global::GOOS_SampleTests.DataModelsForIntegrationTest.Budgets> budgetRepositoryStub1)
        //{
        //    _budgetRepositoryStub1 = budgetRepositoryStub1;
        //}

        public void Create(BudgetAddViewModel model)
        {
            using (var dbcontext = new goosEntitiesForReal())
            {
                var budget = new Budgets() { Amount = model.Amount, YearMonth = model.Month };
                dbcontext.Budgets.Add(budget);
                dbcontext.SaveChanges();
            }
        }
    }
}