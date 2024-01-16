using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Game1
{
    internal class GameLoop
    {
        public int playerPosition = Program.mapRowSize / 2;
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int key); //As i understand it, i imported a dll that was written in C++ and now im using it in C#
        public int runGame(int playerPosition)
        {
            /*if (Console.KeyAvailable) //checks íf a key is pressed
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    playerPosition--;
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    playerPosition++;
                }
            }
            */
            if ((GetAsyncKeyState(0x25) & 0x8000) > 0) // GetAsyncKeyState returns int, no bool so it has to be > 0 ; left arrow press condition ; https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getasynckeystate
            {
                playerPosition--;
            }
            if ((GetAsyncKeyState(0x27) & 0x8000) > 0) //there is no else, because user can press both right and left arrow at the same time
            {
                playerPosition++;
            }
                 
            return playerPosition;
        }
        public bool collisionDetection(int playerPosition, List<char[]> map)
        {
            bool collisionDetection = false;
            char[] mapRow = map[0];
            if (mapRow[playerPosition] == '/' || mapRow[playerPosition] == '│' || mapRow[playerPosition] == '\\' || mapRow[playerPosition] == '#')
            {
                collisionDetection = true;
            }
            return collisionDetection;
        }
        public static void rickroll()
        {
            ProcessStartInfo psi = new ProcessStartInfo(); // credit https://tpforums.org/forum/archive/index.php/t-1524.html ; i just changed iexplore to edge ; also haha get rickrolled
            psi.CreateNoWindow = true;
            psi.FileName = "msedge.exe";
            psi.Arguments = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(psi);
        }
        public static void takeOnMe()
        {
            Console.Beep(369, 200); // credit https://gist.github.com/Shensd/01342e2f399de4dca2ca87b36059ba0a
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(293, 200);
            Console.Beep(246, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(415, 200);
            Console.Beep(415, 200);
            Console.Beep(440, 200);
            Console.Beep(493, 200);
            Console.Beep(440, 200);
            Console.Beep(440, 200);
            Console.Beep(440, 200);
            Console.Beep(329, 200);
            Console.Beep(293, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(369, 200);
            Console.Beep(329, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(293, 200);
            Console.Beep(246, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(415, 200);
            Console.Beep(415, 200);
            Console.Beep(440, 200);
            Console.Beep(493, 200);
            Console.Beep(440, 200);
            Console.Beep(440, 200);
            Console.Beep(440, 200);
            Console.Beep(329, 200);
            Console.Beep(293, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(369, 200);
            Console.Beep(329, 200);
        }
    }
}
