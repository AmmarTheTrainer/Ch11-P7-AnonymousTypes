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
            //InterNEtSurfing();

            Console.WriteLine("***** Fun with Anonymous Types *****\n");

            //// Make an anonymous type representing a car.
            //var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };

            //// Now show the color and make.
            //Console.WriteLine("My car is a {0} {1}.", myCar.Color, myCar.Make);

            //// Now call our helper method to build anonymous type via args.
            //BuildAnonType("BMW", "Black", 90);

            #region Working with Overriden MEthods


            //// Make an anonymous type representing a car.
            //var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            //var myCar2 = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            //// Reflect over what the compiler generated.
            //ReflectOverAnonymousType(myCar);

            //Console.WriteLine();
            //Console.WriteLine(myCar.ToString());

            //Console.WriteLine();
            //Console.WriteLine("myCar.GetHashCode()  " + myCar.GetHashCode());
            //Console.WriteLine("myCar2.GetHashCode()  " + myCar2.GetHashCode());


            //EqualityTest();

            #endregion

            //// Make an anonymous type that is composed of another.
            //var purchaseItem = new
            //{
            //    TimeBought = DateTime.Now,
            //    ItemBought = new { Color = "Red", Make = "Saab", CurrentSpeed = 55 },
            //    Price = 34.000
            //};

            //ReflectOverAnonymousType(purchaseItem);

            #region Where exactly to use Anonymous Types:

            List<Student> studentList = new List<Student>()
            {
                        new Student() { StudentID = 1, StudentName = "John", age = 18 } ,
                        new Student() { StudentID = 2, StudentName = "Steve",  age = 21 } ,
                        new Student() { StudentID = 3, StudentName = "Bill",  age = 18 } ,
                        new Student() { StudentID = 4, StudentName = "Ram" , age = 20  } ,
                        new Student() { StudentID = 5, StudentName = "Ron" , age = 21 }
            };

            var studentNames = from s in studentList
                               select new
                               {
                                   StudentID = s.StudentID,
                                   StudentName = s.StudentName
                               };

            foreach (var item in studentNames)
            {
                Console.WriteLine(item.StudentID + " : " + item.StudentName);
            }

            #endregion

            Console.ReadLine();
        }

        private static void EqualityTest()
        {
            // Make 2 anonymous classes with identical name/value pairs.
            var firstCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            var secondCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };

            Console.WriteLine("\nUse of Equals() overridden method > firstCar.Equals(secondCar) ");
            // Are they considered equal when using Equals()?
            if (firstCar.Equals(secondCar))
                Console.WriteLine("Same anonymous object!");
            else
                Console.WriteLine("Not the same anonymous object!");

            Console.WriteLine("\nUse of == > firstCar == secondCar ");
            // Are they considered equal when using ==?
            if (firstCar == secondCar)
                Console.WriteLine("Same anonymous object!");
            else
                Console.WriteLine("Not the same anonymous object!");

            Console.WriteLine("\nUse of TYpes names with == > firstCar.GetType().Name == secondCar.GetType().Name ");

            // Are these objects the same underlying type?
            if (firstCar.GetType().Name == secondCar.GetType().Name)
                Console.WriteLine("We are both the same type!");
            else
                Console.WriteLine("We are different types!");
            
            // Show all the details.
            Console.WriteLine();
            ReflectOverAnonymousType(firstCar);
            ReflectOverAnonymousType(secondCar);
        }

        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString() == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());

            string typename = obj.GetType().Name;

            Console.WriteLine();
        }

        private static void BuildAnonType(string make, string color, int currSp)
        {
            // Build anon type using incoming args.
            var car = new { Make = make, Color = color, Speed = currSp };
            
            // Note you can now use this type to get the property data!
            Console.WriteLine("You have a {0} {1} going {2} MPH", car.Color, car.Make, car.Speed);
            
            // Anon types have custom implementations of each virtual method of System.Object. For example:
            Console.WriteLine("ToString() == {0}", car.ToString());
        }

        private static void InterNEtSurfing()
        {
            var result = new { FirstName = "Ammar", LastName = "Hassan" };

            //result.FirstName = "NEw name"; // immutable

            Console.WriteLine(result.FirstName);
        }
    }
}
