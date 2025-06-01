using System.Drawing;

namespace SpaceInvaders.Interfaces
{
    public interface IGameObject
    {
        Point Position { get; }
        Rectangle Bounds { get; }
        void Update();
        void Draw(Graphics g);
    }
} 