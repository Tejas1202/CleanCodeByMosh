namespace CleanCode.SwitchStatements
{
    #region Customer Class before Refactoring
    //public class Customer
    //{
    //    public CustomerType Type { get; set; }
    //}
    #endregion

    #region Refactored Code
    public abstract class Customer
    {
        public abstract MonthlyStatement GenerateStatement(MonthlyUsage monthlyUsage);
    }

    public class PayAsYouGoCustomer : Customer
    {
        public override MonthlyStatement GenerateStatement(MonthlyUsage monthlyUsage)
        {
            var statement = new MonthlyStatement
            {
                CallCost = 0.12f * monthlyUsage.CallMinutes,
                SmsCost = 0.12f * monthlyUsage.SmsCount
            };
            statement.TotalCost = statement.CallCost + statement.SmsCost;

            return statement;
        }
    }

    public class UnlimitedCustomer : Customer
    {
        public override MonthlyStatement GenerateStatement(MonthlyUsage monthlyUsage)
        {
            var statement = new MonthlyStatement();
            statement.TotalCost = 54.90f;

            return statement;
        }
    }
    #endregion

    public enum CustomerType
    {
        PayAsYouGo = 1,
        Unlimited
    }
}
