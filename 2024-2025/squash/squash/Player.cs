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
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int key); //As i understand it, i imported a dll that was written in C++ and now im using it in C#
        public (int, char) PlayerMovement(int playerPosition, char playerDirection, int playerLength, char[,] map)
        {
            playerDirection = '|';
            if ((GetAsyncKeyState(0x28) & 0x8000) > 0 && playerPosition + playerLength < map.GetLength(1) - 1) // GetAsyncKeyState returns int, no bool so it has to be > 0 ; left arrow press condition ; https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getasynckeystate
            {
                playerPosition--;
                playerDirection = '↓';
            }
            if ((GetAsyncKeyState(0x26) & 0x8000) > 0 && playerPosition + playerLength > 0) //right arrow ; there is no else, because user can press both right and left arrow at the same time
            {
                playerPosition++;
                playerDirection = '↑';
            }

            return (playerPosition, playerDirection);
        }


    }

}
