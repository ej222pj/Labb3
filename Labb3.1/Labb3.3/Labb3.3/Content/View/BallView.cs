using Labb3._3.Content.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._3.Content.View
{
    class BallView
    {
        private SpriteBatch spriteBatch;
        private Texture2D deadBallTexture;
        private Texture2D aliveBallTexture;

        private Camera camera;

        public BallView(GraphicsDevice graphicsDevice, ContentManager content, Camera Camera)
        {    
            camera = Camera;

            spriteBatch = new SpriteBatch(graphicsDevice);
            aliveBallTexture = content.Load<Texture2D>("SpinningBeachBallOfDeath");
            deadBallTexture = content.Load<Texture2D>("DeadSpinningBeachBallOfDeath");
        }

        internal void drawLevel(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor, Texture2D pixel, int borderSize) 
        {  
            spriteBatch.Begin();

            int extraFrameX = 0;
            int extraFrameY = 0;
            if (rectangleToDraw.Height > rectangleToDraw.Width)
            {
                extraFrameX = rectangleToDraw.Height - rectangleToDraw.Width;
            }
            if (rectangleToDraw.Width > rectangleToDraw.Height) 
            {
                extraFrameY = rectangleToDraw.Width - rectangleToDraw.Height;
            }
            
            
            //Sätter en bakgrund
            //spriteBatch.Draw(background, new Rectangle(0, 0, m_windowWidth , m_windowHeight ), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);

            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X + thicknessOfBorder, rectangleToDraw.Y + thicknessOfBorder, rectangleToDraw.Width - extraFrameY - (thicknessOfBorder * 2), borderSize), borderColor);
            
            //// Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X + thicknessOfBorder, rectangleToDraw.Y + thicknessOfBorder, borderSize, rectangleToDraw.Height - (thicknessOfBorder * 2) - extraFrameX), borderColor);
 
            //// Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder - extraFrameY), rectangleToDraw.Y + thicknessOfBorder, borderSize, rectangleToDraw.Height - (thicknessOfBorder * 2) - extraFrameX), borderColor);

            //// Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X + thicknessOfBorder, rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder - extraFrameX, rectangleToDraw.Width - extraFrameY - (thicknessOfBorder * 2), borderSize), borderColor);
            spriteBatch.End();
        }

        internal void drawBall(float centerX, float centerY, float diameter, bool isDead)
        {
            int vx = (int)(centerX * camera.Scale + camera.getFrame());
            int vy = (int)(centerY * camera.Scale + camera.getFrame());
            int ballSize = (int)(diameter * camera.Scale);

            Rectangle newBall = new Rectangle(vx - ballSize / 2, vy - ballSize / 2, ballSize, ballSize);

            Texture2D ballTexture;
            ballTexture = aliveBallTexture;

            if (isDead)
            {
                ballTexture = deadBallTexture;
            }

            spriteBatch.Begin();
            spriteBatch.Draw(ballTexture, newBall, Color.White);             
            spriteBatch.End();
        }
    }
}