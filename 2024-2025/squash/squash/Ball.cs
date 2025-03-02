using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace squash
{
    internal class Ball
    {
        public int horizontalVector = 1;
        public int verticalVector = 1;
        public int[] position = {12, 30};

        public void RandomizeVector()
        {
            Random rng = new Random();
            int direction = rng.Next(0, 1);
            int verticalRandomised = rng.Next(-3, 0);
            Thread.Sleep(10);
            int horizontalRandomised = rng.Next(1, 4);

            if (direction == 0)
            {
                horizontalVector = horizontalRandomised;
                verticalVector = 1;
            } 
            else if (verticalVector > 0)
            {
                verticalVector = verticalRandomised;
                horizontalVector = 1;
            }
            else
            {
                verticalVector = Math.Abs(verticalRandomised);
                horizontalVector = 1;
            }




        }
        public (bool, char[,]) BallMovement(int turnCounter, char[,] map)
        {
            int[] oldPosition = new int[] { position[0], position[1] };

            if (turnCounter % Math.Abs(verticalVector) == 0)
            {
                if (verticalVector > 0)
                    position[0]++;
                else
                    position[0]--;
            }
            if (turnCounter % Math.Abs(horizontalVector) == 0)
            {
                if (horizontalVector > 0)
                    position[1]++;
                else
                    position[1]--;
            }

            // loose condition if the ball goes off the left side 
            if (position[1] == -1)
            {
                return (true, map);
            }

            if (map[position[0], position[1]] == '-')
            {
                verticalVector *= -1;
                position[0] = oldPosition[0];
            }
            else if (map[position[0], position[1]] == '|')
            {
                horizontalVector *= -1;
                position[1] = oldPosition[1];

                if (position[0] < map.GetLength(1))
                {
                    RandomizeVector();
                }
            }
            else if (map[position[0], position[1]] == '#')
            {
                horizontalVector *= -1;
                verticalVector *= -1;
                position[0] = oldPosition[0];
                position[1] = oldPosition[1];
            }

            // Clear the old ball position.
            Console.SetCursorPosition(oldPosition[1], oldPosition[0]);
            Console.Write(" ");

            // first parameter is column, second is row.
            Console.SetCursorPosition(position[1], position[0]);
            Console.Write("o");

            return (false, map);
        }
    }
}
