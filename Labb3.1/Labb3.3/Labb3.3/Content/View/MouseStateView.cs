using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._3.Content.View
{
    class MouseStateView
    {
        float x;
        float y;
        private MouseState currentMouseState;
        private MouseState previousMouseState;
        Camera camera;
        private SpriteBatch spriteBatch;

        public MouseStateView(Camera camera, GraphicsDevice graphicsDevice)
        {
            this.camera = camera;
            spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public bool IsButtonPressed() 
        {
            bool mouseIsClicked = false;
            currentMouseState = Mouse.GetState();

            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                mouseIsClicked = true;
            }

            previousMouseState = currentMouseState;

            return mouseIsClicked;
        }

        public Vector2 GetMousePos()
        {
            currentMouseState = Mouse.GetState();

            x = currentMouseState.X;
            y = currentMouseState.Y;

            Vector2 mouseModelPos = camera.mousePosToModelPos(x, y);

            return mouseModelPos;
        }

        internal void drawMouseAim(Texture2D aimTexture)
        {
            //int vx = (int)(centerX * camera.Scale + camera.getFrame());
            //int vy = (int)(centerY * camera.Scale + camera.getFrame());
            //int ballSize = (int)(diameter * camera.Scale);

            Rectangle mouseAim = new Rectangle(currentMouseState.X - 100 / 2, currentMouseState.Y - 100 / 2, 100, 100);

            spriteBatch.Begin();
            spriteBatch.Draw(aimTexture, mouseAim, Color.White);
            spriteBatch.End();
        }
    }
}
