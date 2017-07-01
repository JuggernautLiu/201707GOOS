using System;
using GOOS_Sample.Models.ViewModels;
using GOOS_Sample.Models.dataModels;

namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
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