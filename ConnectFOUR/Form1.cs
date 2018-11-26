using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFOUR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2.GameMode = gameMode.SelectedItem.ToString();

            if (gameMode.SelectedItem == "Player V.S Player")
            {
                if (comboBox1.Text == comboBox2.Text)
                {
                    MessageBox.Show("Please Select different Colors");
                }
                else
                {
                    Form2.player1col = comboBox1.Text;
                    Form2.player2col = comboBox2.Text;
                    Form2.checkplayer = true;
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
            }
            else if (gameMode.SelectedItem == "Player V.S Computer")
            {
                if (comboBox1.Text == "Yellow")
                {
                    MessageBox.Show("Kindly Select Another Color");
                }
                else
                {
                    Form2.player1col = comboBox1.Text;
                    Form2.player2col = "Yellow";
                    Form2.checkplayer = false;
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void gameMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gameMode.SelectedItem == "Player V.S Player")
            {
                label3.Visible = true;
                comboBox2.Visible = true;
                label4.Visible = false;
            }
            else
            {
                label4.Visible = true;
                label3.Visible = false;
                comboBox2.Visible = false;
            }
        }


    }
}
