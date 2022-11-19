using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    public class Item
    {
        Random random = new();
        public char item = 'I';
        public Item()
        {
            //x
            GameManager.itemPos[0] = random.Next(GameManager.boundaries[1], GameManager.boundaries[0]);
            //y
            GameManager.itemPos[1] = random.Next(GameManager.boundaries[3], GameManager.boundaries[2]);
        }
        public void renderItem()
        {
            
            GameManager.renderCharAtPos(GameManager.itemPos, item);
        }
    }
}
