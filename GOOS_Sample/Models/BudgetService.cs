using System;
using GOOS_Sample.Models.ViewModels;
using GOOS_Sample.Models.dataModels;

namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
        private IRepository<Budgets> _budgetRepository;
        //private IRepository<global::GOOS_SampleTests.DataModelsForIntegrationTest.Budgets> _budgetRepositoryStub1;

        public BudgetService(IRepository<Budgets> budgetRepositoryStub)
        {
            _budgetRepository = budgetRepositoryStub;
        }

        public event EventHandler Created;
        public event EventHandler Updated;

        //public BudgetService(IRepository<global::GOOS_SampleTests.DataModelsForIntegrationTest.Budgets> budgetRepositoryStub1)
        //{
        //    _budgetRepositoryStub1 = budgetRepositoryStub1;
        //}

        public void Create(BudgetAddViewModel model)
        {
            //using (var dbcontext = new goosEntitiesForReal())
            //{
            //    var budget = new Budgets() { Amount = model.Amount, YearMonth = model.Month };
            //    dbcontext.Budgets.Add(budget);
            //    dbcontext.SaveChanges();
            //}

            //var budget = new Budgets() { Amount = model.Amount, YearMonth = model.Month };
            //this._budgetRepository.Save(budget);


            var budget = this._budgetRepository.Read(x => x.YearMonth == model.Month);
            if (budget == null)
            {
                this._budgetRepository.Save(new Budgets() { Amount = model.Amount, YearMonth = model.Month });

                var handler = this.Created;
                handler?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                budget.Amount = model.Amount;
                this._budgetRepository.Save(budget);

                var handler = this.Updated;
                handler?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}