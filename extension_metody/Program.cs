using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extension_metody
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Příklad použití extension metod
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Random Element: " + numbers.RandomElement());

            Console.WriteLine("Random Elements with condition: " + string.Join(", ", numbers.RandomElementsWith(3, x => x % 2 == 0)));

            Console.WriteLine("Elements appearing greater than or equal to 2 times: " + string.Join(", ", numbers.AppearanceGreaterThen(2)));

            Console.WriteLine("Every 2nd Element: " + string.Join(", ", numbers.Every(2)));

            Console.WriteLine("Unique Elements: " + string.Join(", ", numbers.Unique()));


            Console.ReadLine();
        }
    }
}
