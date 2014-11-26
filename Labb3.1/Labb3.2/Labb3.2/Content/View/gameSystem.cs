using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Labb3._2.Content.View
{
    class GameSystem
    {
        private Vector2 position;
        private SplitterSystem splitterSystem;

        public GameSystem(ContentManager content, Vector2 Position, Camera camera )
        {
            splitterSystem = new SplitterSystem(Position, content, camera);
            
        }

        public void Update(float timeElapsed) 
        {
            splitterSystem.Update(timeElapsed);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            splitterSystem.Draw(spriteBatch);
        }
    }
}