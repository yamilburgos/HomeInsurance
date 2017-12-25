using HomeInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User { Username = "Joe Schmoe", Password = "Secret", IsAdmin = false };
            using(QuotesEntity q = new QuotesEntity())
            {
                q.Users.Add(user);
                q.SaveChanges();
            }
        }
    }
}
