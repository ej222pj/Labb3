using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._2.Content.View
{
    class SmokeSystem
    {        
        private Camera camera;
        private Texture2D smokeTexture;
        private List<SmokeParticle> particles = new List<SmokeParticle>();
        private float totalTime = 0;
        private static float delay = 0.2f;
        private Vector2 position;

        public SmokeSystem(Vector2 Position, ContentManager content, Camera Camera)
        {
            camera = Camera;
            position = Position;
            smokeTexture = content.Load<Texture2D>("particlesmoke");
        }

        public void Update(float timeElapsed)
        {
            totalTime += timeElapsed;

            if (totalTime >= delay)
            {
                totalTime = 0;
            
            particles.Add(new SmokeParticle(position));
            }

            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Update(timeElapsed);

                if (particles[i].ParticleIsDead())
                {
                    particles[i].Respawn();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw(spriteBatch, smokeTexture, camera);
            }
        }
    }
}
