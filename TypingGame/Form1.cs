using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingGame
{
    public partial class Form1 : Form
    {
        Stats stats = new Stats();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();

            //add a random key to the ListBox
            listBox1.Items.Add((Keys)rnd.Next(65, 90));

            //check ListBox if it filled 
            if(listBox1.Items.Count > 7)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Game over!");
                timer1.Stop();
                
                if (MessageBox.Show("Do you want a new round?", "Game over", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Application.Restart();
                }
                else
                    Close();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //If the user pressed a key that's in the listBox, remove it
            //and then make the game a little faster
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();

                if (timer1.Interval > 400)
                    timer1.Interval -= 10;
                if (timer1.Interval > 250)
                    timer1.Interval -= 7;
                if (timer1.Interval > 100)
                    timer1.Interval -= 2;

                progBarDifficulty.Value = 800 - timer1.Interval;

                //The user pressed a correct key, update the Stats object
                //by calling its Update() method with the argument true
                stats.Update(true);
            }
            else
                //The user pressed an incorrect key, update the Stats object
                //by calling its Update() method with the argument false
                stats.Update(false);

            //Update the labels on tha StatusBar
            lblCorrect.Text = "Correct: " + stats.Correct;
            lblAccuracy.Text = "Accuracy: " + stats.Accuracy + "%";
            lblMissed.Text = "Missed: " + stats.Missed;
            lblTotal.Text = "Total: " + stats.Total;
        }
    }
}
