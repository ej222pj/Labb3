﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._1.Content.View
{
    class SplitterParticle
    {
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration;
        private static float splitterSize = 0.04f;


        public SplitterParticle(Vector2 Velocity, Vector2 Position)
        {
            position = Position;
            velocity = Velocity;
            acceleration = new Vector2(0, 0.5f);
        }

        public void Update(float timeElapsed)
        {
            Vector2 newPos = new Vector2();
            Vector2 newVel = new Vector2();

            newVel.X = velocity.X + timeElapsed * acceleration.X;
            newVel.Y = velocity.Y + timeElapsed * acceleration.Y;

            newPos.X = position.X + timeElapsed * velocity.X;
            newPos.Y = position.Y + timeElapsed * velocity.Y;

            velocity = newVel;
            position = newPos;

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture, Camera camera)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(splitterTexture, camera.scaleParticle(position.X, position.Y, splitterSize), Color.White);
            spriteBatch.End();
        }
    }
}
