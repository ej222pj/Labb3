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
        private List<SmokeParticle> particles = new List<SmokeParticle>();
        private float totalTime = 0;
        private static float delay = 0.2f;

        public SmokeSystem(Viewport viewPort)
        {
            camera = new Camera(viewPort.Width, viewPort.Height);
        }

        public void Update(float timeElapsed)
        {
            totalTime += timeElapsed;

            if (totalTime >= delay)
            {
                totalTime = 0;
            
            particles.Add(new SmokeParticle());
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

        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw(spriteBatch, splitterTexture, camera);
            }
        }
    }
}
