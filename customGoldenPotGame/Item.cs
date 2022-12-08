using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    public class Item
    {
        Random random = new();
        public const char item = 'I';
        public const char badItem = 'X';
        public Item()
        {
            //x
            GameManager.itemPos[0] = random.Next(GameManager.boundaries[1], GameManager.boundaries[0]);
            //y
            GameManager.itemPos[1] = random.Next(GameManager.boundaries[3], GameManager.boundaries[2]);

            //x
            GameManager.badItemPos[0] = random.Next(GameManager.boundaries[1], GameManager.boundaries[0]);
            //y
            GameManager.badItemPos[1] = random.Next(GameManager.boundaries[3], GameManager.boundaries[2]);
        }
        public static void renderItem()
        {
            GameManager.renderCharAtPos(GameManager.itemPos, item);
            GameManager.renderCharAtPos(GameManager.badItemPos, badItem);
        }
    }
}
