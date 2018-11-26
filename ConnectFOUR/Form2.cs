using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConnectFOUR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Game game = new Game();
        public static bool checkplayer; //check pc or player
        public static string player1col = "";
        public static string player2col = "";
        public static Color p1;
        public static Color p2;
        public static string GameMode;
        int p1count, p2count; //playersScores
        public static bool checkpc = false;

        public static int x = 0;
        public static int y = 0;

        //write in file
        public static int rowN = 0;
        public static int colN = 0;
        public static int score = 0;
        public static bool winC = false;
        public static bool winP = false;
        void initialize()
        {
            winC = false;
            winP = false;
            Player.playerOneCount = 0;
            Player.playerTwoCount = 0;
            Player.checkWinner = false;
            dataGridView1.Enabled = true;
            Game.boardCell = new Game.cell[6, 7];

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            p1 = Color.FromName(player1col);
            p2 = Color.FromName(player2col);
            DataGridViewTextBoxColumn Column = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(Column);
            dataGridView1.Columns[0].Width = 100;
            for (int i = 0; i < 6; i++)
            {
                DataGridViewTextBoxColumn Column1 = new DataGridViewTextBoxColumn();
                dataGridView1.Columns.Add(Column1);
                dataGridView1.Columns[i + 1].Width = 100;
                DataGridViewRow Row = new DataGridViewRow();
                Row.Height = 100;
                dataGridView1.Rows.Add(Row);
            }
            Controls.Add(dataGridView1);
            game.initializecells();

            if (checkplayer == true)
            {
                label1.Text = player1col;
                label3.Text = player2col;
                label5.Text = player1col + " Turn";
                label5.ForeColor = p1;
            }
            else
            {
                label3.Text = "Computer";
                label1.Text = player1col;
                label5.Text = "Play Smart ☺";
                label5.ForeColor = Color.Navy;
            }


        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            drawBoard();

            Graphics g = dataGridView1.CreateGraphics();
            for (int i = 0; i < Game.boardCell.GetLength(0); i++)
            {
                for (int j = 0; j < Game.boardCell.GetLength(1); j++)
                {
                    Brush b = new SolidBrush(Game.boardCell[i, j].cellColor);
                    g.FillEllipse(b, Game.boardCell[i, j].cellPosition.X, Game.boardCell[i, j].cellPosition.Y, 100, 100);
                }
            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            if (GameMode == "Player V.S Player")
                playerVSplayer(e.X, e.Y);
            else
            {
                playerVScomputer(e.X, e.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initialize();
            game.initializecells();
            dataGridView1.Invalidate();
            if (checkpc == true)
                playerVScomputer(x, y);
        }

        void drawBoard()
        {
            int X = 0;
            int Y = 0;
            Graphics g = dataGridView1.CreateGraphics();
            Brush b = new SolidBrush(Color.Black);
            Pen p = new Pen(b, 3);
            for (int i = 0; i < 6; i++)
            {
                X = 0;
                for (int j = 0; j < 7; j++)
                {
                    g.DrawEllipse(p, X, Y, 100, 100);
                    X += 100;
                }
                Y += 100;
            }
        }

        public void playerVSplayer(int x, int y)
        {
            Game.cell cell = new Game.cell();

            if (Player.PlayerOneTurn == true)
            {
                cell = Game.cellSearch(x, y, p1);

                Player.playerOneCount++;
                if (Player.playerOneCount >= 4)
                {
                    Player.winningPlayer();
                    if (Player.checkWinner == true)
                    {
                        MessageBox.Show(player1col + " is the winner");
                        dataGridView1.Enabled = false;
                        p1count++;
                        label2.Text = p1count.ToString();
                        return;
                    }

                }
                Player.PlayerTwoTurn = true;
                Player.PlayerOneTurn = false;

                label5.ForeColor = p2;
                label5.Text = player2col + " Turn";

            }

            else if (Player.PlayerTwoTurn == true)
            {
                cell = Game.cellSearch(x, y, p2);


                Player.playerTwoCount++;
                if (Player.playerTwoCount >= 4)
                {
                    Player.winningPlayer();
                    if (Player.checkWinner == true)
                    {
                        MessageBox.Show(player2col + " is the winner");
                        dataGridView1.Enabled = false;
                        p2count++;
                        label4.Text = p2count.ToString();
                        return;
                    }
                }
                Player.PlayerOneTurn = true;
                Player.PlayerTwoTurn = false;
                label5.ForeColor = p1;
                label5.Text = player1col + " Turn";
            }

        }

        public void playerVScomputer(int x, int y)
        {
            if (Player.PlayerOneTurn == true)
            {
                Game.cellSearch(x, y, p1);
                write_file(Player.PlayerOneTurn, 0, rowN, colN);
                Player.playerOneCount++;

                if (Player.playerOneCount >= 4)
                {
                    Player.winningPlayer();
                    if (Player.checkWinner == true)
                    {
                        MessageBox.Show(player1col + " is the winner");
                        dataGridView1.Enabled = false;
                        p1count++;
                        label2.Text = p1count.ToString();
                        winP = true;
                        write_file(Player.PlayerOneTurn, 0, rowN, colN);
                        return;
                    }
                }
                checkpc = true;
                Player.PlayerOneTurn = false;
            }

            if (checkpc == true)
            {
                Computer.minimax();
                Player.playerTwoCount++;
                write_file(Player.PlayerOneTurn, score, rowN, colN);
                if (Player.playerTwoCount >= 4)
                {
                    Player.winningPlayer();
                    if (Player.checkWinner == true)
                    {
                        MessageBox.Show(player2col + " is the winner");
                        dataGridView1.Enabled = false;
                        p2count++;
                        label4.Text = p2count.ToString();
                        winC = true;
                        write_file(Player.PlayerOneTurn, score, rowN, colN);
                        return;
                    }
                }
                checkpc = false;
                Player.PlayerOneTurn = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            initialize();
            game.initializecells();
            dataGridView1.Invalidate();
        }

        private void write_file(bool turn, int score, int row, int column)
        {
            FileStream fs = new FileStream("log file.txt",FileMode.Append);
            string s;
            StreamWriter sw = new StreamWriter(fs);
            if (turn == true)
            {
                if (winP == true)
                s= player1col + " is the Winner \0/";
                else
               s = "Player One row number= " + row + " , Column number= " + column;
            }
            else
            {
                if (winC == true)
                    s = "Computer is the Winner -_-";
                else
                    s = "Computer row number= " + row + " , Column number= " + column + " , Score= " + score;

            }
            sw.WriteLine(s);
            sw.Close();
        }
    }
}
