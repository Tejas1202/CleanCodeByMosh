using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class OutputParameters
    {
        public void DisplayCustomers()
        {
            #region Calling Bad Code
            //int totalCount = 0;
            //var customers = GetCustomers(1, out totalCount);
            #endregion

            var result = GetCustomers(pageIndex: 1);

            Console.WriteLine("Total customers: " + result.TotalCount);
            foreach (var c in result.Customers)
                Console.WriteLine(c);
        }

        #region Code Smell
        //public IEnumerable<Customer> GetCustomers(int pageIndex, out int totalCount)
        //{
        //    totalCount = 100;
        //    return new List<Customer>();
        //}
        #endregion

        public GetCustomerResult GetCustomers(int pageIndex)
        {
            return new GetCustomerResult
            {
                Customers = new List<Customer>(),
                TotalCount = 100
            };
        }
    }

    // Hence creating a new class for replacing out parameter
    public class GetCustomerResult
    {
        public IEnumerable<Customer> Customers { get; set; }
        public int TotalCount { get; set; }
    }
}
