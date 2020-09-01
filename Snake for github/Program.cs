using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake_Game
{
    class Program
    {
        /*
         * This is a simple console snake game
         * I have literally no reason for coding this
         */
        enum Compass
        {
            North,East,South,West
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your difficulty");
            int difficulty = Convert.ToInt32(Console.ReadLine());
            Game(difficulty);


        }

        static void Game(int difficulty)
        {
            uint[] map = new uint[120];
            uint apple;
            int score = 0;
            apple = RandomNumber(10, 110);
            List<uint> snake;
            snake = new List<uint> { 50 };
            snake[0] = 50;
            //i've decided that index 0 will be the head of the snake
            bool finished = false;
            Compass heading;
            heading = Compass.East;
            while (finished == false)
            {
                heading = UserDirection(heading, difficulty);

                snake = ApplyMovement(snake, heading, apple);

                if(snake[0] == apple)
                {
                    //after eating the apple the score increases and the apple is place somewhere else
                    score++;
                    apple = RandomNumber(10, 110);
                }
                for(int i = 1; i < snake.Count - 1; i++)
                {
                    //if the snake hits his tail its game over
                    if (snake.Count > 1)
                    {
                        if (snake[0] == snake[i])
                        {
                            finished = true;
                        }
                    }
                }
                Console.Clear();
                DisplayScreen(snake, score, apple);
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Gamer over!");
        }

        static void DisplayScreen(List<uint> snake, int score, uint apple)
        {
            bool snakeUnit = false;
            bool appleUnit = false;

            for(uint i = 10; i < 110; i++)
            {
                appleUnit = false;
                if (i == apple)
                {
                    appleUnit = true;
                }
                snakeUnit = false;
                for(int j = 0; j < snake.Count; j++)
                {
                    if (snake[j] == i)
                    {
                        snakeUnit = true;
                    }
                }
                if ((i % 10) == 0)
                {
                    Console.WriteLine();
                }
                if (snakeUnit == true)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("O");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (appleUnit == true)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("A");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.Write("X");
                }
                Console.Write(" ");

            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(score);
            Console.WriteLine(snake[0]);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static List<uint> ApplyMovement(List<uint> snake, Compass heading, uint apple)
        {
            // using Compass;
            int lastMember = snake.Count - 1;
            uint headTemp = snake[0];
            uint tailTemp = snake[lastMember];
            switch (heading)
            {
                case (Compass.North):
                    snake[0] = snake[0] - 10;
                    break;
                case (Compass.East):
                    snake[0] = snake[0] + 1;
                    break;
                case (Compass.South):
                    snake[0] = snake[0] + 10;
                    break;
                case (Compass.West):
                    snake[0] = snake[0] - 1;
                    break;
            }
            if (snake[0] > 110)
            {
                snake[0] = snake[0] - 100;
            }else if(snake[0] < 10)
            {
                snake[0] = snake[0] + 100;
            }
            for(int i = lastMember; i > 1; i--)
            {
                snake[i] = snake[i - 1];
            }
            if(snake.Count > 1)
            {
                snake[1] = headTemp;
            }
            if(snake[0] == apple)
            {
                snake.Add(tailTemp);
            } 
            return snake;
        }
        static Compass UserDirection(Compass heading, int difficulty)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
               // Console.WriteLine("Read key: " + key.KeyChar);
                switch (key.KeyChar.ToString())
                {
                    case ("w"):
                        if (heading != Compass.South)
                        {
                            heading = Compass.North;
                        }
                        break;
                    case ("a"):
                        if (heading != Compass.East)
                        {
                            heading = Compass.West;
                        }
                        break;
                    case ("s"):
                        if (heading != Compass.North)
                        {
                            heading = Compass.South;
                        }
                        break;
                    case ("d"):
                        if (heading != Compass.West)
                        {
                            heading = Compass.East;
                        }
                        break;
                }
            }
            Thread.Sleep(500 / difficulty);
            return heading;
        }
   
        static uint RandomNumber(int min, int max)
        {
            Random rand = new Random();
            return (uint)rand.Next(min, max);
        }



    }
}
