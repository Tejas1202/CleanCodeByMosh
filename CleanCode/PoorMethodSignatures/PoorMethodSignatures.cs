using System;
using System.Linq;

namespace CleanCode.PoorMethodSignatures
{
    public class PoorMethodSignatures
    {
        public void Run()
        {
            var userService = new UserService();

            #region Calling Bad Code
            //var user = userService.GetUser("username", "password", true);
            //var anotherUser = userService.GetUser("username", null);
            #endregion

            #region Calling Refactored Code
            var user = userService.Login("username", "password");
            var anotherUser = userService.GetUser("username");
            #endregion
        }
    }

    public class UserService
    {
        private UserDbContext _dbContext = new UserDbContext();

        // Passing a bool parameter like this just to decide the execution path inside a method is most likely a code smell
        // The ideal way should be to create different methods for those execution paths
        #region Bad Code
        //public User GetUser(string username, string password, bool login)
        //{
        //    if (login)
        //    {
        //        // Check if there is a user with the given username and password in db
        //        // If yes, set the last login date 
        //        // and then return the user. 
        //        var user = _dbContext.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        //        if (user != null)
        //            user.LastLogin = DateTime.Now;
        //        return user;
        //    }
        //    else
        //    {
        //        // Check if there is a user with the given username
        //        // If yes, return it, otherwise return null
        //        var user = _dbContext.Users.SingleOrDefault(u => u.Username == username);
        //        return user;
        //    }
        //}
        #endregion

        #region Refactored code
        // Hence here we created two seperate clear methods which doesn't take unnecessary parameters
        // Also the caller will now get more idea of what each of the methods does
        public User GetUser(string username)
        {
            // Check if there is a user with the given username
            // If yes, return it, otherwise return null
            var user = _dbContext.Users.SingleOrDefault(u => u.Username == username);
            return user;
        }

        public User Login(string username, string password)
        {
            // Check if there is a user with the given username and password in db
            // If yes, set the last login date 
            // and then return the user. 
            var user = _dbContext.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
                user.LastLogin = DateTime.Now;
            return user;
        }
        #endregion
    }

    #region Supporting Code
    public class UserDbContext : DbContext
    {
        public IQueryable<User> Users { get; set; }
    }

    public class DbSet<T>
    {
    }

    public class DbContext
    {
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
    }
    #endregion
}