using System;

public class Game {
	char[] _board = {
        ' ',
    	'1', '2', '3',
    	'4', '5', '6',
    	'7', '8', '9'
    };
	char[] _playerSymbols = { 'X', 'O' };
    int _currentPlayer;

    public void Run() {
        int flag = 0;

        while (flag == 0) {
			Console.Clear();
			
			Console.WriteLine("Player1:X and Player2:O");
			Console.WriteLine();
			if (_currentPlayer == 0) {
				Console.WriteLine("Player 1 Chance");
			} else {
				Console.WriteLine("Player 2 Chance");
			}
			Console.WriteLine();
			DrawBoard(_board);
			var choice = int.Parse(Console.ReadLine());
			
			while (choice > 9 || choice < 0) {
				Console.WriteLine("That is an invalid number, please try again: ");
				choice = int.Parse(Console.ReadLine());
			}
			
			if (_board[choice] != 'X' && _board[choice] != 'O') {
				_board[choice] = _playerSymbols[_currentPlayer];
			} else {
				Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, _board[choice]);
				Console.WriteLine();
			}
			flag = CheckGameOver(_board);
            if (flag != 0)
                break;
            
            _currentPlayer = _currentPlayer == 0 ? 1 : 0;
        }

		Console.Clear();
		DrawBoard(_board);
		if (flag == 1) {
			Console.WriteLine("Player {0} has won", _currentPlayer + 1);
		} else {
			Console.WriteLine("Draw");
		}
		Console.ReadLine();
	}

	void DrawBoard(char[] board) {
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

	private int CheckGameOver(char[] board) {
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
}

