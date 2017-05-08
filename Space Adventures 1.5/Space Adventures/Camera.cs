using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Adventures
{
    class Camera
    {
        private Matrix transform;
        private Vector2 pos;
        private Viewport view;

        public Rectangle levelBounds = new Rectangle(0, 0, 1000, 640);

        public Camera(Viewport view)
        {
            this.view = view;
        }

        public void SetPos(Vector2 pos)
        {
            this.pos = pos;
            transform = Matrix.CreateTranslation(MathHelper.Clamp(view.Width / 2 - pos.X, -levelBounds.Right, 0), MathHelper.Clamp(view.Height / 2 - pos.Y, -levelBounds.Bottom, (-800 - -levelBounds.Bottom)), 0);
        }

        public Vector2 GetPos()
        {
            return pos;
        }

        public Matrix GetTransform()
        {
            return transform;
        }
    }
}
