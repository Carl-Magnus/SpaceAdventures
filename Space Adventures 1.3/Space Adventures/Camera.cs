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

        public Camera(Viewport view)
        {
            this.view = view;
        }

        public void SetPos(Vector2 pos)
        {
            this.pos = pos;
            transform = Matrix.CreateTranslation(-pos.X + view.Width / 2, -pos.Y + view.Height / 2, 0);
            //Matrix.CreateTranslation(MathHelper.Clamp(view.Width / 2 - pos.X, -levelBounds.Right, -levelBounds.Left)
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
