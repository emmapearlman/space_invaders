using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Player : IGameObject
    {
        public Point Position { get; private set; }
        public bool MoveLeft { get; set; }
        public bool MoveRight { get; set; }
        private Size size;
        private int speed;
        private DateTime lastShotTime;
        private int shotCooldown;

        public Player(Point position)
        {
            Position = position;
            size = new Size(40, 20);
            speed = 5;
            lastShotTime = DateTime.Now;
            shotCooldown = 250; // milliseconds
        }

        public void Update()
        {
            if (MoveLeft && Position.X > 0)
                Position = new Point(Position.X - speed, Position.Y);
            if (MoveRight && Position.X < 760) // 800 - 40 (width)
                Position = new Point(Position.X + speed, Position.Y);
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Green, new Rectangle(Position, size));
        }

        public void Shoot(System.Collections.Generic.List<Bullet> bullets)
        {
            if ((DateTime.Now - lastShotTime).TotalMilliseconds >= shotCooldown)
            {
                bullets.Add(new Bullet(new Point(Position.X + size.Width / 2, Position.Y), true));
                lastShotTime = DateTime.Now;
            }
        }

        public Rectangle Bounds => new Rectangle(Position, size);
    }
} 