using System.Threading;
namespace TicTacToeGameConsole
    //<Морски шах>1
{
        using System;
    class Program
    {
        static void Main(string[] args)
        {
            int gameStatus = 0;
            int currentPlayer = -1;
            char[] gameMarkers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            do
            {
                Console.Clear();
                currentPlayer = GetNextPlayer(currentPlayer);
                HeadsUpDisplay(currentPlayer);
                DrawGameboard(gameMarkers);
                GameEngine(gameMarkers, currentPlayer);
                gameStatus = CheckWinner(gameMarkers);
            } while (gameStatus.Equals(0));
            Console.Clear();
            HeadsUpDisplay(currentPlayer);
            DrawGameboard(gameMarkers);
            Console.CursorVisible = false;
            BuildBoundries();
            if (gameStatus.Equals(1))
            {
                Console.WriteLine($"Играч {currentPlayer} е победител!");
            }
            if (gameStatus.Equals(2))
            {
                Console.WriteLine($"Играта е наравно!");
            }
        }

        private static int CheckWinner(char[] gameMarkers)
        {
            if (IsGameDraw(gameMarkers))
            {
                return 2;
            }
            if (IsGameWinner(gameMarkers))
            {
                return 1;
            }
            if (IsGameDraw(gameMarkers))
            {
                return 2;
            }

            return 0;
        }

        private static bool IsGameDraw(char[] gameMarkers)
        {
            return
                
                gameMarkers[0] != '1' &&
                gameMarkers[1] != '2' &&
                gameMarkers[2] != '3' &&
                gameMarkers[3] != '4' &&
                gameMarkers[4] != '5' &&
                gameMarkers[5] != '6' &&
                gameMarkers[6] != '7' &&
                gameMarkers[7] != '8' &&
                gameMarkers[8] != '9';
            
        }
        private static bool IsGameWinner(char[] gameMarkers)
        {
            if (IsGameMarkersTheSame(gameMarkers, 0, 1, 2))
            {
                return  true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 3, 4, 5))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 6, 7, 8))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 0, 3, 6))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 1, 4, 7))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 2, 5, 8))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 0, 4, 8))
            {
                return true;
            }
            if (IsGameMarkersTheSame(gameMarkers, 2, 4, 6))
            {
                return true;
            }
            return false;
        }
        private static bool IsGameMarkersTheSame(char[] testGameMarkers, int pos1, int pos2, int pos3)
        {
            return testGameMarkers[pos1].Equals(testGameMarkers[pos2]) && testGameMarkers[pos2].Equals(testGameMarkers[pos3]);
        }
        private static void GameEngine(char[] gameMarkers, int currentPlayer)
        {
            bool notValidMove = true;
            do
            {
                string userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput) &&
                    (userInput.Equals("1") ||
                    userInput.Equals("2") ||
                    userInput.Equals("3") ||
                    userInput.Equals("4") ||
                    userInput.Equals("5") ||
                    userInput.Equals("6") ||
                    userInput.Equals("7") ||
                    userInput.Equals("8") ||
                    userInput.Equals("9")))
                {
                    int.TryParse(userInput, out int gamePlacementMarker);
                    char currentMarker = gameMarkers[gamePlacementMarker - 1];
                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Мястото е заето , Моля изберете друго!");
                    }
                    else
                    {
                        gameMarkers[gamePlacementMarker - 1] = GetPlayerMarker(currentPlayer);
                        notValidMove = false;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Невалидна стойност"); 
                }
            } while (notValidMove);
        }
        private static char GetPlayerMarker(int player)
        {

            if (player % 2 == 0)
            {
                return 'o';
            }
            return 'x'; 
        }
             private static void BuildBoundries()
        {
            for (int i = 1; i < 40; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(70, i);
                Console.Write("#");
            }
            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                Console.SetCursorPosition(i, 40);
                Console.Write("#");
            }
        }
        static void HeadsUpDisplay(int PlayerNumber)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(" ");
                //Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(" Дбре дошли в Първата версия на МОРСКИ ШАХ");
                //Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(" Играч 1: X");
                //Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(" Играч 2: O");
                //Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($" Играч {PlayerNumber} , за да се движите , моля изберете между числата от 1 до 9.");
                //Thread.Sleep(100);
            }
        }
        static void DrawGameboard(char[] gameMarkers)
        {      
                    Console.ForegroundColor = ConsoleColor.Yellow;
            {
                Console.WriteLine(" ╔═══╦═══╦═══╗");
                Console.WriteLine($" ║ {gameMarkers[0]} ║ {gameMarkers[1]} ║ {gameMarkers[2]} ║");
                Console.WriteLine(" ╠═══╬═══╬═══╣");
                Console.WriteLine($" ║ {gameMarkers[3]} ║ {gameMarkers[4]} ║ {gameMarkers[5]} ║ ");
                Console.WriteLine(" ╠═══╬═══╬═══╣");
                Console.WriteLine($" ║ {gameMarkers[6]} ║ {gameMarkers[7]} ║ {gameMarkers[8]} ║");
                Console.WriteLine(" ╚═══╩═══╩═══╝");
            }
        }
        static int GetNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }
            return 1;
        }
    }
}
