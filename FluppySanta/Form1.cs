using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FluppySanta
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int pipeSpeed = 6;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void ground_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            santa.Top += gravity;
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;
            pipeBottomTree.Left -= pipeSpeed;
            scoreLabel1.Text = $"score: {score} ";

            if (pipeTop.Left < -100)
            {
                pipeTop.Left = 500;
                score++;
            }

            if (pipeBottom.Left < -100 )
            {
                pipeBottom.Left = 500;
                score++;
            }

            if (pipeBottomTree.Left < -100)
            {
                pipeBottomTree.Left = 500 ;
                score++;
            }


            if (santa.Top < -25)
            {
                gameOver();
            }


            if (santa.Bounds.IntersectsWith(pipeTop.Bounds) || santa.Bounds.IntersectsWith(pipeBottom.Bounds) || santa.Bounds.IntersectsWith(pipeBottomTree.Bounds) ||
              santa.Bounds.IntersectsWith(grounds.Bounds))
            {
                gameOver();
            }
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;

            }
        }

        private void gameOver()
        {
            timer1.Stop();
            scoreLabel1.Text = $" Game over!";
            playAgain.Visible = true;
        }

        private void playAgain_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }
    }
}
