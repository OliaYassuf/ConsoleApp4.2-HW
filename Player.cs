using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.GameLogic
{
    public class Player
    {
        public char Symbol { get; }
        public bool IsComputer { get; }

        public Player(char symbol, bool isComputer)
        {
            Symbol = symbol;
            IsComputer = isComputer;
        }

        public void MakeMove(char[,] board)
        {
            if (IsComputer)
            {
                MakeComputerMove(board);
            }
            else
            {
                MakeHumanMove(board);
            }
        }

        private void MakeComputerMove(char[,] board)
        {
            Random random = new Random();
            int row, col;
            do
            {
                row = random.Next(0, 3);
                col = random.Next(0, 3);
            } while (!IsValidMove(board, row, col));

            board[row, col] = Symbol;
        }

        private void MakeHumanMove(char[,] board)
        {
            int row = 0, col = 0;
            bool validInput = false;
            do
            {
                Console.WriteLine($"Player {Symbol}, enter your move (row [1-3] column [1-3]):");
                string input = Console.ReadLine();
                string[] inputParts = input.Split();
                if (inputParts.Length == 2 && int.TryParse(inputParts[0], out row) && int.TryParse(inputParts[1], out col))
                {
                    row--;
                    col--;
                    if (IsValidMove(board, row, col))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input format. Please enter two numbers separated by a space.");
                }
            } while (!validInput);

            board[row, col] = Symbol;
        }

        private bool IsValidMove(char[,] board, int row, int col)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3)
            {
                Console.WriteLine("Invalid move. Row and column should be in range [1-3].");
                return false;
            }
            if (board[row, col] != ' ')
            {
                Console.WriteLine("Invalid move. Cell is already occupied.");
                return false;
            }
            return true;
        }
    }
}