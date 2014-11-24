using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._2.Content.View
{
    class SplitterSystem
    {
        private SplitterParticle[] particles;
        private int maxPartical = 100;
        private float time = 0;
        private static float runTime = 3;
        private static float maxSpeed = 0.4f;
        private Camera camera;
        private Vector2 position;
        private Texture2D splitterTexture;

        public SplitterSystem(Viewport viewPort, Vector2 Position, ContentManager content)
        {
            camera = new Camera(viewPort.Width, viewPort.Height);

            particles = new SplitterParticle[maxPartical];
            position = Position;

            splitterTexture = content.Load<Texture2D>("spark");

            newExplotion();
        }
        private void newSystem()
        {
            Random rand = new Random();

            for (int i = 0; i < maxPartical; i++)
            {
                Vector2 direction = new Vector2(((float)rand.NextDouble() - 0.5f), ((float)rand.NextDouble() - 0.5f));
                direction.Normalize();
                direction = direction * ((float)rand.NextDouble() * maxSpeed);

                particles[i] = new SplitterParticle(direction, position);
            }
        }

        private void newExplotion()
        {
            Random rand = new Random();

            for (int i = 0; i < maxPartical; i++)
            {
                Vector2 direction = new Vector2(((float)rand.NextDouble() - 0.5f), ((float)rand.NextDouble() - 0.5f));
                direction.Normalize();
                direction = direction * ((float)rand.NextDouble() * maxSpeed);

                particles[i] = new SplitterParticle(direction, position);
            }
        }

        public void Draw(SpriteBatch spriteBatch, float timeElapsed)
        {
            time += timeElapsed;

            for (int i = 0; i < maxPartical; i++)
            {
                particles[i].Update(timeElapsed);
            }
            if (time > runTime)
            {
                time = 0;
                newExplotion();
            }

            for (int i = 0; i < maxPartical; i++)
            {
                particles[i].Draw(spriteBatch, splitterTexture, camera);
            }
        }
    }
}
