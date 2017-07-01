using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOOS_Sample.Models;
using NSubstitute;
using GOOS_Sample.Models.ViewModels;
using GOOS_Sample.Models.dataModels;

namespace GOOS_SampleTests.Models
{
    /// <summary>
    /// BudgetServiceTests 的摘要說明
    /// </summary>
    [TestClass]
    public class BudgetServiceTests
    {
        public BudgetServiceTests()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///取得或設定提供目前測試回合
        ///相關資訊與功能的測試內容。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 其他測試屬性
        //
        // 您可以使用下列其他屬性撰寫測試: 
        //
        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        private BudgetService _budgetService;
        private IRepository<Budgets> _budgetRepositoryStub = Substitute.For<IRepository<Budgets>>();
        [TestMethod()]
        public void CreateTest_should_invoke_repository_one_time()
        {
            this._budgetService = new BudgetService(_budgetRepositoryStub);
            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };
            this._budgetService.Create(model);
            _budgetRepositoryStub.Received()
                .Save(Arg.Is<Budgets>(x => x.Amount == 2000 && x.YearMonth == "2017-02"));
        }
    }
}
