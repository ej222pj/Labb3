using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._3.Content.View
{
    class Camera
    {
        private float scale;
        private static int border;
        private int width;
        private int height;

        public Camera(int width, int heigth, int frame)
        {
            border = frame;

            int scaleX = (width - border * 2);
            int scaleY = (heigth - border * 2);

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        public void setDimensions(int width, int height)
        {
            this.width = width;
            this.height = height;

            int scaleX = (width - border * 2);
            int scaleY = (height - border * 2);

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        public Rectangle scaleParticle(float xPos, float yPos, float size)
        {
            int vSize = (int)(size * scale);

            Vector2 smokeVector = scaleVector(xPos, yPos);

            return new Rectangle((int)smokeVector.X, (int)smokeVector.Y, vSize, vSize);
        }

        public Vector2 scaleVector(float xPos, float yPos)
        {
            float X = (xPos * scale + border);
            float Y = (yPos * scale + border);

            return new Vector2(X, Y);
        }

        public Vector2 mousePosToModelPos(float mouseX, float mouseY)
        {
            float modelX = (mouseX - border) / scale;
            float modelY = (mouseY - border) / scale;

            Vector2 newPos = new Vector2(modelX, modelY);

            return newPos;
        }

        public float Scale
        {
            get { return scale; }
        }

        public int getFrame()
        {
            return border;
        }
    }
}
