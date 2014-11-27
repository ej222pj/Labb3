using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Labb3._3.Content.View
{
    class GameSystem
    {
        private SplitterSystem splitterSystem;
        private SmokeSystem smokeSystem;

        public GameSystem(ContentManager content, Vector2 Position, Camera camera)
        {
            splitterSystem = new SplitterSystem(Position, content, camera);
            smokeSystem = new SmokeSystem(Position, content, camera);
        }

        public void Update(float timeElapsed) 
        {
            splitterSystem.Update(timeElapsed);
            smokeSystem.Update(timeElapsed);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            splitterSystem.Draw(spriteBatch);
            smokeSystem.Draw(spriteBatch);
        }
    }
}