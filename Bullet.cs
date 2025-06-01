using System;
using System.Drawing;

namespace SpaceInvaders
{
    public class Bullet
    {
        public Point Position { get; private set; }
        private Size size;
        private int speed;
        private bool isPlayerBullet;

        public Bullet(Point position, bool isPlayerBullet)
        {
            Position = position;
            size = new Size(4, 10);
            speed = isPlayerBullet ? 7 : 5;
            this.isPlayerBullet = isPlayerBullet;
        }

        public void Update()
        {
            Position = new Point(Position.X, Position.Y + (isPlayerBullet ? -speed : speed));
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.White, new Rectangle(Position, size));
        }

        public Rectangle Bounds => new Rectangle(Position, size);
    }
} 