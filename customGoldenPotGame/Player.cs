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
        private int[] mainPlayerPos = new int[2];
        private int[] mainPlayerPosHistory = new int[2];
        // Use Width and height from map instead

        private char playerCharacter = Convert.ToChar("0");
        private char emptyChar = Convert.ToChar(" ");


        private int x;
        private int y;

        public Player()
        {
            // main Player start Pos
            x = 30;
            y = 18;

            mainPlayerPos[0] = x;
            mainPlayerPos[1] = y;


        }
        public void movePlayerToNextPos()
        {
            GameManager.renderCharAtPos(mainPlayerPos, playerCharacter);
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
            mainPlayerPosHistory[0] = mainPlayerPos[0];
            mainPlayerPosHistory[1] = mainPlayerPos[1];
            if (inputKey == 'w')
            {
                //up
                // check for avoiding going out of bounds
                // not the smartest solution but it works (optimize)
                // flickering appears because trail is removed while not changing position
                //on key hold char dissapears until you move the opposite direction
                if (mainPlayerPos[1] > GameManager.boundaries[3])
                {
                    mainPlayerPos[1]--;
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
                if (mainPlayerPos[0] > GameManager.boundaries[1])
                {
                    mainPlayerPos[0]--;
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
                if (mainPlayerPos[1] < GameManager.boundaries[2])
                {
                    mainPlayerPos[1]++;
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
                if (mainPlayerPos[0] < GameManager.boundaries[0])
                {
                    mainPlayerPos[0]++;
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
