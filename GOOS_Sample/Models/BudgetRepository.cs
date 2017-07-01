using GOOS_Sample.Models.dataModels;

namespace GOOS_Sample.Models
{

    public class BudgetRepository : IRepository<Budgets>
    {
        public void Save(Budgets entity)
        {
            using (var dbcontext = new goosEntitiesForReal())
            {                
                dbcontext.Budgets.Add(entity);
                dbcontext.SaveChanges();
            }
        }
    }
}