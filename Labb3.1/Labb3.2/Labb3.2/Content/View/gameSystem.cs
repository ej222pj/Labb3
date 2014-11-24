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
        Vector2 mousePos;

        public GameSystem(Viewport viewPort, ContentManager content)
        {
            position = new Vector2(0.5f, 0.5f);
            splitterSystem = new SplitterSystem(viewPort, position, content);
            
        }

        public void Draw(SpriteBatch spriteBatch, float timeElapsed)
        {
            
            splitterSystem.Draw(spriteBatch, timeElapsed);
        }
    }
}