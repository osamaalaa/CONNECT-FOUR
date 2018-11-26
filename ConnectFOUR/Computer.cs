using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConnectFOUR
{
    class Computer
    {
        public static int calculateScore(Game.cell c1, int columns, int rows)
        {
            int Count = 0;
            int maxScores = 0;
            int minX = Math.Max(Game.boardCell.GetLowerBound(1), columns - 3);
            int maxX = Math.Min(Game.boardCell.GetUpperBound(1), columns + 3);
            int maxY = Math.Max(Game.boardCell.GetLowerBound(0), rows - 3);
            int minY = Math.Min(Game.boardCell.GetUpperBound(0), rows + 3);

            List<int> scores = new List<int>();

            //Right side
            for (int i = columns + 1; i <= maxX; i++)
            {
                if (Game.boardCell[rows, i].cellColor == Color.Yellow)
                {
                    Count++;
                }
                else if (Game.boardCell[rows, i].cellColor != Color.White)
                {
                    Count--;
                }
                else
                {
                    break;
                }
            }
            scores.Add(Count);
            Count = 0;

            //Left Side
            for (int j = columns - 1; j >= minX; j--)
            {
                if (Game.boardCell[rows, j].cellColor == Color.Yellow)
                {
                    Count++;
                }
                else if (Game.boardCell[rows, j].cellColor != Color.White)
                {
                    Count--;
                }
                else
                {
                    break;
                }
            }
            scores.Add(Count);
            Count = 0;

            //Down side
            for (int i = rows + 1; i <= minY; i++)
            {

                if (Game.boardCell[i, columns].cellColor == Color.Yellow)
                {
                    Count++;
                }
                else if (Game.boardCell[i, columns].cellColor != Color.White)
                {
                    Count--;
                }
                else
                {
                    break;
                }
            }
            scores.Add(Count);
            Count = 0;

            //right-up diagonal 
            int y = rows - 1;
            for (int i = columns + 1; i <= maxX; i++)
            {
                if (y < 0)
                    break;
                if (Game.boardCell[y, i].cellColor == Color.Yellow)
                {
                    Count++;
                }
                else if (Game.boardCell[y, i].cellColor != Color.White)
                {
                    Count--;
                }
                else
                {
                    break;
                }
                y--;
            }
            scores.Add(Count);
            Count = 0;

            //Left down digonal
            y = rows + 1;
            for (int i = columns - 1; i >= minX; i--)
            {
                if (y > 5)
                    break;
                if (Game.boardCell[y, i].cellColor == Color.Yellow)
                {
                    Count++;
                }
                else if (Game.boardCell[y, i].cellColor != Color.White)
                {
                    Count--;
                }
                else
                {
                    break;
                }
                y++;
            }
            scores.Add(Count);
            Count = 0;

            //Right down digonal
            y = rows + 1;
            for (int i = columns + 1; i <= maxX; i++)
            {
                if (y > 5)
                    break;
                if (Game.boardCell[y, i].cellColor == Color.Yellow)
                {
                    Count++;
                }
                else if (Game.boardCell[y, i].cellColor != Color.White)
                {
                    Count--;
                }
                else
                {
                    break;
                }

                y++;
            }
            scores.Add(Count);
            Count = 0;

            //Left up digonal
            y = rows - 1;
            for (int i = columns - 1; i >= minX; i--)
            {
                if (y < 0)
                    break;
                if (Game.boardCell[y, i].cellColor == Color.Yellow)
                {
                    Count++;
                }
                else if (Game.boardCell[y, i].cellColor != Color.White)
                {
                    Count--;
                }
                else
                {
                    break;
                }

                y--;
            }
            scores.Add(Count);
            Count = 0;
    
            maxScores = scores.Max();
            return maxScores;

        }

        public static void minimax()
        {
            Game.cell cell = new Game.cell();
            List<int> totalscores = new List<int>();
            List<Point> scorespoints = new List<Point>();
            int maxindex = 0;
            Point finalpos = new Point(0, 0);

           cell = Player.playerToWin();
            if (cell.cellPosition.X != 0 ||cell.cellPosition.Y !=0)
            {
                for (int i = Game.boardCell.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = 0; j < Game.boardCell.GetLength(1); j++)
                    {
                        if (cell.cellPosition == Game.boardCell[i, j].cellPosition)
                        {
                           cell.cellColor = Color.Yellow;
                            Game.boardCell[i, j].cellColor =cell.cellColor;
                            Form2.rowN = i;
                            Form2.colN = j;
                        }

                    }
                }
            }
            else
            {
                for (int j = 5; j >= 0; j--)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (Game.boardCell[j, i].cellColor == Color.White)
                        {
                            if (j < 5 && Game.boardCell[j + 1, i].cellColor == Color.White)
                                break;
                            else
                            {
                                totalscores.Add(calculateScore((Game.boardCell[j, i]), i, j));
                                scorespoints.Add(Game.boardCell[j, i].cellPosition);
                            }
                        }

                    }
                }

                maxindex = totalscores.IndexOf(totalscores.Max());
                Form2.score = totalscores.Max();
                finalpos = scorespoints[maxindex];
                cell.cellPosition = finalpos;

                for (int i = Game.boardCell.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = 0; j < Game.boardCell.GetLength(1); j++)
                    {
                        if (cell.cellPosition == Game.boardCell[i, j].cellPosition)
                        {
                            cell.cellColor = Color.Yellow;
                            Game.boardCell[i, j].cellColor = cell.cellColor;
                            Form2.colN = j;
                            Form2.rowN = i;
                        }

                    }
                }
                
            }
        }
    }

}
