using System;

namespace CleanCode.NestedConditionals
{
    public class Customer
    {
        public int LoyaltyPoints { get; set; }

        // IsGoldCustomer should be a part of this class instead of a private method in Reservation class
        public bool IsGoldCustomer => LoyaltyPoints > 100;
    }

    public class Reservation
    {
        #region Supporting Code
        public DateTime From { get; set; }
        public Customer Customer { get; set; }
        public bool IsCanceled { get; set; }

        public Reservation(Customer customer, DateTime dateTime)
        {
            From = dateTime;
            Customer = customer;
        }
        #endregion

        #region Code Smell
        //public void Cancel()
        //{
        //    // Gold customers can cancel up to 24 hours before
        //    if (Customer.LoyaltyPoints > 100)
        //    {
        //        // If reservation already started throw exception
        //        if (DateTime.Now > From)
        //        {
        //            throw new InvalidOperationException("It's too late to cancel.");
        //        }
        //        if ((From - DateTime.Now).TotalHours < 24)
        //        {
        //            throw new InvalidOperationException("It's too late to cancel.");
        //        }
        //        IsCanceled = true;
        //    }
        //    else
        //    {
        //        // Regular customers can cancel up to 48 hours before

        //        // If reservation already started throw exception
        //        if (DateTime.Now > From)
        //        {
        //            throw new InvalidOperationException("It's too late to cancel.");
        //        }
        //        if ((From - DateTime.Now).TotalHours < 48)
        //        {
        //            throw new InvalidOperationException("It's too late to cancel.");
        //        }
        //        IsCanceled = true;
        //    }
        //}
        #endregion

        #region Refactored Code
        // Extracting methods and combining them whenever possible
        public void Cancel()
        {
            // If reservation already started throw exception
            if (IsCancellationPeriodOver())
                throw new InvalidOperationException("It's too late to cancel.");

            IsCanceled = true;
        }

        private bool IsCancellationPeriodOver()
        {
            return (Customer.IsGoldCustomer && LessThan(24) ||
                   !Customer.IsGoldCustomer && LessThan(48));
        }

        private bool LessThan(int maxHours)
        {
            return (From - DateTime.Now).TotalHours < maxHours;
        }
        #endregion
    }
}