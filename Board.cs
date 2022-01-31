namespace TicTacToe
{
    public class Board
    {
        private string[] board = new string[] {"1", "2", "3", "4", "5", "6", "7" , "8", "9"};

        // Basically displays the board to the console.
        public void ShowBoard()
        {
            Console.WriteLine("-------------");
            for (int pos = 1; pos < 10; pos++)
            {
                Console.Write($"| {board[pos-1]} ");
                if ((pos > 0) && (pos % 3 == 0))
                {
                    Console.Write("|");
                    Console.WriteLine();
                    Console.WriteLine("-------------");
                }
            }
        }

        // Checks if someone won or not.
        public string Check()
        {
            for (int pos = 0; pos < 3; pos++)
            {
                if ((board[pos] == board[pos+3]) && (board[pos+3] == board[pos+6]))
                {
                    return board[pos];
                }
            }
            for (int pos = 0; pos <= 6; pos += 3)
            {
                if ((board[pos] == board[pos+1]) && (board[pos+1] == board[pos+2]))
                {
                    return board[pos];
                }
            }
            if ((board[0] == board[4]) && (board[4] == board[8]))
            {
                return board[0];
            } 
            else if ((board[2] == board[4]) && (board[4] == board[6]))
            {
                return board[2];
            }
            return "";
        }

        // Checks if board is full
        public bool IsFull()
        {
            foreach (string cell in board)
            {
                if (!(cell == "X" || cell == "O"))
                {
                    return false;
                }
            }
            return true; 
        }

        // Inserts either X or O to the board. 
        // Throws an exception if the player is stupid enough to make a mistake. 
        public void Insert(int pos, string mark)
        {
            if (board[pos-1] == "X" || board[pos-1] == "O")
            {
                throw new ArgumentException();
            }

            if (!(0 < pos) && (pos < 10))
            {
                throw new IndexOutOfRangeException();
            }
            board[pos-1] = mark;
        }
    }
}