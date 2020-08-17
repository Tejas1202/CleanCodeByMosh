using CleanCode.SwitchStatements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanCode.UnitTests.SwitchStatements
{
    [TestClass]
    public class MonthlyStatementTests
    {
        #region Default test cases for Poor code
        //[TestMethod]
        //public void PayAsYouGoCustomer_IsChargedBasedOnTheSumOfCostOfCallAndSms()
        //{
        //    var customer = new Customer { Type = CustomerType.PayAsYouGo };
        //    var usage = new MonthlyUsage { CallMinutes = 100, SmsCount = 100, Customer = customer };

        //    var statement = new MonthlyStatement();
        //    statement.Generate(usage);

        //    Assert.AreEqual(12.0f, statement.CallCost);
        //    Assert.AreEqual(12.0f, statement.SmsCost);
        //    Assert.AreEqual(24.0f, statement.TotalCost);
        //}

        //[TestMethod]
        //public void UnlimitedCustomer_IsChargedAFlatRatePerMonth()
        //{
        //    var customer = new Customer { Type = CustomerType.Unlimited };
        //    var usage = new MonthlyUsage { CallMinutes = 100, SmsCount = 100, Customer = customer };
        //    var statement = new MonthlyStatement();
        //    statement.Generate(usage);

        //    Assert.AreEqual(0, statement.CallCost);
        //    Assert.AreEqual(0, statement.SmsCost);
        //    Assert.AreEqual(54.90f, statement.TotalCost);
        //}
        #endregion

        [TestMethod]
        public void PayAsYouGoCustomer_IsChargedBasedOnTheSumOfCostOfCallAndSms()
        {
            //var customer = new Customer { Type = CustomerType.PayAsYouGo };
            var customer = new PayAsYouGoCustomer();
            var usage = new MonthlyUsage { CallMinutes = 100, SmsCount = 100, Customer = customer };

            var statement = customer.GenerateStatement(usage);

            Assert.AreEqual(12.0f, statement.CallCost);
            Assert.AreEqual(12.0f, statement.SmsCost);
            Assert.AreEqual(24.0f, statement.TotalCost);
        }

        [TestMethod]
        public void UnlimitedCustomer_IsChargedAFlatRatePerMonth()
        {
            var customer = new UnlimitedCustomer();
            var usage = new MonthlyUsage { CallMinutes = 100, SmsCount = 100, Customer = customer };

            var statement = customer.GenerateStatement(usage);

            Assert.AreEqual(0, statement.CallCost);
            Assert.AreEqual(0, statement.SmsCost);
            Assert.AreEqual(54.90f, statement.TotalCost);
        }
    }
}