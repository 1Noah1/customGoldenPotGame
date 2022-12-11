using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    public class Player
    {
        bool overwriteLastPos = true;

        // read char input properly
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

        //array for saving Player pos
        private int[] mainPlayerPosHistory = new int[2];
        // Use Width and height from map instead

        private char playerCharacter = Convert.ToChar("0");
        private char emptyChar = Convert.ToChar(" ");


        private int x;
        private int y;

        public Player()
        {
            // main Player start Pos
            x = GameManager.Height + 3;
            y = 32;

            GameManager.mainPlayerPos[0] = x;
            GameManager.mainPlayerPos[1] = y;


        }
        public void movePlayerToNextPos()
        {
            GameManager.renderCharAtPos(GameManager.mainPlayerPos, playerCharacter);
            if (overwriteLastPos)
            {
                GameManager.renderCharAtPos(mainPlayerPosHistory, emptyChar);
            }

        }


        public void movement()
        {
            // gets user Input 
            keyInfo = Console.ReadKey(true);
            char inputKey = keyInfo.KeyChar;

            // neccessary to remove trail
            mainPlayerPosHistory[0] = GameManager.mainPlayerPos[0];
            mainPlayerPosHistory[1] = GameManager.mainPlayerPos[1];
            if (inputKey == 'w')
            {
                //up
                // check for avoiding going out of bounds
                // not the smartest solution but it works (optimize)
                //on key hold char dissapears until you move the opposite direction
                if (GameManager.mainPlayerPos[1] > GameManager.boundaries[3])
                {
                    GameManager.mainPlayerPos[1]--;
                    overwriteLastPos = true;
                }
                else
                {
                    overwriteLastPos = false;
                }
            }
            else if (inputKey == 'a')
            {
                //left
                if (GameManager.mainPlayerPos[0] > GameManager.boundaries[1])
                {
                    GameManager.mainPlayerPos[0]--;
                    overwriteLastPos = true;
                }
                else
                {
                    overwriteLastPos = false;
                }
            }
            else if (inputKey == 's')
            {
                //down
                if (GameManager.mainPlayerPos[1] < GameManager.boundaries[2])
                {
                    GameManager.mainPlayerPos[1]++;
                    overwriteLastPos = true;
                }
                else
                {
                    overwriteLastPos = false;
                }
            }
            else if (inputKey == 'd')
            {
                //right
                if (GameManager.mainPlayerPos[0] < GameManager.boundaries[0])
                {
                    GameManager.mainPlayerPos[0]++;
                    overwriteLastPos = true;
                }
                else
                {
                    overwriteLastPos = false;
                }
            }
            else
            {
                // character is not overwritten when unknown key is pressed
                overwriteLastPos = false;
            }
        }
    }
}
