using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConnectFOUR
{
    class Player
    {
        public static bool PlayerOneTurn = true;
        public static bool PlayerTwoTurn=false;
        public static int playerOneCount = 0;
        public static int playerTwoCount = 0;

        public static bool checkWinner = false;
        public static Game.cell cCell;

        public static bool winningPlayer()
        {
            for (int i = Game.boardCell.GetLength(0) - 1; i >= 0; i--)
            {

                for (int j = 0; j < Game.boardCell.GetLength(1); j++)
                {
                    if (j <= 3)
                    {
                        if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i, j + 1].cellColor == Form2.p1 && Game.boardCell[i, j + 2].cellColor == Form2.p1 && Game.boardCell[i, j + 3].cellColor == Form2.p1)
                        {
                            checkWinner = true;
                            return checkWinner;
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i, j + 1].cellColor == Form2.p2 && Game.boardCell[i, j + 2].cellColor == Form2.p2 && Game.boardCell[i, j + 3].cellColor == Form2.p2)
                        {
                            checkWinner = true;
                            return checkWinner;
                        }
                    }
                    if (i >= 3)
                    {
                        if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i - 1, j].cellColor == Form2.p1 && Game.boardCell[i - 2, j].cellColor == Form2.p1 && Game.boardCell[i - 3, j].cellColor == Form2.p1)
                        {
                            checkWinner = true;
                            return checkWinner;
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i - 1, j].cellColor == Form2.p2 && Game.boardCell[i - 2, j].cellColor == Form2.p2 && Game.boardCell[i - 3, j].cellColor == Form2.p2)
                        {
                            checkWinner = true;
                            return checkWinner;
                        }
                    }
                    if (j <= 3 && i >= 3)
                    {
                        if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i - 1, j + 1].cellColor == Form2.p1 && Game.boardCell[i - 2, j + 2].cellColor == Form2.p1 && Game.boardCell[i - 3, j + 3].cellColor == Form2.p1)
                        {
                            checkWinner = true;
                            return checkWinner;
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i - 1, j + 1].cellColor == Form2.p2 && Game.boardCell[i - 2, j + 2].cellColor == Form2.p2 && Game.boardCell[i - 3, j + 3].cellColor == Form2.p2)
                        {
                            checkWinner = true;
                            return checkWinner;
                        }
                    }
                    if (j >= 3 && i >= 3)
                    {

                        if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i - 1, j - 1].cellColor == Form2.p1 && Game.boardCell[i - 2, j - 2].cellColor == Form2.p1 && Game.boardCell[i - 3, j - 3].cellColor == Form2.p1)
                        {
                            checkWinner = true;
                            return checkWinner;
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i - 1, j - 1].cellColor == Form2.p2 && Game.boardCell[i - 2, j - 2].cellColor == Form2.p2 && Game.boardCell[i - 3, j - 3].cellColor == Form2.p2)
                        {
                            checkWinner = true;
                            return checkWinner;
                        }
                    }
                }
            }
            return checkWinner;
        }

        public static Game.cell playerToWin()
        {
            cCell = new Game.cell();
            Game.cell cY = new Game.cell();
            for (int i = Game.boardCell.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < Game.boardCell.GetLength(1); j++)
                {
                    
                    if (j <= 3)
                    {
                        if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i, j + 2].cellColor == Form2.p2 && Game.boardCell[i, j + 3].cellColor == Form2.p2)
                        {
                            if (Game.boardCell[i, j + 1].cellColor == Color.White) 
                            {
                                if (i < 5 && Game.boardCell[i + 1, j + 1].cellColor == Color.White)
                                    break;
                                else
                                cY = Game.boardCell[i, j + 1];
                            }
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i, j + 1].cellColor == Form2.p2 && Game.boardCell[i, j + 3].cellColor == Form2.p2)
                        {
                            if (Game.boardCell[i, j + 2].cellColor == Color.White)
                            {
                                if (i < 5 && Game.boardCell[i + 1, j + 2].cellColor == Color.White)
                                    break;
                                else
                                    cY = Game.boardCell[i, j + 2];
                            }
                        }
                        else   if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i, j + 2].cellColor == Form2.p1 && Game.boardCell[i, j + 3].cellColor == Form2.p1)
                        {
                            if (Game.boardCell[i, j + 1].cellColor == Color.White)
                            {
                                if (i < 5 && Game.boardCell[i + 1, j + 1].cellColor == Color.White)
                                    break;
                                else
                                    cCell = Game.boardCell[i, j + 1];
                            }
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i, j + 1].cellColor == Form2.p1 && Game.boardCell[i, j + 3].cellColor == Form2.p1)
                        {
                            if (Game.boardCell[i, j + 2].cellColor == Color.White)
                            {
                                if (i < 5 && Game.boardCell[i + 1, j + 2].cellColor == Color.White)
                                    break;
                                else
                                    cCell = Game.boardCell[i, j + 2];
                            }
                        }
                        if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i, j + 1].cellColor == Form2.p2 && Game.boardCell[i, j + 2].cellColor == Form2.p2)
                        {
                            if (Game.boardCell[i, j + 3].cellColor == Color.White)
                            {
                                if (i < 5 && Game.boardCell[i + 1, j + 3].cellColor == Color.White)
                                    break;
                                else
                                    cY = Game.boardCell[i, j + 3];
                            }
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i, j + 1].cellColor == Form2.p1 && Game.boardCell[i, j + 2].cellColor == Form2.p1)
                        {
                            if (Game.boardCell[i, j + 3].cellColor == Color.White)
                            {
                                if (i < 5 && Game.boardCell[i + 1, j + 3].cellColor == Color.White)
                                    break;
                                else
                                    cCell = Game.boardCell[i, j + 3];
                            }
                        }
                        if (Game.boardCell[i, j + 1].cellColor == Form2.p2 && Game.boardCell[i, j + 2].cellColor == Form2.p2 && Game.boardCell[i, j + 3].cellColor == Form2.p2)
                        {
                            if (Game.boardCell[i, j].cellColor == Color.White)
                            {
                                if (i < 5 && Game.boardCell[i + 1, j].cellColor == Color.White)
                                    break;
                                else
                                    cY = Game.boardCell[i, j];
                            }
                        }
                        else if (Game.boardCell[i, j + 1].cellColor == Form2.p1 && Game.boardCell[i, j + 2].cellColor == Form2.p1 && Game.boardCell[i, j + 3].cellColor == Form2.p1)
                        {
                            if (Game.boardCell[i, j].cellColor == Color.White)
                            {
                                if (i < 5 && Game.boardCell[i + 1, j].cellColor == Color.White)
                                    break;
                                else
                                    cY = Game.boardCell[i, j];
                            }
                        }

                    }
                    if (i >= 3)
                    {
                        if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i - 1, j].cellColor == Form2.p2 && Game.boardCell[i - 2, j].cellColor == Form2.p2)
                        {
                            if (Game.boardCell[i - 3, j].cellColor == Color.White && i>0)
                                cY = Game.boardCell[i - 3, j];
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i - 1, j].cellColor == Form2.p1 && Game.boardCell[i - 2, j].cellColor == Form2.p1)
                        {
                            if (Game.boardCell[i - 3, j].cellColor == Color.White)
                                cCell = Game.boardCell[i - 3, j];
                        }

                    }
                    if (j <= 3 && i >= 3)
                    {

                        if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i - 1, j + 1].cellColor == Form2.p2 && Game.boardCell[i - 2, j + 2].cellColor == Form2.p2)
                        {

                            if (Game.boardCell[i - 3, j + 3].cellColor == Color.White && i>0)
                            {
                                if (Game.boardCell[i - 2, j + 3].cellColor == Color.White)
                                    break;
                                else
                                    cY = Game.boardCell[i - 3, j + 3];
                            }
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i - 1, j + 1].cellColor == Form2.p1 && Game.boardCell[i - 2, j + 2].cellColor == Form2.p1)
                        {
                            if (Game.boardCell[i - 3, j + 3].cellColor == Color.White)
                            {
                                if (Game.boardCell[i - 2, j + 3].cellColor == Color.White)
                                    break;
                                else
                                    cCell = Game.boardCell[i - 3, j + 3];
                            }
                        }
                    }
                    if (j >= 3 && i >= 3)
                    {
                        if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i - 1, j - 1].cellColor == Form2.p2 && Game.boardCell[i - 2, j - 2].cellColor == Form2.p2)
                        {
                            if (Game.boardCell[i - 3, j - 3].cellColor == Color.White)
                            {
                                if (Game.boardCell[i - 2, j - 3].cellColor == Color.White)
                                    break;
                                else
                                    cY = Game.boardCell[i - 3, j - 3];
                            }
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i - 1, j - 1].cellColor == Form2.p1 && Game.boardCell[i - 2, j - 2].cellColor == Form2.p1)
                        {
                            if (Game.boardCell[i - 3, j - 3].cellColor == Color.White)
                            {
                                if (Game.boardCell[i - 2, j - 3].cellColor == Color.White)
                                    break;
                                else
                                    cCell = Game.boardCell[i - 3, j - 3];
                            }

                        }

                    }

                    if (j <= 3 && i < 3)
                    {
                        if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i + 1, j + 1].cellColor == Form2.p2 && Game.boardCell[i + 2, j + 2].cellColor == Form2.p2)
                        {

                            if (Game.boardCell[i + 3, j + 3].cellColor == Color.White)
                            {
                              
                               if (Game.boardCell[i + 4, j + 3].cellColor == Color.White)
                                    break;
                               else
                                   cY = Game.boardCell[i + 3, j + 3];
                            }
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i + 1, j + 1].cellColor == Form2.p1 && Game.boardCell[i+ 2, j + 2].cellColor == Form2.p1)
                        {
                            if (Game.boardCell[i + 3, j + 3].cellColor == Color.White)
                            {
                                if (Game.boardCell[i + 4, j + 3].cellColor == Color.White)
                                    break;
                                else
                                    cY = Game.boardCell[i + 3, j + 3];
                            }
                        }
                    }
                    if (j >= 3 && i < 3)
                    {
                        if (Game.boardCell[i, j].cellColor == Form2.p2 && Game.boardCell[i + 1, j - 1].cellColor == Form2.p2 && Game.boardCell[i + 2, j - 2].cellColor == Form2.p2)
                        {
                            if (Game.boardCell[i + 3, j - 3].cellColor == Color.White)
                            {
                                if (i + 4 == 5)
                                    cY = Game.boardCell[i + 3, j - 3];

                                else if (Game.boardCell[i + 4, j - 3].cellColor == Color.White)
                                    break;

                            }
                        }
                        else if (Game.boardCell[i, j].cellColor == Form2.p1 && Game.boardCell[i + 1, j - 1].cellColor == Form2.p1 && Game.boardCell[i + 2, j - 2].cellColor == Form2.p1)
                        {
                            if (Game.boardCell[i + 3, j - 3].cellColor == Color.White)
                            {
                                if (i + 4 == 5)
                                    cY = Game.boardCell[i + 3, j - 3];

                                else if (Game.boardCell[i + 4, j - 3].cellColor == Color.White)
                                    break;
                            }

                        }
                    }
                }
            }
            if(cY.cellPosition.Y != 0 || cY.cellPosition.X != 0)
                return cY;
            else
                return cCell;
        }
    }
}
