using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Game
    {
        private Player player;
        private List<Enemy> enemies;
        private List<Bullet> bullets;
        private Size gameArea;
        private Random random;
        private int score;
        private bool gameOver;

        public Game(Size gameArea)
        {
            this.gameArea = gameArea;
            random = new Random();
            InitializeGame();
        }

        private void InitializeGame()
        {
            player = new Player(new Point(gameArea.Width / 2, gameArea.Height - 50));
            enemies = new List<Enemy>();
            bullets = new List<Bullet>();
            score = 0;
            gameOver = false;

            // Create enemies
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 11; col++)
                {
                    enemies.Add(new Enemy(
                        new Point(50 + col * 50, 50 + row * 40),
                        row < 2 ? EnemyType.Small : row < 4 ? EnemyType.Medium : EnemyType.Large
                    ));
                }
            }
        }

        public void Update()
        {
            if (gameOver) return;

            // Update player
            player.Update();

            // Update enemies
            foreach (var enemy in enemies)
            {
                enemy.Update();
            }

            // Update bullets
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Update();
                if (bullets[i].Position.Y < 0 || bullets[i].Position.Y > gameArea.Height)
                {
                    bullets.RemoveAt(i);
                    continue;
                }

                // Check bullet collisions
                for (int j = enemies.Count - 1; j >= 0; j--)
                {
                    if (bullets[i].Bounds.IntersectsWith(enemies[j].Bounds))
                    {
                        score += (int)enemies[j].Type * 10;
                        enemies.RemoveAt(j);
                        bullets.RemoveAt(i);
                        break;
                    }
                }
            }

            // Check game over conditions
            if (enemies.Count == 0)
            {
                gameOver = true;
            }
            else
            {
                foreach (var enemy in enemies)
                {
                    if (enemy.Position.Y > gameArea.Height - 50)
                    {
                        gameOver = true;
                        break;
                    }
                }
            }
        }

        public void Draw(Graphics g)
        {
            // Draw background
            g.Clear(Color.Black);

            // Draw player
            player.Draw(g);

            // Draw enemies
            foreach (var enemy in enemies)
            {
                enemy.Draw(g);
            }

            // Draw bullets
            foreach (var bullet in bullets)
            {
                bullet.Draw(g);
            }

            // Draw score
            using (var font = new Font("Arial", 16))
            {
                g.DrawString($"Score: {score}", font, Brushes.White, new PointF(10, 10));
            }

            if (gameOver)
            {
                using (var font = new Font("Arial", 32))
                {
                    string gameOverText = enemies.Count == 0 ? "You Win!" : "Game Over";
                    var textSize = g.MeasureString(gameOverText, font);
                    g.DrawString(gameOverText, font, Brushes.White,
                        new PointF((gameArea.Width - textSize.Width) / 2,
                                 (gameArea.Height - textSize.Height) / 2));
                }
            }
        }

        public void HandleKeyDown(Keys key)
        {
            if (key == Keys.Left)
                player.MoveLeft = true;
            else if (key == Keys.Right)
                player.MoveRight = true;
            else if (key == Keys.Space)
                player.Shoot(bullets);
        }

        public void HandleKeyUp(Keys key)
        {
            if (key == Keys.Left)
                player.MoveLeft = false;
            else if (key == Keys.Right)
                player.MoveRight = false;
        }
    }
} 