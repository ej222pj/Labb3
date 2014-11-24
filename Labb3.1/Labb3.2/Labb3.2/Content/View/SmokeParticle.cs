using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._2.Content.View
{
    class SmokeParticle
    {
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 speed;
        private static float maxSpeed = 0.2f;

        private float timeLived = 0;
        private float size = 0;
        private float maxTimeToLive = 3.0f;
        private float lifePercent;
        private float minSize = 3f;
        private float maxSize = 6f;
        private float rotation = 0;

        public SmokeParticle()
        {
            speed = new Vector2(0, -0.3f);
            Respawn();
        }

        public void Respawn()
        {
            position = new Vector2(0.5f, 1.0f);

            Random rand = new Random();
            velocity = new Vector2(((float)rand.NextDouble() - 0.5f), ((float)rand.NextDouble() - 0.5f));
            velocity.Normalize();
            velocity = velocity * ((float)rand.NextDouble() * maxSpeed);
        }

        public bool ParticleIsDead()
        {
            return timeLived >= maxTimeToLive;
        }

        public void Update(float timeElapsed)
        {
            rotation += 0.02f;

            timeLived += timeElapsed;
            lifePercent = timeLived / maxTimeToLive;
            size = minSize + lifePercent * maxSize;

            Vector2 newPos = new Vector2();
            Vector2 newVel = new Vector2();

            newVel.X = velocity.X + timeElapsed * speed.X;
            newVel.Y = velocity.Y + timeElapsed * speed.Y;

            newPos.X = position.X + timeElapsed * velocity.X;
            newPos.Y = position.Y + timeElapsed * velocity.Y;

            velocity = newVel;
            position = newPos;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D smokeTexture, Camera camera)
        {
            float t = timeLived / maxTimeToLive;
            if (t > 1.0f)
            {
                t = 1.0f;
            }

            float startValue = 1.0f;
            float endValue = 0.0f;

            float fade = endValue * t + (1.0f - t) * startValue;

            Color color = new Color(fade, fade, fade, fade);

            Vector2 origin = new Vector2(smokeTexture.Bounds.Width / 2, smokeTexture.Bounds.Height / 2);

            spriteBatch.Begin();
            spriteBatch.Draw(smokeTexture, camera.scaleVector(position.X, position.Y), new Rectangle(0, 0, smokeTexture.Bounds.Width, smokeTexture.Bounds.Height), color, rotation, origin, size, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
