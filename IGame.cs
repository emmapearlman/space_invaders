using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public interface IGame
    {
        void Update();
        void Draw(Graphics g);
        void HandleKeyDown(Keys key);
        void HandleKeyUp(Keys key);
    }
} 