using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaddersAndSnakes.UI
{
    internal class Ladder
    {
        public Point LadderHead { get; set; }
        public Point LadderTail { get; set; }

        public Ladder(Point ladderHead, Point ladderTail)
        {
            LadderHead = ladderHead;
            LadderTail = ladderTail;
        }

        //Check if the ladder can place in some location or not
        public static bool CheckLadder(Ladder ladder)
        {
            foreach (Point point in Logic.PointList)
            {
                if (ladder.LadderTail.Y <= ladder.LadderHead.Y || point == ladder.LadderHead || point == ladder.LadderTail)
                {
                    return false;
                }
            }
            return true;
        }


        //Move the player to the head of the ladder
        public static void StandOnLadderTail(Player player)
        {
            foreach (var point in Logic.LadderList)
            {
                if (point.LadderTail == player.Location)
                {
                    int lastYpos = player.Location.Y;
                    player.Location = point.LadderHead;
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
