﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace TicTacToeStyrta
{
    public class GameLogic
    {
        public string CurrentPlayer = x;
        private const string x = "X";
        private const string o = "O";
        private string[,] Board = new string[3, 3];
        public int moves = 0;
        public bool stillPlaying = true;

        public void SetNextPlayer()
        {
            if (CurrentPlayer == x)
            {
                CurrentPlayer = o;
            }
            else
            {
                CurrentPlayer = x;
            }
        }
        public bool PlayerWin()
        {
            moves++;
            //horizontal
            for (var i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(Board[i, 0]))
                {
                    if (Board[i, 0] == Board[i, 1] && Board[i, 0] == Board[i, 2])
                    {
                        return true;
                    }
                }
            }

            //columns
            for (var i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(Board[0, i]))
                {
                    if (Board[0, i] == Board[1, i] && Board[0, i] == Board[2, i])
                    {
                        return true;
                    }
                }
            }

            if (!String.IsNullOrWhiteSpace(Board[1, 1]))
            {
                if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
                {
                    return true;
                }

                if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
                {
                    return true;
                }
            }
 
            return false;
        }

        public void UpdateBoard(Position position, string value)
        {
            Board[position.x, position.y] = value;
        }
    }
}
