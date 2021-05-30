using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Linq
{
    class Program
    {   
        public static void LinqQuery()
        {
            int[] myInt = { 10, 20, 40, 50, 80, 75, 66, 30, 32,};
            var result = from i in myInt where i < 25 orderby i select i;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            LinqQuery();
        }
    }
}
