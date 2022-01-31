namespace TicTacToe
{
    class Program
    {

        // This method right here is the reason why the player can insert X or O to the tictactoe board.
        static void Insert(Board gameBoard, string marker)
        {
            while (true)
            {
                Console.Write($"Pick a position from 1-9 only (For {marker} only!): ");
                string? posInput = Console.ReadLine();
                if (string.IsNullOrEmpty(posInput))
                {
                    continue;
                }
                try 
                {
                    int pos = int.Parse(posInput.Trim());
                    gameBoard.Insert(pos, marker);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("It must be a NUMBER.");
                    continue;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("That position is already taken.");
                    continue;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("It must be from 1-9 ONLY.");
                    continue;
                }
            }
        }

        // Basically chooses who plays first.
        static string FirstPlayer()
        {
            Random random = new Random();
            if (random.Next(0,2) == 0)
            {
                return "X";
            }
            return "O";
        }

        // Obviously this is where the game begins. (What else could it be.)
        static void Game()
        {
            Board gameBoard = new Board();
            string marker = FirstPlayer();
            Console.WriteLine($"{marker} will be the first to play.");
            while (true)
            {
                string winner = gameBoard.Check();
                gameBoard.ShowBoard();
                if (!(string.IsNullOrEmpty(winner)))
                {
                    Console.WriteLine($"{winner} is the WINNER!");
                    break;
                }
                else if (gameBoard.IsFull())
                {
                    Console.WriteLine("No one won.");
                    break;
                }
                Insert(gameBoard, marker);
                if (marker == "X")
                {
                    marker = "O";
                }
                else 
                {
                    marker = "X";
                }
            }
        }

        // Entrypoint of the program.  
        static void Main()
        {
            // Got this from https://patorjk.com/software/taag/#p=display&f=Graffiti&t=C%23%20Tic%20Tac%20Toe
            Console.WriteLine("_________    _  _    ___________.__         ___________               ___________");
            Console.WriteLine(@"\_   ___ \__| || |__ \__    ___/|__| ____   \__    ___/____    ____   \__    ___/___   ____");
            Console.WriteLine(@"/    \  \/\   __   /   |    |   |  |/ ___\    |    |  \__  \ _/ ___\    |    | /  _ \_/ __ \");
            Console.WriteLine(@"\     \____|  ||  |    |    |   |  \  \___    |    |   / __ \\  \___    |    |(  <_> )  ___/");
            Console.WriteLine(@" \______  /_  ~~  _\   |____|   |__|\___  >   |____|  (____  /\___  >   |____| \____/ \___  >");
            Console.WriteLine(@"        \/  |_||_|                      \/                 \/     \/                      \/ ");
            Console.WriteLine();
            Game();
        }
    }
}