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
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int key); //As i understand it, i imported a dll that was written in C++ and now im using it in C#
        public (int, char) playerMovement(int playerPosition, char playerDirection)
        {
            playerDirection = '↓'; 
            if ((GetAsyncKeyState(0x25) & 0x8000) > 0) // GetAsyncKeyState returns int, no bool so it has to be > 0 ; left arrow press condition ; https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getasynckeystate
            {
                playerPosition--;
                playerDirection = '←';
            }
            if ((GetAsyncKeyState(0x27) & 0x8000) > 0) //right arrow ; there is no else, because user can press both right and left arrow at the same time
            {
                playerPosition++;
                playerDirection = '→';
            }

            return (playerPosition, playerDirection);
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
        public int IncreaseDifficulty(int score)
        {
            double tempSpeed =  30 / (Math.Log10(score) + 1) ;
            int speed = Convert.ToInt32(tempSpeed);
            return speed;
        }
        public static void startGame()
        {
            Console.WriteLine("Welcome, your objective is to not crash into the barriers");
            Thread.Sleep(500);
            Console.WriteLine("You MUST play with the window maximised");
            Thread.Sleep(500);
            Console.WriteLine("You can control movement by pressing either the left, or the right arrow");
            Thread.Sleep(500);
            Console.WriteLine("For best expirience, play with sound");
            Thread.Sleep(500);
            Console.WriteLine("You will be able to start after the tune finishes playing.");
            Thread.Sleep(500);
            GameLoop.takeOnMe();
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            Console.Beep();

            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }
        public void endgame(int score, Map map1)
        {
            Console.SetCursorPosition(0, map1.mapCapacity + score);
            Console.WriteLine("You crashed! Your score is "+ score);
            Thread.Sleep(3000);
            Console.WriteLine("Uhhh, something is happening");
            Thread.Sleep(1000);
            Console.WriteLine("It seems... YOU'RE GETTING RICKROLLED");
            Thread.Sleep(1200);
            rickroll();
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
