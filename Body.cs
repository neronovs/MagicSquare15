using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MagicSquare15.Properties;
using System.Drawing;

namespace Fifteen
{
    class Body
    {
        Image[] lstImg;
        //Color none = Color.FromArgb(0, Color.White);

        public Body(TableLayoutPanel tableLayoutPanel1, Timer timer1)
        {
            //put Resources' images to a List
            #region put Resources' images to a List
            lstImg = new Image[16];
            lstImg[0]=(Resources._01);
            lstImg[1]=(Resources._02);
            lstImg[2]=(Resources._03);
            lstImg[3]=(Resources._04);
            lstImg[4]=(Resources._05);
            lstImg[5]=(Resources._06);
            lstImg[6]=(Resources._07);
            lstImg[7]=(Resources._08);
            lstImg[8]=(Resources._09);
            lstImg[9]=(Resources._10);
            lstImg[10]=(Resources._11);
            lstImg[11]=(Resources._12);
            lstImg[12]=(Resources._13);
            lstImg[13]=(Resources._14);
            lstImg[14]=(Resources._15);
            lstImg[15]=(Resources._16);
            #endregion

            Field(tableLayoutPanel1, timer1);
        }

        private void Field(TableLayoutPanel tableLayoutPanel1, Timer timer1)
        {
            #region Randomizing
            //Randomizing of the array
            Random rnd = new Random(System.DateTime.Now.Millisecond);
            Image[] rndArray = lstImg;
            rndArray = rndArray.OrderBy(x => rnd.Next()).ToArray();
            //rndArray[14] = lstImg[15]; rndArray[15] = lstImg[14];
            #endregion

            #region Filling
            //Filling the field with the array of numbers
            for (int i = 0; i < 16; i++)
            {
                tableLayoutPanel1.Controls[i].BackgroundImage = rndArray[i];
            }
            #endregion
            timer1.Start();
        }

        public void Change(TableLayoutPanel tableLayoutPanel1, int num, Timer timer1, Label labelTime)
        {
            //Check if it is the space cell near by
            #region Check space near
            Image ofLeft, ofRight, ofUp, ofDown;
            try { ofLeft = tableLayoutPanel1.Controls[num - 1].BackgroundImage; } catch { ofLeft = null; }
            try { ofRight = tableLayoutPanel1.Controls[num + 1].BackgroundImage; } catch { ofRight = null; }
            try { ofUp = tableLayoutPanel1.Controls[num - 4].BackgroundImage; } catch { ofUp = null; }
            try { ofDown = tableLayoutPanel1.Controls[num + 4].BackgroundImage; } catch { ofDown = null; }
            #endregion

            //Changing the chosen cell to the space cell
            #region Changing
            if (ofLeft == lstImg[15])
            {
                tableLayoutPanel1.Controls[num - 1].BackgroundImage = tableLayoutPanel1.Controls[num].BackgroundImage;
                tableLayoutPanel1.Controls[num].BackgroundImage = lstImg[15];
            }
            else if (ofRight == lstImg[15])
            {
                tableLayoutPanel1.Controls[num + 1].BackgroundImage = tableLayoutPanel1.Controls[num].BackgroundImage;
                tableLayoutPanel1.Controls[num].BackgroundImage = lstImg[15];
            }
            else if (ofUp == lstImg[15])
            {
                tableLayoutPanel1.Controls[num - 4].BackgroundImage = tableLayoutPanel1.Controls[num].BackgroundImage;
                tableLayoutPanel1.Controls[num].BackgroundImage = lstImg[15];
            }
            else if (ofDown == lstImg[15])
            {
                tableLayoutPanel1.Controls[num + 4].BackgroundImage = tableLayoutPanel1.Controls[num].BackgroundImage;
                tableLayoutPanel1.Controls[num].BackgroundImage = lstImg[15];
            }
            #endregion

            Check(tableLayoutPanel1, timer1, labelTime); //Check to complete
        }

        public void Check(TableLayoutPanel tableLayoutPanel1, Timer timer1, Label labelTime)
        {
            //Check if all cells are positioned correctly
            #region Checking
            int finished = 0;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i].BackgroundImage == lstImg[i])
                    finished += 1;
            }
            #endregion

            //Finishing if conditions are completed
            #region Finishing
            if (finished == 16)
            {
                int tempTime = Convert.ToInt16(labelTime.Text);
                timer1.Stop();
                labelTime.Text = tempTime.ToString();

                MessageBox.Show("You won! Your time is " + tempTime + " seconds.");

                HighScores hs = new HighScores();
                hs.Register(tempTime);

                FormFifteen.time = 0;
                Field(tableLayoutPanel1, timer1);
            }
            #endregion
        }

        public void MenuNewGame(TableLayoutPanel tableLayoutPanel1, Timer timer1)
        {
            Field(tableLayoutPanel1, timer1);
        }
    }
}
