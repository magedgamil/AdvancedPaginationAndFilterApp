using Shared;
using System;
using System.Linq;
using System.Threading;

namespace CustomLINQMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.Employees;
        
            var page1 = employees.paginate(1, 10);
            var page2 = employees.paginate(2, 10);
            var page3 = employees.paginate(3, 10);

            page1.Print("Page 1");             
            page2.Print("Page 2");             
            page3.Print("Page 3");             
         

           var page1Filtered = employees.WhereWithPaginate(e => e.Salary > 1000, 1, 10);
            page1Filtered.Print("Page 1 Filtered With Salary > 1000");
            Console.ReadKey();
        }
         
    }
}
