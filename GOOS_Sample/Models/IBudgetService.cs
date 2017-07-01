using GOOS_Sample.Models.ViewModels;
using System;

namespace GOOS_Sample.Models
{
    public interface IBudgetService
    {

        event EventHandler Created;
        event EventHandler Updated;

        void Create(BudgetAddViewModel budgetAddViewModel);
    }
}