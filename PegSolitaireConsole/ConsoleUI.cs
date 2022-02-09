using PegSolitaire.Core;
using PegSolitaire.Entity;
using PegSolitaire.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaireConsole
{
    class ConsoleUI
    {
        private Field field;
        //private readonly IScoreService scoreService = new ScoreServiceList();
        private readonly IScoreService scoreService = new ScoreServiceEF();

        //private readonly ICommentService commentService = new CommentServiceList();
        private readonly ICommentService commentService = new CommentServiceEF();

        //private readonly IRatingService ratingService = new RatingServiceList();
        private readonly IRatingService ratingService = new RatingServiceEF();

        string user_Name;

        public void Run()
        {
            scoreService.GetTopScores();
            commentService.GetComment();
            ratingService.GetAverageRating();

            Console.Write("Hi, what your name?\n");
            user_Name = Console.ReadLine();
            ChooseMap();

            while (!field.IsSolved() && !field.IsLosed())
            {
                ProcessInput();
                Console.WriteLine("***************************************");
                PrintField();
            }

            if (field.IsSolved())
            {
                Console.WriteLine("***************************************");
                Console.WriteLine("-----------Game solved!-----------");
                Console.WriteLine("***************************************\n");
                scoreService.AddScore(new Score { Name = user_Name, Points = field.GetScore() });
            }
            else if (field.IsLosed())
            {

                Console.WriteLine("***************************************");
                Console.WriteLine("-----------Game losed!-----------");
                Console.WriteLine("***************************************\n");
            }

            Service();


            Console.WriteLine("Want to play one more time? (y/n)");
            var input = Console.ReadLine().ToUpper();
            if (input == "Y" || input == "YES")
            {
                Run();
            }

        }

        private void ProcessInput()
        {
            Console.WriteLine("Enter a tile coordinate to move and direction \n" +
                              "(A - left, W - up, S - down, D - right): \n" +
                              "row column direction (e.g. 12A, E - exit)");
            string s = Console.ReadLine().ToUpper();

            if (s == "E")
                Environment.Exit(0);


            if (s.Length == 3)
            {
                try
                {
                    int row = Convert.ToInt32(s.Substring(0, 1));
                    int column = Convert.ToInt32(s.Substring(1, 1));
                    char direction = Convert.ToChar(s.Substring(2));

                    var tile = field.GetTile(row, column);
                    if (tile != State.OPENED)
                    {
                        PrintError("Enter valid tile coordinate!\n");
                        ProcessInput();
                    }
                    else if (direction != 'A' && direction != 'W' && direction != 'S' && direction != 'D')
                    {
                        PrintError("Enter valid direction!\n");
                        ProcessInput();
                    }
                    else if (!field.MoveTile(row, column, direction))
                    {
                        PrintError("Cannot be moved\n");
                        ProcessInput();
                    }
                }
                catch
                {
                    PrintError("Сonversion error");
                    ProcessInput();
                }
            }
            else
            {
                PrintError("Bad input!\n");
                ProcessInput();
            }
        }

        private void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintField()
        {
            Console.Write("  ");
            for (var i = 0; i < field.ColumnCount; i++)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();

            for (var row = 0; row < field.RowCount; row++)
            {
                Console.Write(row + "| ");
                for (var column = 0; column < field.ColumnCount; column++)
                {
                    var tile = field.GetTile(row, column);
                    if (tile == State.CLOSED)
                    {
                        Console.Write("-");
                    }
                    else if (tile == State.EATEN)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void Service()
        {
            PrintScores();


            Console.Write("Leave a comment: ");
            var Comment = Console.ReadLine();
            commentService.AddComment(new Comment { Name = user_Name, Comments = Comment });
            PrintComments();


            int rating = 0;
            while (rating > 5 || rating < 1)
            {
                Console.Write("Leave a rating (1-5): ");
                var input = Console.ReadLine();
                if (input.Length == 1)
                {
                    try
                    {
                        rating = Convert.ToInt32(input);
                    }
                    catch
                    {
                        PrintError("Сonversion error");
                    }
                }

                if (rating > 5 || rating < 1)
                    PrintError("Sorry invalid value");
            }

            ratingService.AddOrSetRating(new Rating { Name = user_Name, Rating_player = rating });
            PrintRating();
        }

        private void ChooseMap()
        {
            Console.WriteLine("\nPossible game maps\n");
            Console.WriteLine("Map 1:");
            field = new Field(1);
            PrintField();

            Console.WriteLine("Map 2:");
            field = new Field(2);
            PrintField();

            Console.WriteLine("Map 3:");
            field = new Field(3);
            PrintField();

            Console.WriteLine("Map 4:");
            field = new Field(4);
            PrintField();

            Console.WriteLine("Map 5:");
            field = new Field(5);
            PrintField();

            Console.WriteLine("Map 6:");
            field = new Field(6);
            PrintField();


            int maps = 0;
            while (maps < 1 || maps > 6)
            {
                Console.Write("Choose map: ");
                var input = Console.ReadLine();
                if (input.Length == 1)
                {
                    try
                    {
                        maps = Convert.ToInt32(input);
                    }
                    catch
                    {
                        PrintError("Сonversion error");
                    }
                }

                if (maps < 1 || maps > 6)
                    PrintError("Bad input");
            }

            field = new Field(maps);
            Console.WriteLine("\n***************************************");
            PrintField();

        }

        private void PrintScores()
        {
            var scores = scoreService.GetTopScores();
            Console.WriteLine("Top scores");
            int index = 1;
            foreach (var score in scores)
            {
                Console.WriteLine("{0}. {1,-12} {2,4}", index, score.Name, score.Points);
                index++;
            }
            Console.WriteLine();
        }

        private void PrintRating()
        {
            double ratingAverage = ratingService.GetAverageRating();
            Console.Write("Average rating: ");
            Console.WriteLine(Math.Round(ratingAverage, 2));

            var ratings = ratingService.GetRatings();
            Console.WriteLine("Ratings");
            int index = 1;
            foreach (var rating in ratings)
            {
                Console.WriteLine("{0}. {1,-12} {2,4}", index, rating.Name, rating.Rating_player);
                index++;
            }
            Console.WriteLine();
        }

        private void PrintComments()
        {
            var comments = commentService.GetComment();
            Console.WriteLine("Comments");
            int index = 1;
            foreach (var comment in comments)
            {
                Console.WriteLine("{0}. {1,-12} {2,4}", index, comment.Name, comment.Comments);
                index++;
            }
            Console.WriteLine();
        }

    }
}
