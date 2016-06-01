using MagicSquare15.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicSquare15
{
    class About
    {
        Form tempForm;
        TextBox tempTextBox;

        public About()
        {
            //The constructor
        }

        public void AboutInfo()
        {
            //Creating the AboutWindow
            #region Creating the AboutWindow
            Form AboutWindow = new Form();
            AboutWindow.Icon = Resources._15ico;
            tempForm = AboutWindow;
            AboutWindow.FormBorderStyle = FormBorderStyle.FixedSingle;
            AboutWindow.StartPosition = FormStartPosition.CenterParent;
            //AboutWindow.MaximizeBox = false;
            AboutWindow.MinimizeBox = false;
            AboutWindow.Move += delegate { AboutWindow.Capture = false; }; //Forbiding a movement of the form
            #endregion

            //Creating the TextBox to show info about the app
            #region Creating the TextBox
            TextBox AboutText = new TextBox();
            AboutText.Multiline = true;
            AboutText.Width = AboutWindow.Width;
            AboutText.Height = AboutWindow.Height - 70;
            AboutText.BackColor = System.Drawing.Color.White;
            AboutText.Enabled = false;
            AboutText.HideSelection = false;
            AboutText.Text = "The \"Fifteen\" is a 4×4 \"Magic square\" kind of games. \r\n";
            AboutText.Text += "The game was created by Sergei Neronov in 2016. \r\n \r\n";
            AboutText.Text += "The rules of the game are: \r\n";
            AboutText.Text += "First of all, you need to complete the form with 15 cells\r\n";
            AboutText.Text += "in order, using a space cell to move numbers. When you\r\n";
            AboutText.Text += "get completed the order from 1 to 15, the game will be\r\n";
            AboutText.Text += "finished.";
            tempTextBox = AboutText;
            AboutWindow.Controls.Add(AboutText);
            #endregion

            //Creating the button "close"
            #region Creating the button "close"
            Button BtnClose = new Button();
            BtnClose.Location = new System.Drawing.Point(210, 235);
            BtnClose.Text = "Close";
            BtnClose.Size = new System.Drawing.Size(70, 23);
            BtnClose.TabIndex = 1;
            AboutWindow.Controls.Add(BtnClose);
            #endregion

            //Creating a picture
            #region Creating the picture
            /*PictureBox picBox = new PictureBox();
            picBox.Image = Resources._15png as Bitmap;
            picBox.Location = new System.Drawing.Point(210, 265);
            picBox.Size = new System.Drawing.Size(70, 23);
            AboutWindow.Controls.Add(picBox);*/
            #endregion

            //Events subscribing
            #region Events subscribing
            BtnClose.Click += new EventHandler(BtnClose_Click);
            BtnClose.KeyDown += new KeyEventHandler(AboutWindow_KeyDown);
            #endregion

            AboutWindow.ShowDialog();
        }

        private void AboutWindow_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                tempForm.Close();
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            tempForm.Close();
        }
    }
}
