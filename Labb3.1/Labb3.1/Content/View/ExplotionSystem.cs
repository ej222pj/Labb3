using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Labb3._1.Content.View
{
    class ExplotionSystem
    {
        private Vector2 position;
        private ShockwaveParticle shockwaveParticle;
        private SplitterSystem splitterSystem;
        private ExplotionParticle explotionParicle;

        public ExplotionSystem(Viewport viewPort, ContentManager content)
        {
            position = new Vector2(0.5f, 0.5f);
            shockwaveParticle = new ShockwaveParticle(viewPort, position, content);
            splitterSystem = new SplitterSystem(viewPort, position, content);
            explotionParicle = new ExplotionParticle(viewPort, position, content);                
        }

        public void Draw(SpriteBatch spriteBatch, float timeElapsed)
        {
            shockwaveParticle.Draw(spriteBatch, timeElapsed);
            splitterSystem.Draw(spriteBatch, timeElapsed);
            explotionParicle.Draw(spriteBatch, timeElapsed);
        }
    }
}
