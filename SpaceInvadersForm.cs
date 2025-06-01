using System;
using System.Drawing;
using System.Windows.Forms;
using SpaceInvaders.Game;
using SpaceInvaders.Interfaces;

namespace SpaceInvaders
{
    public class SpaceInvadersForm : Form
    {
        private IGame game;
        private System.Windows.Forms.Timer gameTimer;

        public SpaceInvadersForm()
        {
            this.Text = "Space Invaders";
            this.ClientSize = new Size(800, 600);
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            game = new Game.Game(this.ClientSize);
            gameTimer = new System.Windows.Forms.Timer { Interval = 16 };
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            this.KeyDown += SpaceInvadersForm_KeyDown;
            this.KeyUp += SpaceInvadersForm_KeyUp;
            this.Paint += SpaceInvadersForm_Paint;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            game.Update();
            this.Invalidate();
        }

        private void SpaceInvadersForm_KeyDown(object sender, KeyEventArgs e)
        {
            game.HandleKeyDown(e.KeyCode);
        }

        private void SpaceInvadersForm_KeyUp(object sender, KeyEventArgs e)
        {
            game.HandleKeyUp(e.KeyCode);
        }

        private void SpaceInvadersForm_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }
    }
} 