using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MagicSquare15.Properties;
using MagicSquare15;

namespace Fifteen
{
    public partial class FormFifteen : Form
    {
        static public int time;
        Body body;

        public FormFifteen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormFifteen_Load(object sender, EventArgs e)
        {
            body = new Body(tableLayoutPanel1, timer1);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 0, timer1, labelTime);
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 1, timer1, labelTime);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 2, timer1, labelTime);
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 3, timer1, labelTime);
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 4, timer1, labelTime);
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 5, timer1, labelTime);
        }

        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 6, timer1, labelTime);
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 7, timer1, labelTime);
        }

        private void label9_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 8, timer1, labelTime);
        }

        private void label10_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 9, timer1, labelTime);
        }

        private void label11_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 10, timer1, labelTime);
        }

        private void label12_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 11, timer1, labelTime);
        }

        private void label13_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 12, timer1, labelTime);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            body.Change(tableLayoutPanel1, 13, timer1, labelTime);
        }

        private void label15_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 14, timer1, labelTime);
        }

        private void label16_MouseDown(object sender, MouseEventArgs e)
        {
            body.Change(tableLayoutPanel1, 15, timer1, labelTime);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            body.MenuNewGame(tableLayoutPanel1, timer1);
        }

        private void highScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighScores hs = new HighScores();
            timer1.Stop();
            hs.HighScoresInfo();
            timer1.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = time++.ToString();

        }

        private void aboutTheAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            timer1.Stop();
            about.AboutInfo();
            timer1.Start();
        }
    }
}
