using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace squash
{
    internal class Player
    {
        public int position;
        public int length;
        public char direction;
        public bool movedLastTurn;
        

        public Player() 
        { 
            
        }
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int key); //As i understand it, i imported a dll that was written in C++ and now im using it in C#
        /*
        public (int, char, bool) PlayerMovement(int playerPosition, int playerLength, char[,] map, bool movedLastTurn)
        {
            char playerDirection;
            bool movedThisTurn = false;
            playerDirection = '|';
            if ((GetAsyncKeyState(0x53) & 0x8000) > 0 && playerPosition + playerLength < map.GetLength(0) - 2) // 0x28-arrow downGetAsyncKeyState returns int, no bool so it has to be > 0 ; left arrow press condition ; https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getasynckeystate
            {
                playerPosition++;
                playerDirection = '↓';
                movedThisTurn = true;
            }
            if ((GetAsyncKeyState(0x57) & 0x8000) > 0 && playerPosition + playerLength > 0) //0x26-arrow down right arrow ; there is no else, because user can press both right and left arrow at the same time
            {
                playerPosition--;
                playerDirection = '↑';
                movedThisTurn = true;
            }

            if (movedLastTurn)
            {
                PrintPlayer(playerPosition, playerDirection, playerLength);
            }

            movedLastTurn = movedThisTurn;

            return (playerPosition, playerDirection, movedLastTurn);
        }
        public void PrintPlayer(int playerPosition, char playerDirection, int playerLength)
        {
            //Console.SetCursorPosition(0, i + playerPosition);

            for (int i = 0; i < playerLength; i++)
            {
                Console.SetCursorPosition(0, i + playerPosition);
                Console.Write(playerDirection);
            }
        }
        */

        // In Player class
        public (int, char, char[,]) PlayerMovement(int playerPosition, int playerLength, char[,] map)
        {
            char playerDirection = '|';

            //move up
            if ((GetAsyncKeyState(0x57) & 0x8000) > 0 && playerPosition > 1)
            {
                map[playerPosition + playerLength, 0] = ' ';
                playerPosition--;
                playerDirection = '↑';
                map[playerPosition, 0] = '|';

            }
            //move down
            if ((GetAsyncKeyState(0x53) & 0x8000) > 0 && playerPosition + playerLength < map.GetLength(0) - 1)
            {
                map[playerPosition, 0] = ' ';
                playerPosition++;
                playerDirection = '↓';
                map[playerPosition + playerLength, 0] = '|';
            }
            return (playerPosition, playerDirection, map);
        }

        public void ClearPlayer(int oldPosition, int playerLength)
        {
            for (int i = 0; i < playerLength; i++)
            {
                Console.SetCursorPosition(0, oldPosition + i);
                Console.Write(' ');  // Overwrite with blank space
            }
        }

        public void PrintPlayer(int playerPosition, char playerDirection, int playerLength)
        {
            for (int i = 0; i < playerLength; i++)
            {
                Console.SetCursorPosition(0, playerPosition + i);
                Console.Write('|');
            }
        }




    }

}
