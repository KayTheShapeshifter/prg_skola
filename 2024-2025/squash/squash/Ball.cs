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

        public (bool, char[,]) BallMovement(int turnCounter, char[,] map)
        {
            int[] oldPosition = new int[] { position[0], position[1] };

            // Use turnCounter to regulate speed if needed. For now, we always move.
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

            // Loose condition if the ball goes off the left side (for example)
            if (position[1] == -1)
            {
                return (true, map);
            }

            if (map[position[0], position[1]] == '-')
            {
                verticalVector *= -1;
                // Adjust position back inside the boundary.
                position[0] = oldPosition[0];
            }
            else if (map[position[0], position[1]] == '|')
            {
                horizontalVector *= -1;
                // Adjust position back inside the boundary.
                position[1] = oldPosition[1];
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

            // Draw the ball at the new position.
            // first parameter is column, second is row.
            Console.SetCursorPosition(position[1], position[0]);
            Console.Write("o");

            return (false, map);
        }
    }
}
