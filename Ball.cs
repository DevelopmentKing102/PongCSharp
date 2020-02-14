using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Pong
{
    public class Ball
    {
    	private int xPosition;
    	private int yPosition;
    	private int width = 10;
    	private int height = 10;
    	private int penWidth = 2;
    	private int xVelocity = 0;
    	private int yVelocity = 0;
    	private int maxVelocity = 40;
        public Ball() {}

        public Ball(int x, int y)
        {
	        xPosition = x; yPosition = y;
        }

        public int getX()
        {
	        return xPosition;
        }

        public int getY()
        {
	        return yPosition;
        }

        public void setX(int position)
        {
	        xPosition = position;
        }

        public void setY(int position)
        {
	        yPosition = position;
        }

        public void calculate()
        {
	        xPosition += xVelocity; yPosition += yVelocity;
        }

        public int getMaxSpeed()
        {
	        return maxVelocity;
        }

        public void setXVelocity(int x)
        {
	        xVelocity = x;
        }

        public void setYVelocity(int y)
        {
	        yVelocity = y;
        }

        public int getXVelocity()
        {
	        return xVelocity;
        }

        public int getYVelocity()
        {
	        return yVelocity;
        }

        public void Draw(Graphics g) {g.DrawRectangle(new Pen(Color.White, penWidth), xPosition, yPosition, width, height);}
    }
}