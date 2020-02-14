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
    public class Paddle
    {
    	private int xPosition;
    	private int yPosition;
    	private int width = 10;
    	private int height = 100;
    	private int speed = 3;
        private int points;

        public Paddle(int xPos, int yPos)
        {
	        xPosition = xPos; 
	        yPosition = yPos;
        }

        public Paddle()
        {
	        
        }

        public void Draw(Graphics g)
        {
	        g.FillRectangle(new SolidBrush(Color.White), xPosition, yPosition, width, height);
        }

        public int getX()
        {
	        return xPosition;
        }

        public int getY()
        {
	        return yPosition;
        }

        public int getSpeed()
        {
	        return speed;
	        
        }

        public int getWidth()
        {
	        return width;
        }

        public int getHeight()
        {
	        return height;
        }

        public int getPoints()
        {
	        return points;
        }

        public void setPoints(int x)
        {
	        points = x;
        }

        public void setX(int position)
        {
	        xPosition = position;
        }

        public void setY(int position)
        {
	        yPosition = position;
        }
    }
}