using System;
using LaddersAndSnakes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LaddersAndSnakes.UI
{

    public partial class Form1 : Form
    {
        
        //Create the players 
        public static Point startPoint = new Point(50, 550);
        Player bluePlayer { get; set; } = new Player(startPoint, true , "Blue" , "");
        Player redPlayer { get; set; } = new Player(startPoint,true ,"Red", "");

        //Create the snakes
        Snake snake1 { get; set; } = new Snake(startPoint, startPoint);
        Snake snake2 { get; set; } = new Snake(startPoint, startPoint);
        Snake snake3 { get; set; } = new Snake(startPoint, startPoint);
        Snake snake4 { get; set; } = new Snake(startPoint, startPoint);
        Snake snake5 { get; set; } = new Snake(startPoint, startPoint);

        //Create the ladders
        Ladder ladder1 { get; set; } = new Ladder(startPoint, startPoint);
        Ladder ladder2 { get; set; } = new Ladder(startPoint, startPoint);
        Ladder ladder3 { get; set; } = new Ladder(startPoint, startPoint);
        Ladder ladder4 { get; set; } = new Ladder(startPoint, startPoint);
        Ladder ladder5 { get; set; } = new Ladder(startPoint, startPoint);

        

        public Form1()
        {
            InitializeComponent();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            //Add default point to PointList
            Logic.PointList.Add(startPoint);

            //Visual setup
            btnBlue.BackColor = Color.Gray;
            btnBlue.Visible = true;
            btnBlue.Enabled = false;
            btnRed.Visible = false;
            

        }
        

        //BLUE MOVE
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            //Visual setup
            btnRed.Visible = true;
            btnBlue.Visible = false;

            //Cubes roll
            int sumOfCube = Cube.Roll(txtCube1) + Cube.Roll(txtCube2);

            //Move the player on the board 
            Player.Movement(bluePlayer, sumOfCube,pbBlue);

            //Chack if the player stand on special location
            Logic.StepOnGold(bluePlayer, redPlayer, txtGold1, txtGold2 ,pbBlue, pbRed);
            Ladder.StandOnLadderTail(bluePlayer);
            Snake.StandOnSnakeHead(bluePlayer);

            //Move the picture of the player to the player point
            pbBlue.Location = bluePlayer.Location;

            //Chack if player win
            if (bluePlayer.Location.Y < 10 || (bluePlayer.Location.X == 50 && bluePlayer.Location.Y == 10))
            {
                MessageBox.Show(bluePlayer.Name + " WIN!");
            }
        }


        //RED MOVE
        private void button1_Click(object sender, EventArgs e)
        {
            //Visual setup
            btnRed.Visible = false;
            btnBlue.Visible = true;

            //Cubes roll
            int sumOfCube = Cube.Roll(txtCube1) + Cube.Roll(txtCube2);

            //Move the player on the board 
            Player.Movement(redPlayer, sumOfCube ,pbRed);

            //Chack if the player stand on special location
            Logic.StepOnGold(redPlayer,bluePlayer,txtGold1,txtGold2 , pbRed, pbBlue);
            Ladder.StandOnLadderTail(redPlayer);
            Snake.StandOnSnakeHead(redPlayer);

            //Move the picture of the player to the player point
            pbRed.Location = redPlayer.Location;

            //Chack if player win
            if (redPlayer.Location.Y < 10 || (redPlayer.Location.X == 50 && redPlayer.Location.Y == 10))
            {
                MessageBox.Show(redPlayer.Name + " WIN!");
            }
          
        }


        //Board setup
        private void btnStart_Click(object sender, EventArgs e)
        {


            if ((cbNumOfLadder.Text == "1" || cbNumOfLadder.Text == "2" || cbNumOfLadder.Text == "3" || cbNumOfLadder.Text == "4" || cbNumOfLadder.Text == "5") &&
                cbNumOfSnake.Text == "1" || cbNumOfSnake.Text == "2" || cbNumOfSnake.Text == "3" || cbNumOfSnake.Text == "4" || cbNumOfSnake.Text == "5")
            {
                btnBlue.BackColor = Color.Blue;
                btnBlue.Enabled = true;
                btnRed.Visible = false;
                btnStart.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                cbNumOfLadder.Visible = false;
                cbNumOfSnake.Visible = false;
            }
            else
            {
                MessageBox.Show("Please select a number from 1-5");
                cbNumOfLadder.Text = "";
                cbNumOfSnake.Text = "";
            }
            switch (cbNumOfLadder.Text)
            {
                case "1":

                    ladder1.LadderHead = Logic.SetRandomPositionForHead(ladder1.LadderHead);
                    ladder1.LadderTail = Logic.SetRandomPositionForTail(ladder1.LadderTail);
                    while (Ladder.CheckLadder(ladder1) != true)
                    {
                        ladder1.LadderHead = Logic.SetRandomPositionForHead(ladder1.LadderHead);
                        ladder1.LadderTail = Logic.SetRandomPositionForTail(ladder1.LadderTail);
                    }

                    Logic.PointList.Add(ladder1.LadderHead);
                    Logic.PointList.Add(ladder1.LadderTail);


                    Logic.LadderList.Add(ladder1);


                    txtladderHead1.Location = ladder1.LadderHead;
                    txtladderTail1.Location = ladder1.LadderTail;

                  
                    break;

                case "2":

                    ladder1.LadderHead = Logic.SetRandomPositionForHead(ladder1.LadderHead);
                    ladder1.LadderTail = Logic.SetRandomPositionForTail(ladder1.LadderTail);
                    while (Ladder.CheckLadder(ladder1) != true)
                    {
                        ladder1.LadderHead = Logic.SetRandomPositionForHead(ladder1.LadderHead);
                        ladder1.LadderTail = Logic.SetRandomPositionForTail(ladder1.LadderTail);
                    }

                    Logic.PointList.Add(ladder1.LadderHead);
                    Logic.PointList.Add(ladder1.LadderTail);


                    ladder2.LadderHead = Logic.SetRandomPositionForHead(ladder2.LadderHead);
                    ladder2.LadderTail = Logic.SetRandomPositionForTail(ladder2.LadderTail);
                    while (Ladder.CheckLadder(ladder2) != true)
                    {
                        ladder2.LadderHead = Logic.SetRandomPositionForHead(ladder2.LadderHead);
                        ladder2.LadderTail = Logic.SetRandomPositionForTail(ladder2.LadderTail);
                    }

                    Logic.PointList.Add(ladder2.LadderHead);
                    Logic.PointList.Add(ladder2.LadderTail);

                    Logic.LadderList.Add(ladder1);
                    Logic.LadderList.Add(ladder2);


                    txtladderHead1.Location = ladder1.LadderHead;
                    txtladderTail1.Location = ladder1.LadderTail;

                    txtladderHead2.Location = ladder2.LadderHead;
                    txtladderTail2.Location = ladder2.LadderTail;

                    break;

                case "3":

                    ladder1.LadderHead = Logic.SetRandomPositionForHead(ladder1.LadderHead);
                    ladder1.LadderTail = Logic.SetRandomPositionForTail(ladder1.LadderTail);
                    while (Ladder.CheckLadder(ladder1) != true)
                    {
                        ladder1.LadderHead = Logic.SetRandomPositionForHead(ladder1.LadderHead);
                        ladder1.LadderTail = Logic.SetRandomPositionForTail(ladder1.LadderTail);
                    }

                    Logic.PointList.Add(ladder1.LadderHead);
                    Logic.PointList.Add(ladder1.LadderTail);


                    ladder2.LadderHead = Logic.SetRandomPositionForHead(ladder2.LadderHead);
                    ladder2.LadderTail = Logic.SetRandomPositionForTail(ladder2.LadderTail);
                    while (Ladder.CheckLadder(ladder2) != true)
                    {
                        ladder2.LadderHead = Logic.SetRandomPositionForHead(ladder2.LadderHead);
                        ladder2.LadderTail = Logic.SetRandomPositionForTail(ladder2.LadderTail);
                    }

                    Logic.PointList.Add(ladder2.LadderHead);
                    Logic.PointList.Add(ladder2.LadderTail);

                    ladder3.LadderHead = Logic.SetRandomPositionForHead(ladder3.LadderHead);
                    ladder3.LadderTail = Logic.SetRandomPositionForTail(ladder3.LadderTail);
                    while (Ladder.CheckLadder(ladder3) != true)
                    {
                        ladder3.LadderHead = Logic.SetRandomPositionForHead(ladder3.LadderHead);
                        ladder3.LadderTail = Logic.SetRandomPositionForTail(ladder3.LadderTail);
                    }

                    Logic.PointList.Add(ladder3.LadderHead);
                    Logic.PointList.Add(ladder3.LadderTail);

                    Logic.LadderList.Add(ladder1);
                    Logic.LadderList.Add(ladder2);
                    Logic.LadderList.Add(ladder3);

                    txtladderHead1.Location = ladder1.LadderHead;
                    txtladderTail1.Location = ladder1.LadderTail;

                    txtladderHead2.Location = ladder2.LadderHead;
                    txtladderTail2.Location = ladder2.LadderTail;

                    txtladderHead3.Location = ladder3.LadderHead;
                    txtladderTail3.Location = ladder3.LadderTail;
                    break;

                case "4":

                    ladder1.LadderHead = Logic.SetRandomPositionForHead(ladder1.LadderHead);
                    ladder1.LadderTail = Logic.SetRandomPositionForTail(ladder1.LadderTail);
                    while (Ladder.CheckLadder(ladder1) != true)
                    {
                        ladder1.LadderHead = Logic.SetRandomPositionForHead(ladder1.LadderHead);
                        ladder1.LadderTail = Logic.SetRandomPositionForTail(ladder1.LadderTail);
                    }

                    Logic.PointList.Add(ladder1.LadderHead);
                    Logic.PointList.Add(ladder1.LadderTail);


                    ladder2.LadderHead = Logic.SetRandomPositionForHead(ladder2.LadderHead);
                    ladder2.LadderTail = Logic.SetRandomPositionForTail(ladder2.LadderTail);
                    while (Ladder.CheckLadder(ladder2) != true)
                    {
                        ladder2.LadderHead = Logic.SetRandomPositionForHead(ladder2.LadderHead);
                        ladder2.LadderTail = Logic.SetRandomPositionForTail(ladder2.LadderTail);
                    }

                    Logic.PointList.Add(ladder2.LadderHead);
                    Logic.PointList.Add(ladder2.LadderTail);

                    ladder3.LadderHead = Logic.SetRandomPositionForHead(ladder3.LadderHead);
                    ladder3.LadderTail = Logic.SetRandomPositionForTail(ladder3.LadderTail);
                    while (Ladder.CheckLadder(ladder3) != true)
                    {
                        ladder3.LadderHead = Logic.SetRandomPositionForHead(ladder3.LadderHead);
                        ladder3.LadderTail = Logic.SetRandomPositionForTail(ladder3.LadderTail);
                    }

                    Logic.PointList.Add(ladder3.LadderHead);
                    Logic.PointList.Add(ladder3.LadderTail);

                    ladder4.LadderHead = Logic.SetRandomPositionForHead(ladder4.LadderHead);
                    ladder4.LadderTail = Logic.SetRandomPositionForTail(ladder4.LadderTail);
                    while (Ladder.CheckLadder(ladder4) != true)
                    {
                        ladder4.LadderHead = Logic.SetRandomPositionForHead(ladder4.LadderHead);
                        ladder4.LadderTail = Logic.SetRandomPositionForTail(ladder4.LadderTail);
                    }
                    Logic.PointList.Add(ladder4.LadderHead);
                    Logic.PointList.Add(ladder4.LadderTail);


                    Logic.LadderList.Add(ladder1);
                    Logic.LadderList.Add(ladder2);
                    Logic.LadderList.Add(ladder3);
                    Logic.LadderList.Add(ladder4);






                    txtladderHead1.Location = ladder1.LadderHead;
                    txtladderTail1.Location = ladder1.LadderTail;

                    txtladderHead2.Location = ladder2.LadderHead;
                    txtladderTail2.Location = ladder2.LadderTail;

                    txtladderHead3.Location = ladder3.LadderHead;
                    txtladderTail3.Location = ladder3.LadderTail;

                    txtladderHead4.Location = ladder4.LadderHead;
                    txtladderTail4.Location = ladder4.LadderTail;

      
                    break;

                case "5":


                    ladder1.LadderHead = Logic.SetRandomPositionForHead(ladder1.LadderHead);
                    ladder1.LadderTail = Logic.SetRandomPositionForTail(ladder1.LadderTail);
                    while (Ladder.CheckLadder(ladder1) != true)
                    {
                        ladder1.LadderHead = Logic.SetRandomPositionForHead(ladder1.LadderHead);
                        ladder1.LadderTail = Logic.SetRandomPositionForTail(ladder1.LadderTail);
                    }

                    Logic.PointList.Add(ladder1.LadderHead);
                    Logic.PointList.Add(ladder1.LadderTail);


                    ladder2.LadderHead = Logic.SetRandomPositionForHead(ladder2.LadderHead);
                    ladder2.LadderTail = Logic.SetRandomPositionForTail(ladder2.LadderTail);
                    while (Ladder.CheckLadder(ladder2) != true)
                    {
                        ladder2.LadderHead = Logic.SetRandomPositionForHead(ladder2.LadderHead);
                        ladder2.LadderTail = Logic.SetRandomPositionForTail(ladder2.LadderTail);
                    }

                    Logic.PointList.Add(ladder2.LadderHead);
                    Logic.PointList.Add(ladder2.LadderTail);

                    ladder3.LadderHead = Logic.SetRandomPositionForHead(ladder3.LadderHead);
                    ladder3.LadderTail = Logic.SetRandomPositionForTail(ladder3.LadderTail);
                    while (Ladder.CheckLadder(ladder3) != true)
                    {
                        ladder3.LadderHead = Logic.SetRandomPositionForHead(ladder3.LadderHead);
                        ladder3.LadderTail = Logic.SetRandomPositionForTail(ladder3.LadderTail);
                    }

                    Logic.PointList.Add(ladder3.LadderHead);
                    Logic.PointList.Add(ladder3.LadderTail);

                    ladder4.LadderHead = Logic.SetRandomPositionForHead(ladder4.LadderHead);
                    ladder4.LadderTail = Logic.SetRandomPositionForTail(ladder4.LadderTail);
                    while (Ladder.CheckLadder(ladder4) != true)
                    {
                        ladder4.LadderHead = Logic.SetRandomPositionForHead(ladder4.LadderHead);
                        ladder4.LadderTail = Logic.SetRandomPositionForTail(ladder4.LadderTail);
                    }
                    Logic.PointList.Add(ladder4.LadderHead);
                    Logic.PointList.Add(ladder4.LadderTail);

                    ladder5.LadderHead = Logic.SetRandomPositionForHead(ladder5.LadderHead);
                    ladder5.LadderTail = Logic.SetRandomPositionForTail(ladder5.LadderTail);
                    while (Ladder.CheckLadder(ladder5) != true)
                    {
                        ladder5.LadderHead = Logic.SetRandomPositionForHead(ladder5.LadderHead);
                        ladder5.LadderTail = Logic.SetRandomPositionForTail(ladder5.LadderTail);
                    }
                    Logic.PointList.Add(ladder5.LadderHead);
                    Logic.PointList.Add(ladder5.LadderTail);

                    Logic.LadderList.Add(ladder1);
                    Logic.LadderList.Add(ladder2);
                    Logic.LadderList.Add(ladder3);
                    Logic.LadderList.Add(ladder4);
                    Logic.LadderList.Add(ladder5);


                    txtladderHead1.Location = ladder1.LadderHead;
                    txtladderTail1.Location = ladder1.LadderTail;
         

                    txtladderHead2.Location = ladder2.LadderHead;
                    txtladderTail2.Location = ladder2.LadderTail;
                   
                    txtladderHead3.Location = ladder3.LadderHead;
                    txtladderTail3.Location = ladder3.LadderTail;
           

                    txtladderHead4.Location = ladder4.LadderHead;
                    txtladderTail4.Location = ladder4.LadderTail;
               

                    txtladderHead5.Location = ladder5.LadderHead;
                    txtladderTail5.Location = ladder5.LadderTail;
               
                    break;
            }
            switch (cbNumOfSnake.Text)
            {
                case "1":

                    snake1.SnakeHead = Logic.SetRandomPositionForHead(snake1.SnakeHead);
                    snake1.SnakeTail = Logic.SetRandomPositionForTail(snake1.SnakeTail);
                    while (Snake.CheckSnake(snake1) != true)
                    {
                        snake1.SnakeHead = Logic.SetRandomPositionForHead(snake1.SnakeHead);
                        snake1.SnakeTail = Logic.SetRandomPositionForTail(snake1.SnakeTail);
                    }


                    Logic.PointList.Add(snake1.SnakeHead);
                    Logic.PointList.Add(snake1.SnakeTail);

                    Logic.SnakeList.Add(snake1);

                    txtsnakeHead1.Location = snake1.SnakeHead;
                    txttailSnake1.Location = snake1.SnakeTail;

                    break;

                case "2":


                    snake1.SnakeHead = Logic.SetRandomPositionForHead(snake1.SnakeHead);
                    snake1.SnakeTail = Logic.SetRandomPositionForTail(snake1.SnakeTail);
                    while (Snake.CheckSnake(snake1) != true)
                    {
                        snake1.SnakeHead = Logic.SetRandomPositionForHead(snake1.SnakeHead);
                        snake1.SnakeTail = Logic.SetRandomPositionForTail(snake1.SnakeTail);
                    }

                    Logic.PointList.Add(snake1.SnakeHead);
                    Logic.PointList.Add(snake1.SnakeTail);

                    snake2.SnakeHead = Logic.SetRandomPositionForHead(snake2.SnakeHead);
                    snake2.SnakeTail = Logic.SetRandomPositionForTail(snake2.SnakeTail);

                    while (Snake.CheckSnake(snake2) != true)
                    {
                        snake2.SnakeHead = Logic.SetRandomPositionForHead(snake2.SnakeHead);
                        snake2.SnakeTail = Logic.SetRandomPositionForTail(snake2.SnakeTail);
                    }

                    Logic.PointList.Add(snake2.SnakeHead);
                    Logic.PointList.Add(snake2.SnakeTail);

                    Logic.SnakeList.Add(snake1);
                    Logic.SnakeList.Add(snake2);

                    txtsnakeHead1.Location = snake1.SnakeHead;
                    txttailSnake1.Location = snake1.SnakeTail;

                    txtsnakeHead2.Location = snake2.SnakeHead;
                    txttailSnake2.Location = snake2.SnakeTail;

                    break;
                case "3":

                    snake1.SnakeHead = Logic.SetRandomPositionForHead(snake1.SnakeHead);
                    snake1.SnakeTail = Logic.SetRandomPositionForTail(snake1.SnakeTail);
                    while (Snake.CheckSnake(snake1) != true)
                    {
                        snake1.SnakeHead = Logic.SetRandomPositionForHead(snake1.SnakeHead);
                        snake1.SnakeTail = Logic.SetRandomPositionForTail(snake1.SnakeTail);
                    }

                    Logic.PointList.Add(snake1.SnakeHead);
                    Logic.PointList.Add(snake1.SnakeTail);

                    snake2.SnakeHead = Logic.SetRandomPositionForHead(snake2.SnakeHead);
                    snake2.SnakeTail = Logic.SetRandomPositionForTail(snake2.SnakeTail);

                    while (Snake.CheckSnake(snake2) != true)
                    {
                        snake2.SnakeHead = Logic.SetRandomPositionForHead(snake2.SnakeHead);
                        snake2.SnakeTail = Logic.SetRandomPositionForTail(snake2.SnakeTail);
                    }

                    Logic.PointList.Add(snake2.SnakeHead);
                    Logic.PointList.Add(snake2.SnakeTail);

                    snake3.SnakeHead = Logic.SetRandomPositionForHead(snake3.SnakeHead);
                    snake3.SnakeTail = Logic.SetRandomPositionForTail(snake3.SnakeTail);
                    while (Snake.CheckSnake(snake3) != true)
                    {
                        snake3.SnakeHead = Logic.SetRandomPositionForHead(snake3.SnakeHead);
                        snake3.SnakeTail = Logic.SetRandomPositionForTail(snake3.SnakeTail);
                    }
                    Logic.PointList.Add(snake3.SnakeHead);
                    Logic.PointList.Add(snake3.SnakeTail);


                    Logic.SnakeList.Add(snake1);
                    Logic.SnakeList.Add(snake2);
                    Logic.SnakeList.Add(snake3);

                    txtsnakeHead1.Location = snake1.SnakeHead;
                    txttailSnake1.Location = snake1.SnakeTail;

                    txtsnakeHead2.Location = snake2.SnakeHead;
                    txttailSnake2.Location = snake2.SnakeTail;

                    txtsnakeHead3.Location = snake3.SnakeHead;
                    txttailSnake3.Location = snake3.SnakeTail;

                    break;
                case "4":

                    snake1.SnakeHead = Logic.SetRandomPositionForHead(snake1.SnakeHead);
                    snake1.SnakeTail = Logic.SetRandomPositionForTail(snake1.SnakeTail);
                    while (Snake.CheckSnake(snake1) != true)
                    {
                        snake1.SnakeHead = Logic.SetRandomPositionForHead(snake1.SnakeHead);
                        snake1.SnakeTail = Logic.SetRandomPositionForTail(snake1.SnakeTail);
                    }

                    Logic.PointList.Add(snake1.SnakeHead);
                    Logic.PointList.Add(snake1.SnakeTail);

                    snake2.SnakeHead = Logic.SetRandomPositionForHead(snake2.SnakeHead);
                    snake2.SnakeTail = Logic.SetRandomPositionForTail(snake2.SnakeTail);

                    while (Snake.CheckSnake(snake2) != true)
                    {
                        snake2.SnakeHead = Logic.SetRandomPositionForHead(snake2.SnakeHead);
                        snake2.SnakeTail = Logic.SetRandomPositionForTail(snake2.SnakeTail);
                    }

                    Logic.PointList.Add(snake2.SnakeHead);
                    Logic.PointList.Add(snake2.SnakeTail);

                    snake3.SnakeHead = Logic.SetRandomPositionForHead(snake3.SnakeHead);
                    snake3.SnakeTail = Logic.SetRandomPositionForTail(snake3.SnakeTail);
                    while (Snake.CheckSnake(snake3) != true)
                    {
                        snake3.SnakeHead = Logic.SetRandomPositionForHead(snake3.SnakeHead);
                        snake3.SnakeTail = Logic.SetRandomPositionForTail(snake3.SnakeTail);
                    }
                    Logic.PointList.Add(snake3.SnakeHead);
                    Logic.PointList.Add(snake3.SnakeTail);

                    snake4.SnakeHead = Logic.SetRandomPositionForHead(snake4.SnakeHead);
                    snake4.SnakeTail = Logic.SetRandomPositionForTail(snake4.SnakeTail);
                    while (Snake.CheckSnake(snake4) != true)
                    {
                        snake4.SnakeHead = Logic.SetRandomPositionForHead(snake4.SnakeHead);
                        snake4.SnakeTail = Logic.SetRandomPositionForTail(snake4.SnakeTail);
                    }
                    Logic.PointList.Add(snake4.SnakeHead);
                    Logic.PointList.Add(snake4.SnakeTail);

                    Logic.SnakeList.Add(snake1);
                    Logic.SnakeList.Add(snake2);
                    Logic.SnakeList.Add(snake3);
                    Logic.SnakeList.Add(snake4);

                    txtsnakeHead1.Location = snake1.SnakeHead;
                    txttailSnake1.Location = snake1.SnakeTail;

                    txtsnakeHead2.Location = snake2.SnakeHead;
                    txttailSnake2.Location = snake2.SnakeTail;

                    txtsnakeHead3.Location = snake3.SnakeHead;
                    txttailSnake3.Location = snake3.SnakeTail;

                    txtsnakeHead4.Location = snake4.SnakeHead;
                    txttailSnake4.Location = snake4.SnakeTail;


                    break;
                case "5":

                    snake1.SnakeHead = Logic.SetRandomPositionForHead(snake1.SnakeHead);
                    snake1.SnakeTail = Logic.SetRandomPositionForTail(snake1.SnakeTail);
                    while (Snake.CheckSnake(snake1) != true)
                    {
                        snake1.SnakeHead = Logic.SetRandomPositionForHead(snake1.SnakeHead);
                        snake1.SnakeTail = Logic.SetRandomPositionForTail(snake1.SnakeTail);
                    }

                    Logic.PointList.Add(snake1.SnakeHead);
                    Logic.PointList.Add(snake1.SnakeTail);

                    snake2.SnakeHead = Logic.SetRandomPositionForHead(snake2.SnakeHead);
                    snake2.SnakeTail = Logic.SetRandomPositionForTail(snake2.SnakeTail);

                    while (Snake.CheckSnake(snake2) != true)
                    {
                        snake2.SnakeHead = Logic.SetRandomPositionForHead(snake2.SnakeHead);
                        snake2.SnakeTail = Logic.SetRandomPositionForTail(snake2.SnakeTail);
                    }

                    Logic.PointList.Add(snake2.SnakeHead);
                    Logic.PointList.Add(snake2.SnakeTail);

                    snake3.SnakeHead = Logic.SetRandomPositionForHead(snake3.SnakeHead);
                    snake3.SnakeTail = Logic.SetRandomPositionForTail(snake3.SnakeTail);
                    while (Snake.CheckSnake(snake3) != true)
                    {
                        snake3.SnakeHead = Logic.SetRandomPositionForHead(snake3.SnakeHead);
                        snake3.SnakeTail = Logic.SetRandomPositionForTail(snake3.SnakeTail);
                    }
                    Logic.PointList.Add(snake3.SnakeHead);
                    Logic.PointList.Add(snake3.SnakeTail);


                    snake4.SnakeHead = Logic.SetRandomPositionForHead(snake4.SnakeHead);
                    snake4.SnakeTail = Logic.SetRandomPositionForTail(snake4.SnakeTail);
                    while (Snake.CheckSnake(snake4) != true)
                    {
                        snake4.SnakeHead = Logic.SetRandomPositionForHead(snake4.SnakeHead);
                        snake4.SnakeTail = Logic.SetRandomPositionForTail(snake4.SnakeTail);
                    }
                    Logic.PointList.Add(snake4.SnakeHead);
                    Logic.PointList.Add(snake4.SnakeTail);

                    snake5.SnakeHead = Logic.SetRandomPositionForHead(snake5.SnakeHead);
                    snake5.SnakeTail = Logic.SetRandomPositionForTail(snake5.SnakeTail);
                    while (Snake.CheckSnake(snake5) != true)
                    {
                        snake5.SnakeHead = Logic.SetRandomPositionForHead(snake5.SnakeHead);
                        snake5.SnakeTail = Logic.SetRandomPositionForTail(snake5.SnakeTail);
                    }
                    Logic.PointList.Add(snake5.SnakeHead);
                    Logic.PointList.Add(snake5.SnakeTail);



                    Logic.SnakeList.Add(snake1);
                    Logic.SnakeList.Add(snake2);
                    Logic.SnakeList.Add(snake3);
                    Logic.SnakeList.Add(snake4);
                    Logic.SnakeList.Add(snake5);

                    txtsnakeHead1.Location = snake1.SnakeHead;
                    txttailSnake1.Location = snake1.SnakeTail;

                    txtsnakeHead2.Location = snake2.SnakeHead;
                    txttailSnake2.Location = snake2.SnakeTail;

                    txtsnakeHead3.Location = snake3.SnakeHead;
                    txttailSnake3.Location = snake3.SnakeTail;

                    txtsnakeHead4.Location = snake4.SnakeHead;
                    txttailSnake4.Location = snake4.SnakeTail;

                    txtsnakeHead5.Location = snake5.SnakeHead;
                    txttailSnake5.Location = snake5.SnakeTail;



                    break;

            }

            //Add 2 gold locations

            Logic.NewGold(txtGold1);
            Logic.NewGold(txtGold2);
            

           




        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
