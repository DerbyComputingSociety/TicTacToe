using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int player = 1;
    static int choice;
    static int flag = 0;

    private static int CheckGameOver(char[] board)
    {
        // Check rows
        if ((board[1] == board[2] && board[2] == board[3]) ||
            (board[4] == board[5] && board[5] == board[6]) ||
            (board[7] == board[8] && board[8] == board[9]))
            return 1;
        
        // Check columns
        if ((board[1] == board[4] && board[4] == board[7]) ||
           (board[2] == board[5] && board[5] == board[8]) || 
           (board[3] == board[6] && board[6] == board[9]))
            return 1;
        
       // Check Diagonals
        if ((board[1] == board[5] && board[5] == board[9]) ||
            (board[3] == board[5] && board[5] == board[7]))
            return 1;
        
        // Check For Draw
        if (board[1] != '1' && board[2] != '2' && board[3] != '3' && board[4] != '4' && board[5] != '5' && board[6] != '6' && board[7] != '7' && board[8] != '8' && board[9] != '9')
            return -1;
        
        return 0;
    }
    private static void DrawBoard(char[] board)
    {
        Console.WriteLine("   |   |  ");
        Console.WriteLine(" {0} | {1} | {2}", board[1], board[2], board[3]);
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |  ");
        Console.WriteLine(" {0} | {1} | {2}", board[4], board[5], board[6]);
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |  ");
        Console.WriteLine(" {0} | {1} | {2}", board[7], board[8], board[9]);
        Console.WriteLine("   |   |  ");
    }
    static void Main(string[] args)
    {
        var board = new char[] { 
            '0', 
            '1', '2', '3', 
            '4', '5', '6', 
            '7', '8', '9'
        };

        do
        {
            Console.Clear();
            Console.WriteLine("Player1:X and Player2:O");
            Console.WriteLine();
            if (player % 2 == 0)
            {
                Console.WriteLine("Player 2 Chance");
            }
            else
            {
                Console.WriteLine("Player 1 Chance");
            }
            Console.WriteLine();
            DrawBoard(board);
            choice = int.Parse(Console.ReadLine());

            while (choice > 9 || choice < 0)
            {
                Console.WriteLine("That is an invalid number, please try again: ");
                choice = int.Parse(Console.ReadLine());
            }

            if (board[choice] != 'X' && board[choice] != 'O')
            {
                if (player % 2 == 0)
				{
                    board[choice] = '0';
                    player++;
                }
                else
                {
                    board[choice] = 'X';
                    player++;
                }

            }
            else
            {
                Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, board[choice]);
                Console.WriteLine();

            }
            flag = CheckGameOver(board);
        }
        while (flag != 1 && flag != -1);

        Console.Clear();
        DrawBoard(board);
        if (flag == 1)
        {
            Console.WriteLine("Player {0} has won", (player % 2) + 1);
        }
        else
        {
            Console.WriteLine("Draw");
        }
        Console.ReadLine();

    }
}
