using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[][] board = new int[][]
            //{
            //    new int[]{ 7,3,5,6,1,4,8,9,2 },
            //    new int[]{ 8,4,2,9,7,3,5,6,1 },
            //    new int[]{ 9,6,1,2,8,5,3,7,4 },
            //    new int[]{ 2,8,6,3,4,9,1,5,7 },
            //    new int[]{ 4,1,3,8,5,7,9,2,6 },
            //    new int[]{ 5,7,9,1,2,6,4,3,8 },
            //    new int[]{ 1,5,7,4,9,2,6,8,3 },
            //    new int[]{ 6,9,4,7,3,8,2,1,5 },
            //    new int[]{ 3,2,8,5,6,1,7,4,9 }
            //};

            int[][] board = new int[][]
            {
                new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9},
                new int[]{ 2, 3, 1, 5, 6, 4, 8, 9, 7},
                new int[]{ 3, 1, 2, 6, 4, 5, 9, 7, 8},
                new int[]{ 4, 5, 6, 7, 8, 9, 1, 2, 3},
                new int[]{ 5, 6, 4, 8, 9, 7, 2, 3, 1},
                new int[]{ 6, 4, 5, 9, 7, 8, 3, 1, 2},
                new int[]{ 7, 8, 9, 1, 2, 3, 4, 5, 6},
                new int[]{ 8, 9, 7, 2, 3, 1, 5, 6, 4},
                new int[]{ 9, 7, 8, 3, 1, 2, 6, 4, 5}
            };

            Console.WriteLine($"Player Won: {IsBoardCorrect(board)}");
        }

        static bool IsBoardCorrect(int[][] board)
        {
            bool playerWon = true;

            for (int i = 0; i < board.Length; i++)
            {
                var set = new HashSet<int>(board[i]);
                if (set.Count != board[i].Length)//player repeated the same number in a row
                {
                    playerWon = false;
                    break;
                }

                bool isOutOfRange = set.Any(number => number <= 0 || number > 9);
                if (isOutOfRange)//player entered 0 or negative or other number greater than 9
                {
                    playerWon = false;
                    break;
                }

                //store the board vertically
                var flippedSet = new HashSet<int>();
                for (int j = 0; j < board[i].Length; j++)
                {
                    flippedSet.Add(board[j][i]);
                }
                if (flippedSet.Count != board.Length)
                {
                    playerWon = false;
                    break;
                }

                //section check
                if (i % 3 == 0 && i < board.Length - 1)
                {
                    set.Clear();
                    for (int j = i; j < i + 3; j++)
                    {
                        for (int k = i; k < i + 3; k++)
                        {
                            set.Add(board[j][k]);
                        }
                    }
                    if (set.Count != board[i].Length)
                    {
                        playerWon = false;
                        break;
                    }
                }
            }

            return playerWon;
        }
    }
}
