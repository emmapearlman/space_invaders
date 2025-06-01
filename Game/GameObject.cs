using System.Drawing;
using SpaceInvaders.Interfaces;

namespace SpaceInvaders.Game
{
    public abstract class GameObject : IGameObject
    {
        public Point Position { get; protected set; }
        protected Size Size { get; set; }
        protected int Speed { get; set; }

        protected GameObject(Point position, Size size, int speed)
        {
            Position = position;
            Size = size;
            Speed = speed;
        }

        public virtual void Update()
        {
            // Base implementation can be empty, derived classes will override
        }

        public virtual void Draw(Graphics g)
        {
            // Base implementation can be empty, derived classes will override
        }

        public Rectangle Bounds => new Rectangle(Position, Size);
    }
} 