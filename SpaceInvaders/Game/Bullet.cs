using System;
using System.Drawing;

namespace SpaceInvaders.Game
{
    public class Bullet : GameObject
    {
        private bool isPlayerBullet;

        public Bullet(Point position, bool isPlayerBullet) 
            : base(position, new Size(4, 10), isPlayerBullet ? 7 : 5)
        {
            this.isPlayerBullet = isPlayerBullet;
        }

        public override void Update()
        {
            Position = new Point(Position.X, Position.Y + (isPlayerBullet ? -Speed : Speed));
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.White, new Rectangle(Position, Size));
        }
    }
} 