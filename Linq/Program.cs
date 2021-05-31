using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


namespace Linq
{
    
    public class Car : IDisposable
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Count { get; set; }
        public string Make { get; set; }        

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    class ProductInfo
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int NumberInStock { get; set; }

        public override string ToString() => $"Name={Name}, " +
            $"Description={Description}, Number in Stock={NumberInStock}";
    }
    class Program
    {
        public static void LinqQuery()
        {
            string[] mystring = { "fafawfa", "sgegesg", "sgdsgsgsg", "12345" };
            int result = (from i in mystring where i.Length > 8 select i).Count();
            Console.WriteLine(result);
        }
        public delegate int Newwest(int a, int b);
        static void TakeEveryThing(ProductInfo[] prInfo)
        {
            var result = from pr in prInfo where pr.NumberInStock > 25 
                         orderby pr descending
                         select new {pr.Name, pr.Description };
            foreach (var item in result)
            {
                Console.WriteLine("{0}",item.ToString());
            }
        }
        static Array ReturnArray(ProductInfo[] prInfo)
        {
            var result = from pr in prInfo
                         where pr.NumberInStock > 25
                         select new { pr.Name, pr.Description };
            return result.ToArray();
        }
        static void GetCar(ArrayList myCars)
        {
            var myCarsEnum = myCars.OfType<Car>();
            var hereCar = from c in myCarsEnum
                          where c.Count > 12000 && c.Color == "Green"
                          select c;
            foreach (var item in hereCar.Reverse())
            {
                Console.WriteLine("Here: {0} {1}",item.Make, item.Name);
            }
        }
        public static void LinqArray()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.AddRange(new object[] { 10, true, 'h', "string", 55, "test" });
            var newArrayList = arrayList.OfType<int>();
            foreach (var item in newArrayList)
            {
                Console.WriteLine("integer: {0}",item);
            }
        }
      
        static void Main(string[] args)
        {
            ArrayList cars = new ArrayList()
            {
                new Car{Name = "Ceed", Color = "Red", Count = 10000, Make = "Kia"},
                new Car{Name = "LC", Color = "Black", Count = 25000, Make = "Toyota"},
                new Car{Name = "Three", Color = "Green", Count = 15000, Make = "Mazda"},
                new Car{Name = "Stenger", Color = "Silver", Count = 27000, Make = "Kia"},
                new Car{Name = "Polo", Color = "White", Count = 11000, Make = "VW"}
            };

            ProductInfo[] itemsInStock = new[]
            {
                new ProductInfo{ Name = "Mac's Coffee",
                                Description = "Coffee with TEETH",
                                NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk",
                                Description = "Milk cow's love",
                                NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu",
                                Description = "Bland as Possible",
                                NumberInStock = 120},
                new ProductInfo{ Name = "Cruchy Pops",
                                Description = "Cheezy, peppery goodness",
                                NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water",
                                Description = "From the tap to your wallet",
                                NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza",
                                Description = "Everyone loves pizza!",
                                NumberInStock = 73}
            };
            try
            {
                Array result = ReturnArray(itemsInStock);
                TakeEveryThing(itemsInStock);
                LinqQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
            Console.WriteLine(GC.GetTotalMemory(false));
        }
    }
}
