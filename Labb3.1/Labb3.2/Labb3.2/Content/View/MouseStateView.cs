using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._2.Content.View
{
    class MouseStateView
    {
        private MouseState currentMouseState;
        private MouseState previousMouseState;
        Camera camera;

        public MouseStateView(Camera camera)
        {
            this.camera = camera;
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

            float x = currentMouseState.X;
            float y = currentMouseState.Y;

            Vector2 mouseModelPos = camera.mousePosToModelPos(x, y);

            return mouseModelPos;
        }

    }
}
