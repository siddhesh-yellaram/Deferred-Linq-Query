using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefferedLinqQuery
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var empList = new List<Employee>(
                    new Employee[]
                    {
                        new Employee{ ID = 1, Name = "Sid", Age = 21},
                        new Employee { ID = 2, Name = "Jack", Age = 27},
                        new Employee { ID = 3, Name = "Akira", Age = 29},
                        new Employee { ID = 4, Name = "Barbara", Age = 31},
                        new Employee { ID = 5, Name = "James", Age = 28}
                    }
                );

            var lst = from e in empList
                      where e.Age > 27
                      select new { e.Name };

            empList.Add(new Employee { ID = 6, Name = "Bruce", Age = 27 });

            Console.WriteLine("\nEmployees with age greater than 27 are:");
            
            //Deferred Execution happens here since the query var lst does not get executed
            //but it is called when it iterates over the entire List.
            //It is basically used for return the sequence of values and therefore it is helpful for fetching latest info.
            foreach(var emp in lst)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();
        }
    }
}
