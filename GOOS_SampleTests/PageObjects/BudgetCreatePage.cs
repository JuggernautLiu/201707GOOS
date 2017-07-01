using FluentAutomation;
using System;

namespace GOOS_SampleTests.steps
{
    internal class BudgetCreatePage : PageObject<BudgetCreatePage>
    {
        private BudgetCreateSteps budgetCreateSteps;


        public BudgetCreatePage(FluentTest test) : base(test)
        {
            this.Url = $"{PageContext.Domain}/budget/add";
        }


        public BudgetCreatePage Amount(int amount)
        {
            I.Enter(amount.ToString()).In("#amount");
            return this;
        }

        public BudgetCreatePage Month(string yearMonth)
        {

            I.Enter(yearMonth).In("#month");
            return this;
        }

        public void AddBudget()
        {
            I.Click("input[type=\"submit\"]");
        }

        public void ShouldDisplay(string message)
        {
            I.Assert.Text(message).In("#message");
        }
    }

    internal class PageContext
    {
        public static string Domain
        {
            get { return "http://localhost:58527"; }
        }
    }
}