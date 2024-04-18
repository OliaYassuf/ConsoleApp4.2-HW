using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.GameLogic
{

    public class TicTacToeGame
    {
        private readonly char[,] board;
        private readonly Player player1;
        private readonly Player player2;
        private bool player1Turn;

        public TicTacToeGame(char player1Symbol, char player2Symbol, bool player2IsComputer)
        {
            board = new char[3, 3];
            player1 = new Player(player1Symbol, false);
            player2 = new Player(player2Symbol, player2IsComputer);
            player1Turn = new Random().Next(2) == 0;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            DisplayBoard();

            while (!IsGameOver())
            {
                if (player1Turn)
                {
                    player1.MakeMove(board);
                }
                else
                {
                    player2.MakeMove(board);
                }

                DisplayBoard();
                player1Turn = !player1Turn;
            }

            if (CheckForWinner())
            {
                Console.WriteLine(player1Turn ? "Player 2 wins!" : "Player 1 wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }


        private void DisplayBoard()
        {
            Console.WriteLine("  1 2 3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + 1 + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private bool IsGameOver()
        {
            return CheckForWinner() || IsBoardFull();
        }

        private bool CheckForWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != ' ')
                {
                    return true;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == board[1, j] && board[1, j] == board[2, j] && board[0, j] != ' ')
                {
                    return true;
                }
            }

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ')
            {
                return true;
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != ' ')
            {
                return true;
            }

            return false;
        }

        private bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
