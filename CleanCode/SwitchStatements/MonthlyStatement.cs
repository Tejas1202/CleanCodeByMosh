namespace CleanCode.SwitchStatements
{
    public class MonthlyStatement
    {
        public float CallCost { get; set; }
        public float SmsCost { get; set; }
        public float TotalCost { get; set; }

        #region Code Smell
        // This method is too much dependent on MonthlyUsage class. According to Encapsulation principle, this method should
        // really belong to the MonthlyUsage class instead of any other class
        //public void Generate(MonthlyUsage usage)
        //{
        //    switch (usage.Customer.Type)
        //    {
        //        case CustomerType.PayAsYouGo:
        //            CallCost = 0.12f * usage.CallMinutes;
        //            SmsCost = 0.12f * usage.SmsCount;
        //            TotalCost = CallCost + SmsCost;
        //            break;

        //        case CustomerType.Unlimited:
        //            TotalCost = 54.90f;
        //            break;

        //        default:
        //            throw new NotSupportedException("The current customer type is not supported");
        //    }
        //}
        #endregion
    }
}