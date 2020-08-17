namespace CleanCode.SwitchStatements
{
    public class MonthlyUsage
    {
        public Customer Customer { get; set; }
        public int CallMinutes { get; set; }
        public int SmsCount { get; set; }

        // Moving GenerateStatement method to Customer class so that our switch stamement purely depends on one type and we
        // can easily replace it with Polymorphism
    }
}