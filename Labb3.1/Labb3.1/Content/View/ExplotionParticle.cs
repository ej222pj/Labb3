using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._1.Content.View
{
    class ExplotionParticle
    {
        Texture2D explosion;
        private Vector2 position;
        private float timePast;
        private float maxTime = 1.5f;
        private int numberOfFrames = 24;
        private int FramesX = 4;
        private int frameSize;
        private float scale = 0.7f;
        Camera camera;

        public ExplotionParticle(Viewport viewPort, Vector2 Position, ContentManager content)
        {
            explosion = content.Load<Texture2D>("explosion");
            camera = new Camera(viewPort.Width, viewPort.Height);
            position = Position;
            frameSize = explosion.Bounds.Width / FramesX;
            scale = scale * camera.Scale;
        }

        public void Draw(SpriteBatch spriteBatch, float elapsedTime)
        {
            
            if (timePast >= maxTime + 1.5f)
            {
                timePast = 0;
            }
            timePast += elapsedTime;
            float percentAnimated = timePast / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);
            int frameX = frame % FramesX;
            int frameY = frame / FramesX;
            Vector2 scalePos = camera.scaleVector(position.X, position.Y);

            spriteBatch.Begin();
            spriteBatch.Draw(explosion, new Rectangle((int)scalePos.X - (int)scale / 2, (int)scalePos.Y - (int)scale / 2, (int)scale, (int)scale), new Rectangle(frameX * frameSize, frameY * frameSize, frameSize, frameSize), Color.White);
            spriteBatch.End();
        }
    }
}
