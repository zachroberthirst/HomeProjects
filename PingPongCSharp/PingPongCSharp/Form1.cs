﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPongCSharp
{
    public partial class Form1 : Form
    {

        public int speed_left = 4;  //Speed of the ball 
        public int speed_top = 4;
        public int points = 0; //Points at beginning of match

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide(); //Hides the cursor

            this.FormBorderStyle = FormBorderStyle.None; //removes border
            this.TopMost = true; //bring the form to front of tabs
            this.Bounds = Screen.PrimaryScreen.Bounds; //Makes form fullscreen 

            racket.Top = playground.Bottom - (playground.Bottom / 10); //Set the positon of racket

           
            gameover_lbl.Left = (playground.Width / 8) - (gameover_lbl.Width / 8); //Position to left side of screen
            gameover_lbl.Top = (playground.Height / 2) - (gameover_lbl.Height / 2);
            gameover_lbl.Visible = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            racket.Left = Cursor.Position.X - (racket.Width / 2); //Set the center of the racet to the point of the cursor

            ball.Left += speed_left;    //Move the ball
            ball.Top += speed_top;

            if(ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right) //Racket Collison 
            {
                speed_top += 1;
                speed_left += 1;
                speed_top = -speed_top; //Change direction 
                points += 1;
                points_lbl.Text = points.ToString();

                
            }

            if(ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if(ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if(ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }

            if(ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false; //ball is out -> stop the game

                gameover_lbl.Visible = true; 
            
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close(); // Press Escape to quit 
            }
            if(e.KeyCode == Keys.F1)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                points = 0;
                points_lbl.Text = "0";
                timer1.Enabled = true;
                gameover_lbl.Visible = false;
            }

        }

       
    }
}
