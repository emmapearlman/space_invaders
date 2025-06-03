using System;
using System.Drawing;

namespace SpaceInvaders.Game
{
    public enum EnemyType
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }

    public class Enemy : GameObject
    {
        public EnemyType Type { get; }
        private bool movingRight;
        private int moveDownDistance;

        public Enemy(Point position, EnemyType type) 
            : base(position, new Size(30, 20), 2)
        {
            Type = type;
            movingRight = true;
            moveDownDistance = 20;
        }

        public override void Update()
        {
            if (movingRight)
            {
                Position = new Point(Position.X + Speed, Position.Y);
                if (Position.X > 770) // 800 - 30 (width)
                {
                    Position = new Point(Position.X, Position.Y + moveDownDistance);
                    movingRight = false;
                }
            }
            else
            {
                Position = new Point(Position.X - Speed, Position.Y);
                if (Position.X < 0)
                {
                    Position = new Point(Position.X, Position.Y + moveDownDistance);
                    movingRight = true;
                }
            }
        }

        public override void Draw(Graphics g)
        {
            Brush enemyBrush = Type switch
            {
                EnemyType.Small => Brushes.Red,
                EnemyType.Medium => Brushes.Yellow,
                EnemyType.Large => Brushes.Blue,
                _ => Brushes.White
            };

            g.FillRectangle(enemyBrush, new Rectangle(Position, Size));
        }
    }
} 