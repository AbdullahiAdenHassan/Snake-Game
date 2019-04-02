using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstSnakeGame
{
    public partial class SnakeGame : Form
    {
        private List<Shape> Snake = new List<Shape>();
        private Shape food = new Shape();

        public SnakeGame()
        {
            InitializeComponent();

            //Set settings to default
            new Settings();

            //Set game speed and start timer
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateMyScreen;
            gameTimer.Start();

            StartGame();//Start New Game
        }

        private void StartGame()
        {
            lbGameOver.Visible = false;

            // set settings to default 
            new Settings();

            /*Creating a new player object*/
            Snake.Clear();
            Shape Head = new Shape();
            Head.X = 10;
            Head.Y = 5;
            Snake.Add(Head);

            lbScore.Text = Settings.Score.ToString();
            GenerateFood();
        }

        private void GenerateFood()
        {
            int maxXPos = pbGameArea.Size.Width / Settings.Width;
            int maxYPos = pbGameArea.Size.Height / Settings.Height;

            Random random = new Random();
            food = new Shape();
            food.X = random.Next(0, maxXPos);
            food.Y = random.Next(0, maxYPos);
        }

        private void UpdateMyScreen(object sender, EventArgs e)
        {

            if (Settings.GameOver == true)//check for Game over
            {
                if (Input.KeyPressed(Keys.Enter)) //check if Enter is pressed
                {
                    StartGame();
                }
            }
            else // GameOver is false
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != eDirection.LEFT)
                {
                    Settings.direction = eDirection.RIGHT;
                }
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != eDirection.RIGHT)
                {
                    Settings.direction = eDirection.LEFT;
                }
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != eDirection.UP)
                {
                    Settings.direction = eDirection.DOWN;
                }
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != eDirection.DOWN)
                {
                    Settings.direction = eDirection.UP;
                }

                MovePlayer();
            }
            pbGameArea.Invalidate();
        }

        private void MovePlayer()
        {

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //move head
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case eDirection.RIGHT:
                            Snake[i].X++;
                            break;
                        case eDirection.LEFT:
                            Snake[i].X--;
                            break;
                        case eDirection.DOWN:
                            Snake[i].Y++;
                            break;
                        case eDirection.UP:
                            Snake[i].Y--;
                            break;
                    }

                    //Get Maximum X and Y Pos
                    int maxXpos = pbGameArea.Size.Width / Settings.Width;
                    int maxYpos = pbGameArea.Size.Height / Settings.Height;

                    //Detect collission with game borders
                    if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X >= maxXpos || Snake[i].Y >= maxYpos)
                    {
                        Die();
                    }

                    //Detect collission with body
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            Die();
                        }
                    }

                    //Detect collosion with food piece
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        Eat();
                    }

                }
                else
                {
                    //Move body
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void Die()
        {
            Settings.GameOver = true;
        }

        private void Eat()
        {
            //Add body to the snake.
            Shape food = new Shape();
            food.X = Snake[Snake.Count - 1].X;
            food.Y = Snake[Snake.Count - 1].Y;
            Snake.Add(food);

            //Update the score. 
            Settings.Score += Settings.Points;
            lbScore.Text = Settings.Score.ToString();

            GenerateFood();
        }

        private void pbGameArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if (Settings.GameOver == false)
            {
                Brush mySnakeColour;

                for (int i = 0; i < Snake.Count; i++)//Draw head
                {
                    if (i == 0)
                    {
                        mySnakeColour = Brushes.Black;//draw head
                    }
                    else
                    {
                        mySnakeColour = Brushes.Green; // Reset of body
                    }

                    //Draw snake-> black snake.
                    graphics.FillEllipse(mySnakeColour,
                        new Rectangle(Snake[i].X * Settings.Width, Snake[i].Y * Settings.Height,
                        Settings.Width, Settings.Height));

                    //Draw FOOD-> Red apple. 
                    graphics.FillEllipse(Brushes.Red,
                        new Rectangle(food.X * Settings.Width, food.Y * Settings.Height,
                        Settings.Width, Settings.Height));
                }
            }
            else
            {
                string gameOver = "Game over\nYour final score is " + Settings.Score + "\nPress Enter to try again";
                lbGameOver.Text = gameOver;
                lbGameOver.Visible = true;
            }
        }

        private void IsKeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void IsKeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
    }
}
