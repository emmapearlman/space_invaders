using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders.Game
{
    public class Player : GameObject
    {
        public bool MoveLeft { get; set; }
        public bool MoveRight { get; set; }
        private DateTime lastShotTime;
        private int shotCooldown;

        public Player(Point position) 
            : base(position, new Size(40, 20), 5)
        {
            lastShotTime = DateTime.MinValue; // Initialize to allow first shot immediately
            shotCooldown = 250; // milliseconds
        }

        public override void Update()
        {
            if (MoveLeft && Position.X > 0)
                Position = new Point(Position.X - Speed, Position.Y);
            if (MoveRight && Position.X < 760) // 800 - 40 (width)
                Position = new Point(Position.X + Speed, Position.Y);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Green, new Rectangle(Position, Size));
        }

        public void Shoot(System.Collections.Generic.List<Bullet> bullets)
        {
            var now = DateTime.Now;
            if ((now - lastShotTime).TotalMilliseconds >= shotCooldown)
            {
                var bulletPosition = new Point(Position.X + Size.Width / 2, Position.Y);
                bullets.Add(new Bullet(bulletPosition, true));
                lastShotTime = now;
            }
        }
    }
} 