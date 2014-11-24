using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._1.Content.View
{
    class ShockwaveParticle
    {
        Texture2D shockwave;
        private Vector2 position;
        private float scale;
        private float timePast;
        Camera camera;

        public ShockwaveParticle(Viewport viewPort, Vector2 Position, ContentManager content)
        {
            shockwave = content.Load<Texture2D>("circle");
            camera = new Camera(viewPort.Width, viewPort.Height);
            position = Position;
            scale = scale * camera.Scale;
        }

        public void Draw(SpriteBatch spriteBatch, float elapsedTime)
        {
            timePast += elapsedTime;
            if (scale > 900.0f) 
            {
                scale = 0;
            }
            scale = scale + 5.0f;
            Vector2 scalePos = camera.scaleVector(position.X, position.Y);

            spriteBatch.Begin();
            spriteBatch.Draw(shockwave, new Rectangle((int)scalePos.X - (int)scale / 2, (int)scalePos.Y - (int)scale / 2, (int)scale, (int)scale), Color.White);
            spriteBatch.End();
        }
    }
}
