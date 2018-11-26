using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConnectFOUR
{
   public  class Game
    {
        public  struct cell
        {
            public Color cellColor;
            public Point cellPosition;
        }
       public static cell[,] boardCell;

       //initialize the position and color of each cell
        public void initializecells()
        {
            boardCell = new cell[6, 7];
            Point minPos = new Point(0, 0);

            for (int i = 0; i < 6; i++)
            {
                minPos.X = 0;
                for (int j = 0; j < 7; j++)
                {
                    boardCell[i, j].cellPosition = minPos;
                    boardCell[i, j].cellColor = Color.White;
                    minPos.X += 100;
                }
                minPos.Y += 100;
            }

        }

        public static cell cellSearch(int xPos, int yPos, Color col)
        {
            cell cell1 = new cell();
           
            for (int i = boardCell.GetLength(0)-1; i >= 0; i--)
            {
                for (int j = 0; j < boardCell.GetLength(1); j++)
                {
                    if (boardCell[i, j].cellPosition.X <= xPos && boardCell[i, j].cellPosition.X + 100 >= xPos)
                    {

                        if (boardCell[i, j].cellColor == Color.White)
                        {
                            boardCell[i, j].cellColor = col;
                            cell1 = boardCell[i, j];
                            Form2.rowN = i;
                            Form2.colN = j;
                            return cell1;
                        }

                    }
                }

            }
            return cell1;
        }
    }
}
