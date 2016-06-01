using MagicSquare15.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//First of all you need to make 2 stringCollections in Settings: HSCollectionInt and HSCollectionString

namespace Fifteen
{
    class HighScores
    {
        public bool reseted = false;
        Form tempForm;
        TextBox tempTextBox;

        public HighScores()
        {
            //The constructor
        }

        public void HighScoresInfo()
        {
            //Creating the HighScoresWindow
            #region Creating the HighScoresWindow
            Form HighScoresWindow = new Form();
            HighScoresWindow.Icon = Resources._15ico;
            tempForm = HighScoresWindow;
            HighScoresWindow.FormBorderStyle = FormBorderStyle.FixedSingle;
            HighScoresWindow.StartPosition = FormStartPosition.CenterParent;
            HighScoresWindow.MaximizeBox = false;
            HighScoresWindow.MinimizeBox = false;
            HighScoresWindow.Move += delegate { HighScoresWindow.Capture = false; }; //Forbiding a movement of the form
            #endregion

            //Creating the TextBox to show results
            #region Creating the TextBox
            TextBox HSText = new TextBox();
            HSText.Multiline = true;
            HSText.Width = HighScoresWindow.Width;
            HSText.Height = HighScoresWindow.Height - 70;
            HSText.BackColor = System.Drawing.Color.White;
            HSText.Enabled = false;
            HSText.HideSelection = false;
            HSText.Text = "The high scores are: \r\n \r\n";
            for (int i = 0; i < Settings.Default.HSCollectionInt.Count; i++)
            {
                HSText.Text += (i+1) + ". " + Settings.Default.HSCollectionString[i] + Settings.Default.HSCollectionInt[i] + " seconds." + "\r\n";
            }
            tempTextBox = HSText;
            HighScoresWindow.Controls.Add(HSText);
            #endregion

            //Creating the button "reset"
            #region Creating the button "reset"
            Button BtnReset = new Button();
            BtnReset.Location = new System.Drawing.Point(120, 235);
            //BtnReset.SetTopLevel(true); 
            BtnReset.Text = "Reset results";
            //BtnReset.Anchor = AnchorStyles.Right;
            BtnReset.Size = new System.Drawing.Size(80, 23);
            BtnReset.TabIndex = 2;
            HighScoresWindow.Controls.Add(BtnReset);
            #endregion

            //Creating the button "close"
            #region Creating the button "close"
            Button BtnClose = new Button();
            BtnClose.Location = new System.Drawing.Point(210, 235);
            BtnClose.Text = "Close";
            BtnClose.Size = new System.Drawing.Size(70, 23);
            BtnClose.TabIndex = 1;
            HighScoresWindow.Controls.Add(BtnClose);
            #endregion

            //Events subscribing
            #region Events subscribing
            BtnReset.Click += new EventHandler(BtnReset_Click);
            BtnClose.Click += new EventHandler(BtnClose_Click);
            BtnClose.KeyDown += new KeyEventHandler(HighScoresWindow_KeyDown);
            #endregion

            HighScoresWindow.ShowDialog();
        }

        public void Register(int tempTime)
        {
            //Put Settings' data to an array
            #region the Exporting to array part
            List<string> hsArrayInt = new List<string>();
            List<string> hsArrayStr = new List<string>();
            try
            {
                for (int i = 0; i < Settings.Default.HSCollectionInt.Count; i++)
                {
                    hsArrayInt.Add(Settings.Default.HSCollectionInt[i]);
                    hsArrayStr.Add(Settings.Default.HSCollectionString[i]);
                }
            }
            catch { }
            #endregion

            //Add the current result to the array
            #region the Addition current result part
            hsArrayInt.Add(tempTime.ToString());
            hsArrayStr.Add("On the " + System.DateTime.Now + ", the result - ");
            #endregion

            //Sorting the arrays
            #region the Sorting part
            string[,] tempList = new string[2, hsArrayInt.Count];
            for (int i = 0; i < hsArrayInt.Count; i++)
            {
                tempList[0, i] = hsArrayInt[i];
                tempList[1, i] = hsArrayStr[i];
            }
            tempList = Sorting(tempList);
            for (int j = 0; j < tempList.GetLength(1); j++)
            {
                hsArrayInt[j] = tempList[0, j];
                hsArrayStr[j] = tempList[1, j];
            }
            #endregion

            //Upload the array's data to the Settings
            #region the Uploading part
            if (Settings.Default.HSCollectionInt == null)
            {
                Settings.Default.HSCollectionInt = new StringCollection();
                Settings.Default.HSCollectionString = new StringCollection();
                Settings.Default.HSCollectionInt.Add(hsArrayInt[0]);
                Settings.Default.HSCollectionString.Add(hsArrayStr[0]);
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.HSCollectionInt.Clear();
                Settings.Default.HSCollectionString.Clear();
                for (int i = 0; i < hsArrayInt.Count && i < 15; i++)
                {
                    Settings.Default.HSCollectionInt.Add(hsArrayInt[i]);
                    Settings.Default.HSCollectionString.Add(hsArrayStr[i]);
                    Settings.Default.Save();
                }
            }
            #endregion
        }

        private string[,] Sorting(string[,] array)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (Convert.ToInt16(array[0, j + 1]) < Convert.ToInt16(array[0, j]))
                    {
                        string c = array[0, j];
                        //change for the 1 column
                        array[0, j] = array[0, j + 1];
                        array[0, j + 1] = c;
                        //change for the 2 column
                        c = array[1, j];
                        array[1, j] = array[1, j + 1];
                        array[1, j + 1] = c;
                    }
                }
            }
            return array;
        }

        private void BtnReset_Click(object sender, System.EventArgs e)
        {
            Settings.Default.HSCollectionInt.Clear();
            Settings.Default.HSCollectionString.Clear();
            Settings.Default.Save();

            tempTextBox.Text = "The high scores are: \r\n \r\n";
            tempTextBox.Text += "...";
        }

        private void HighScoresWindow_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
