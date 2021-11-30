using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaddersAndSnakes.UI
{
    internal class Logic
    {

        //List of Used locations
        public static List<Point> PointList { get; set; } = new List<Point>();


        //List of Snakes
        public static List<Snake> SnakeList { get; set; } = new List<Snake>();

        //List of Ladders
        public  static List<Ladder> LadderList { get; set; } = new List<Ladder>();





        //Set location for snake/ladder head
        public static Point SetRandomPositionForHead(Point Head)
        {

            Random random = new Random();
            bool flag = false;
            while (!flag)
            {
                Head = new Point(random.Next(1, 9) * 70 + 50, random.Next(1, 9) * 60 + 10);
                foreach (Point point in PointList)
                {

                    if (point == Head)
                    {

                        SetRandomPositionForHead(Head);
                    }
                    else
                    {
                        flag = true;
                    }

                }
            }
            return Head;
        }


        //Set location for snake/ladder tail
        public static Point SetRandomPositionForTail(Point Tail)
        {
            Random random = new Random();
            bool flag = false;
            while (!flag)
            {
                Tail = new Point(random.Next(1, 9) * 70 + 50, random.Next(1, 9) * 60 + 10);
                foreach (Point point in PointList)
                {

                    if (point == Tail)
                    {

                        SetRandomPositionForHead(Tail);
                    }
                    else
                    {
                        flag = true;
                    }

                }
            }
            return Tail;
        }
        

        //Move the picture of the player
        public static void MovePicture(Player player,PictureBox picture)
        {

            picture.Location = player.Location;
            Thread.Sleep(300);
        }


        //Create gold location
        public static void NewGold(TextBox gold)
        {
            Random random = new Random();

            gold.Location = new Point(random.Next(1, 9) * 70 + 50, random.Next(1, 9) * 60 + 10);
            foreach (Point point in Logic.PointList)
            {
                while (point == gold.Location)
                {
                    gold.Location = new Point(random.Next(1, 9) * 70 + 50, random.Next(1, 9) * 60 + 10);
                }
            }
            Logic.PointList.Add(gold.Location);
        }

        //Switch the lead player location with the player how stand on gold 
        public static void StepOnGold(Player player1, Player player2, TextBox gold1, TextBox gold2, PictureBox pbplayer1, PictureBox pbplayer2)
        {
            int lastYpos1 = player1.Location.Y;
            int lastYpos2 = player2.Location.Y;
            if (player1.Location.Y > player2.Location.Y || (player1.Location.X > player2.Location.X && player1.Location.Y == player2.Location.Y))
            {
                if ((gold1.Location.X == player1.Location.X && gold1.Location.Y == player1.Location.Y) ||
                    (gold2.Location.X == player1.Location.X && gold2.Location.Y == player1.Location.Y))
                {

                    int tempX;
                    int tempY;
                    tempX = player1.Location.X;
                    tempY = player1.Location.Y;
                    player1.Location = new Point(player2.Location.X, player2.Location.Y);
                    player2.Location = new Point(tempX, tempY);
                }
                if ((((((player1.Location.Y - 10) / 60) + ((lastYpos1 - 10) / 60))) % 2 == 1) && player1.Direction == true)
                {
                    player1.Direction = false;
                }
                else if ((((((player1.Location.Y - 10) / 60) + ((lastYpos1 - 10) / 60))) % 2 == 1) && player1.Direction == false)
                {
                    player1.Direction = true;
                }

                if ((((((player2.Location.Y - 10) / 60) + ((lastYpos2 - 10) / 60))) % 2 == 1) && player2.Direction == true)
                {
                    player2.Direction = false;
                }
                else if ((((((player2.Location.Y - 10) / 60) + ((lastYpos2 - 10) / 60))) % 2 == 1) && player2.Direction == false)
                {
                    player2.Direction = true;
                }
                pbplayer1.Location = player1.Location;
                pbplayer2.Location = player2.Location;
            }
            else
                return;
        }


    }
}
