using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace CleanCode.Comments
{
    #region Poorly commented code
    //public class Comments
    //{
    //    private int _pf;  // pay frequency
    //    private DbContext _dbContext;

    //    public Comments()
    //    {
    //        _dbContext = new DbContext();
    //    }

    //    // Returns list of customers in a country.
    //    public List<Customer> GetCustomers(int countryCode)
    //    {
    //        //TODO: We need to get rid of abcd once we revisit this method. Currently, it's 
    //        // creating a coupling betwen x and y and because of that we're not able to do 
    //        // xyz. 

    //        throw new NotImplementedException();
    //    }

    //    public void SubmitOrder(Order order)
    //    {
    //        // Save order to the database
    //        _dbContext.Orders.Add(order);
    //        _dbContext.SaveChanges();

    //        // Send an email to the customer
    //        var client = new SmtpClient();
    //        var message = new MailMessage("noreply@site.com", order.Customer.Email, "Your order was successfully placed.", ".");
    //        client.Send(message);

    //    }
    //}
    #endregion

    #region Refactored Code
    // TODO comments are not code smells, they're important as someone might wanna fix that or implement that later
    // Whenever you see two code snippets inside one method with seperate comments (like SubmitOrder above), it may be an oppurtunity
    // to create seperate methods for them
    public class Comments
    {
        private int payFrequency;
        private DbContext _dbContext;

        public Comments()
        {
            _dbContext = new DbContext();
        }

        public List<Customer> GetCustomers(int countryCode)
        {
            //TODO: We need to get rid of abcd once we revisit this method. Currently, it's 
            // creating a coupling betwen x and y and because of that we're not able to do 
            // xyz. 

            throw new NotImplementedException();
        }

        public void SubmitOrder(Order order)
        {
            SaveOrder(order);

            NotifyCustomer(order);
        }

        private static void NotifyCustomer(Order order)
        {
            var client = new SmtpClient();
            var message = new MailMessage("noreply@site.com", order.Customer.Email, "Your order was successfully placed.", ".");
            client.Send(message);
        }

        private void SaveOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }
    #endregion

    #region Supporting Code
    public class DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public void SaveChanges()
        {


        }
    }

    public class DbSet<T>
    {
        public void Add(Order order)
        {


        }
    }
    public class Order
    {
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public string Email { get; set; }
    }
    #endregion
}
