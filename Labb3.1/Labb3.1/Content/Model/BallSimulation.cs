using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3._1.Content.Model
{
    class BallSimulation
    {
       Ball ball = new Ball();
       internal void update(float elapsedTime)
       {
            ball.m_x += elapsedTime * ball.speedX;

            if (ball.m_x + ball.diameter / 2 > 1.0f)
            {
                ball.speedX = ball.speedX * -1.0f;
            }
            if (ball.m_x - ball.diameter / 2 < 0.0f)
            {
                ball.speedX = ball.speedX * -1.0f;
            }

            ball.m_y += elapsedTime * ball.speedY;

            if (ball.m_y + ball.diameter / 2 > 1.0f)
            {
                ball.speedY = ball.speedY * -1.0f;
            }
            if (ball.m_y - ball.diameter / 2 < 0.0f)
            {
                ball.speedY = ball.speedY * -1.0f;
            }
       }
       public float getXPos()
       {
           return ball.m_x;
       }
       public float getYPos()
       {
           return ball.m_y;
       }
       public float getDiameter()
       {
           return ball.diameter;
       
       }
    }
}
