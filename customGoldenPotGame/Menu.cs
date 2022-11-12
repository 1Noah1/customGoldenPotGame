using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    public class Menu
    {
        public void startMenu()
        {
            string divider = "___________________________________________________";
            Console.WriteLine("Welcome to my Game!");
            Thread.Sleep(1000);
            Console.WriteLine("Your task is collecting all the Items across the map");
            Thread.Sleep(1500);
            Console.WriteLine("Just move to the items (item var)");
            Console.WriteLine(divider);
            Console.WriteLine("MOVEMENT:");
            Console.WriteLine("Move the Main Character (O) with the \"wasd\" Keys");
            Console.WriteLine("Move the Second Character (X) with the \"plöä\" Keys");
            Console.WriteLine(divider);
            Thread.Sleep(2500);
            Console.WriteLine();
            Console.WriteLine("Enjoy! :D");
            Console.WriteLine();
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
    }
}
