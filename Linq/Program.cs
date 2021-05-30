using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Linq
{
    public class LinqQuery
    {
           static int[] myInt = { 10, 20, 40, 50, 80, 75, 66, 30, 32, };
           IEnumerable<int> result = from i in myInt where i < 25 orderby i select i;
           public void enumerate()
           {
                foreach (var item in result) 
                { 
                    Console.WriteLine(item); 
                }
                
           }
    }
    public class Car
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Count { get; set; }
        public string Make { get; set; }
    }
    class Program
    {   
        static void GetCar(List<Car> myCars)
        {
            var hereCar = from c in myCars
                          where c.Count > 12000
                          select c;
            foreach (var item in hereCar)
            {
                Console.WriteLine("Here: {0} {1}",item.Make, item.Name);
            }
        }

        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>()
            {
                new Car{Name = "Ceed", Color = "Red", Count = 10000, Make = "Kia"},
                new Car{Name = "LC", Color = "Black", Count = 25000, Make = "Toyota"},
                new Car{Name = "Three", Color = "Green", Count = 15000, Make = "Mazda"},
                new Car{Name = "Stenger", Color = "Silver", Count = 27000, Make = "Kia"},
                new Car{Name = "Polo", Color = "White", Count = 11000, Make = "VW"}
            };

            GetCar(cars);
        }
    }
}
