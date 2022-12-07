﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    public class Menu
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

        public char startMenu()
        {
            string divider = "___________________________________________________";
            Console.WriteLine("Willkommen bei meinem Spiel!");
            Thread.Sleep(1000);
            Console.WriteLine("Deine Aufgabe ist es die Gegenstände einzusammeln");
            Thread.Sleep(1500);
            Console.WriteLine("Bewege dich einfach zu den Items hin (I)");
            Console.WriteLine("Vermeide die giftigen Gegenstände (X)");
            Console.WriteLine(divider);
            Console.WriteLine("Tastenbelegung");
            Console.WriteLine("Bewege die Spielfigur (O) mit den \"wasd\" Tasten");
            Console.WriteLine(divider);
            Thread.Sleep(2500);
            Console.WriteLine();
            Console.WriteLine("Viel Spaß!");
            Console.WriteLine("");
            Console.WriteLine("Für das");
            Console.WriteLine();
            Console.WriteLine("Tippe \"S\" für das Spiel");
            Console.WriteLine("Tippe \"L\" für das Labyrinth");
            keyInfo = Console.ReadKey(true);
            char inputKey = keyInfo.KeyChar;
            return inputKey;
        }

        public void mazeMenu()
        {
            Console.WriteLine("Du kannst versuchen dich durch das Labyrinth zu bewegen");
            Thread.Sleep(500);
            Console.WriteLine("Schließe alles mit der \"ESC\" Taste ");
            Thread.Sleep(500);
            Console.WriteLine("Du kannst ein neues Labyrinth mit der \"N\" Taste generieren");
             
        }

        public static void renderFailscreen() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < GameManager.Height; i++)
            {
                renderFailPhrase();
            }
            Thread.Sleep(500);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White; 
            Console.Write("Versuch's nochmal");
            Console.ReadKey();
        }
        private static void renderFailPhrase()
        {
            Console.Write("!!DU HAST VERLOREN!!");
            Console.SetCursorPosition(Console.CursorLeft - 19, Console.CursorTop + 1);
            Thread.Sleep(50);
        }
    }
}
