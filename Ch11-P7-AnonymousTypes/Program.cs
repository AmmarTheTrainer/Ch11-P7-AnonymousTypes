using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11_P7_AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Internet Surfing

            var Person = new { FirstName = "Ammar", LastName = "Shaukat" };

            Console.WriteLine(Person.FirstName);

            #endregion

            Console.ReadLine();
        }
    }
}
