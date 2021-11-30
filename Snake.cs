using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaddersAndSnakes.UI
{
    internal class Snake
    {
        public Point SnakeHead { get; set; }
        public Point SnakeTail { get; set; }

        public Snake(Point snakeHead, Point snakeTail)
        {
            SnakeHead = snakeHead;
            SnakeTail = snakeTail;
        }

        //Check if the snake can place in some location or not
        public static bool CheckSnake(Snake snake)
        {
            foreach (Point point in Logic.PointList)
            {
                if (snake.SnakeHead.Y >= snake.SnakeTail.Y || point == snake.SnakeHead || point == snake.SnakeTail)
                {
                    return false;

                }
            }
            return true;
        }

        //Move the player to the tail of the snake
        public static void StandOnSnakeHead(Player player)
        {
            foreach (var point in Logic.SnakeList)
            {
                if (point.SnakeHead == player.Location)
                {
                    int lastYpos = player.Location.Y;
                    player.Location = point.SnakeTail;

                    if ((((((player.Location.Y - 10) / 60) + ((lastYpos - 10) / 60))) % 2 == 1) && player.Direction == true)
                    {
                        player.Direction = false;
                    }
                    else if ((((((player.Location.Y - 10) / 60) + ((lastYpos - 10) / 60))) % 2 == 1) && player.Direction == false)
                    {
                        player.Direction = true;
                    }
                }
            }
        }


    }
}
