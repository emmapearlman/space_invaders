using System;
using System.Drawing;

namespace SpaceInvaders
{
    public enum EnemyType
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }

    public class Enemy : IGameObject
    {
        public Point Position { get; private set; }
        public EnemyType Type { get; }
        private Size size;
        private int speed;
        private bool movingRight;
        private int moveDownDistance;

        public Enemy(Point position, EnemyType type)
        {
            Position = position;
            Type = type;
            size = new Size(30, 20);
            speed = 2;
            movingRight = true;
            moveDownDistance = 20;
        }

        public void Update()
        {
            if (movingRight)
            {
                Position = new Point(Position.X + speed, Position.Y);
                if (Position.X > 770) // 800 - 30 (width)
                {
                    Position = new Point(Position.X, Position.Y + moveDownDistance);
                    movingRight = false;
                }
            }
            else
            {
                Position = new Point(Position.X - speed, Position.Y);
                if (Position.X < 0)
                {
                    Position = new Point(Position.X, Position.Y + moveDownDistance);
                    movingRight = true;
                }
            }
        }

        public void Draw(Graphics g)
        {
            Brush enemyBrush = Type switch
            {
                EnemyType.Small => Brushes.Red,
                EnemyType.Medium => Brushes.Yellow,
                EnemyType.Large => Brushes.Blue,
                _ => Brushes.White
            };

            g.FillRectangle(enemyBrush, new Rectangle(Position, size));
        }

        public Rectangle Bounds => new Rectangle(Position, size);
    }
} 