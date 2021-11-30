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
    internal class Player
    {

        public Point Location { get; set; }
        public bool Direction { get; set; } // true = right , false = left
        public string Name { get; set; }
        public string LastMovement { get; set; } // (Left, Right, Up)

        public Player(Point location, bool direction, string name, string lastMovement)
        {
            Location = location;
            Direction = direction;
            Name = name;
            LastMovement = lastMovement;
        }



        //Move the player after all the steps
        public static void Movement(Player player ,int cubeNum, PictureBox picture)
        {
            int lastXPos = player.Location.X;
            int lastYPos = player.Location.Y;
            int sum;
            sum = cubeNum;

            while (sum > 0)
            {
                if (player.Location.X == 680)
                {
                    player.Direction = false;
                }

                if ((player.Location.X == 680 || (player.Location.X == 50 && player.Location.Y !=550)) && player.Location.Y == lastYPos && player.LastMovement != "Up")
                {
                    lastYPos = player.Location.Y;
                    Player.Up(player);
                    player.LastMovement = "Up";
                    player.Direction = true;
                    sum--;
                    Logic.MovePicture(player, picture);
                }
                else if ((player.Location.X == 50 && player.Location.Y != 550) && player.Location.Y == lastYPos && player.LastMovement != "Up")
                {
                    lastYPos = player.Location.Y;
                    Player.Up(player);
                    player.LastMovement = "Up";
                    player.Direction = false;
                    sum--;
                    Logic.MovePicture(player, picture);
                }
                else if (player.Direction == true)
                {
                    
                    lastXPos= player.Location.X;

                    Player.Right(player);
                    player.LastMovement = "Right";

                    sum--;
                    Logic.MovePicture(player, picture);
                }
                else if (player.Direction == false)
                {
                    lastXPos = player.Location.X;
                    Player.Left(player);
                    player.LastMovement = "Left";
                    sum--;
                    Logic.MovePicture(player, picture);
                }
            }
        }
       

        //Move the player one step up 
        public static void Up(Player playerPos)
        {
            int Y = (playerPos.Location.Y - 60) % 550;

            if (Y == 0) Y = 550;
            playerPos.Location = new Point(playerPos.Location.X, Y);
        }

        //Move the player one step right 
        public static void Right(Player playerPos)
        {
            int X = (playerPos.Location.X + 70) % 680;

            if (X == 0) X = 680;

            playerPos.Location = new Point(X , playerPos.Location.Y);
            
        }

        //Move the player one step left
        public static void Left(Player playerPos)
        {
            int X = (playerPos.Location.X - 70) % 680;
            if (X == 0) X = 680;
            playerPos.Location = new Point(X, playerPos.Location.Y);
            
        }
    }
}
