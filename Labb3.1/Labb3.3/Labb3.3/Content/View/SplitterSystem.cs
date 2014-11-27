using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._3.Content.View
{
    class SplitterSystem
    {
        private SplitterParticle[] particles;
        private int maxPartical = 200;
        private static float maxSpeed = 0.3f;
        private Camera camera;
        private Vector2 position;
        private Texture2D splitterTexture;

        public SplitterSystem(Vector2 Position, ContentManager content, Camera Camera)
        {
            camera = Camera;

            particles = new SplitterParticle[maxPartical];
            position = Position;

            splitterTexture = content.Load<Texture2D>("spark");

            newExplotion();
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

        public void Update(float timeElapsed)
        {
            for (int i = 0; i < maxPartical; i++)
            {
                particles[i].Update(timeElapsed);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < maxPartical; i++)
            {
                particles[i].Draw(spriteBatch, splitterTexture, camera);
            }
        }
    }
}
