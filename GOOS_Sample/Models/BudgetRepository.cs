using System;
using GOOS_Sample.Models.dataModels;
using System.Linq;

namespace GOOS_Sample.Models
{

    public class BudgetRepository : IRepository<Budgets>
    {
       
        public void Save(Budgets entity)
        {
            //using (var dbcontext = new goosEntitiesForReal())
            //{                
            //    dbcontext.Budgets.Add(entity);
            //    dbcontext.SaveChanges();
            //}


            using (var dbcontext = new goosEntitiesForReal())
            {
                var budgetFromDb = dbcontext.Budgets.FirstOrDefault(x => x.YearMonth == entity.YearMonth);

                if (budgetFromDb == null)
                {
                    dbcontext.Budgets.Add(entity);
                }
                else
                {
                    budgetFromDb.Amount = entity.Amount;
                }

                dbcontext.SaveChanges();
            }
        }


        public Budgets Read(Func<Budgets, bool> predicate)
        {
            using (var dbcontext = new goosEntitiesForReal())
            {
                var firstBudget = dbcontext.Budgets.FirstOrDefault(predicate);
                return firstBudget;
            }
        }
    }
}