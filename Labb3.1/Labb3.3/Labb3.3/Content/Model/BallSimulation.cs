using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._3.Content.Model
{
    class BallSimulation
    {
        public List<Ball> ballList;
        private int numberOfBalls = 10;
        float mouseArea = 0.3f;

        public BallSimulation()
        {
            ballList = new List<Ball>();
            Random random = new Random();

            for (int i = 0; i < numberOfBalls; i++) 
            {
                //(maxpos, minpos)
                float centerX = (float)random.NextDouble() * (1.0f - 0.5f) + 0.1f;
                float centerY = (float)random.NextDouble() * (1.0f - 0.5f) + 0.1f;

                //(maxspeed, minspeed)
                float speedX = (float)random.NextDouble() * (0.7f - 0.2f) + 0.1f;
                float speedY = (float)random.NextDouble() * (0.7f - 0.1f) + 0.1f;

                ballList.Add(new Ball(centerX, centerY, speedX, speedY));
            }
        }
        public void ballsInsideMouseArea(Vector2 mousePos)
        {
            foreach (var ball in ballList)
            {
                if (ball.CenterX + ball.Diameter / 2 > mousePos.X - mouseArea /2 &&
                    ball.CenterX - ball.Diameter / 2 < mousePos.X + mouseArea /2 &&
                    ball.CenterY + ball.Diameter / 2 > mousePos.Y - mouseArea /2 &&
                    ball.CenterY - ball.Diameter / 2 < mousePos.Y + mouseArea /2)
                {
                    ball.IsDead = true;
                }
            }
        }

       internal void update(float elapsedTime)
       {
           foreach (var ball in ballList)
           {
               if (!ball.IsDead)
               {
                   ball.CenterX += ball.SpeedX * elapsedTime;

                   if (ball.CenterX + ball.Diameter / 2 > 1.0f)
                   {
                       ball.SpeedX = ball.SpeedX * -1.0f;
                   }
                   if (ball.CenterX - ball.Diameter / 2 < 0.0f)
                   {
                       ball.SpeedX = ball.SpeedX * -1.0f;
                   }

                   ball.CenterY += ball.SpeedY * elapsedTime;

                   if (ball.CenterY + ball.Diameter / 2 > 1.0f)
                   {
                       ball.SpeedY = ball.SpeedY * -1.0f;
                   }
                   if (ball.CenterY - ball.Diameter / 2 < 0.0f)
                   {
                       ball.SpeedY = ball.SpeedY * -1.0f;
                   }
               }
           }
       }

       public float getMouseArea
       {
           get { return mouseArea; }
       }
    }
}
