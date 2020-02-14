using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form
    {
	    public Random randomObject = new Random();
	    public Timer t = new Timer();
    	public Ball pongBall = new Ball(395, 295);
    	public Paddle right = new Paddle();
        public Paddle left = new Paddle();
        public int numberOfPointsToWin = 5;
        public Form1() {
	        InitializeComponent();
	        t.Interval = 30;
	        t.Enabled = true;
	        t.Tick += MainLoop;
	        right.setX(770);
	        right.setY(250);
	        left.setX(30);
	        left.setY(250);
	        pongBall.setXVelocity(randomObject.Next(0, pongBall.getMaxSpeed()*2) - pongBall.getMaxSpeed());
	        pongBall.setYVelocity(randomObject.Next(0, pongBall.getMaxSpeed()*2) - pongBall.getMaxSpeed());
	        pongBall.setXVelocity(-10);
	        pongBall.setYVelocity(0);
        }
        protected override void OnKeyDown(KeyEventArgs e) {
	        if (e.KeyCode == Keys.Escape)
	        {
		        Application.Exit(); return;
	        }
	        if (e.KeyCode == Keys.Enter)
	        {
		        t.Enabled = true;
	        }

	        if (e.KeyCode == Keys.W)
	        {
		        left.setY(left.getY() - left.getSpeed());
	        }

	        if (e.KeyCode == Keys.S)
	        {
		        left.setY(left.getY() + left.getSpeed());
	        }
	        if (e.KeyCode == Keys.Up)
	        {
		        right.setY(right.getY() - right.getSpeed());
	        }

	        if (e.KeyCode == Keys.Down)
	        {
		        right.setY(right.getY() + right.getSpeed());
	        }
        }
        private void MainLoop(object sender, EventArgs e){ 
        	/* Clears the Screen */
            CreateGraphics().FillRectangle(new SolidBrush(Color.Black), 0, 0, 800,600);
        	pongBall.Draw(this.CreateGraphics());    	
        	right.Draw(this.CreateGraphics());
            left.Draw(CreateGraphics());
            pongBall.calculate();
            if (pongBall.getX() <= 0)
            {
	            left.setPoints(left.getPoints() + 1);
	            if (left.getPoints() >= numberOfPointsToWin)
	            {
		            CreateGraphics().FillRectangle(new SolidBrush(Color.Black), 0, 0, 800,600);

		            CreateGraphics().DrawString("Right WINS!", new Font("Arial", 72), new SolidBrush(Color.White), new PointF(100, 100));
		            t.Enabled = false;
	            }
	            right.setX(770);
	            right.setY(250);
	            left.setX(30);
	            left.setY(250);
	            pongBall.setX(400);
	            pongBall.setY(300);
	            pongBall.setXVelocity((int) (randomObject.Next(4, pongBall.getMaxSpeed()*2) - pongBall.getMaxSpeed()));
	            pongBall.setYVelocity((int) (randomObject.Next(4, pongBall.getMaxSpeed()*2) - pongBall.getMaxSpeed()));
            }

            if (pongBall.getX() >= 800)
            {
	            right.setPoints(right.getPoints() + 1);
	            if (right.getPoints() >= numberOfPointsToWin)
	            {
		            CreateGraphics().FillRectangle(new SolidBrush(Color.Black), 0, 0, 800,600);

		            CreateGraphics().DrawString("LEFT WINS!", new Font("Arial", 72), new SolidBrush(Color.White), new PointF(90, 100));
		            t.Enabled = false;
		            return;
	            }
	            right.setX(770);
	            right.setY(250);
	            left.setX(30);
	            left.setY(250);
	            pongBall.setX(400);
	            pongBall.setY(300);
	            pongBall.setXVelocity((int) (randomObject.Next(4, pongBall.getMaxSpeed()*2) - pongBall.getMaxSpeed()));
	            pongBall.setYVelocity((int) (randomObject.Next(4, pongBall.getMaxSpeed()*2) - pongBall.getMaxSpeed()));

            }
            if(pongBall.getY() >= 600)
            {
	            pongBall.setYVelocity(-pongBall.getYVelocity());
            }
            if(pongBall.getY() <= 0)
            {
	            pongBall.setYVelocity(-pongBall.getYVelocity());
            }

            if (pongBall.getX() <= left.getX() + left.getWidth() && pongBall.getX() >= left.getX())
            {
	            if (pongBall.getY() <= left.getY() + left.getHeight() && pongBall.getY() >= left.getY())
	            {
		            pongBall.setXVelocity(-pongBall.getXVelocity());
	            }
            }
            if (pongBall.getX() <= right.getX() + right.getWidth() && pongBall.getX() >= right.getX())
            {
	            if (pongBall.getY() <= right.getY() + right.getHeight() && pongBall.getY() >= right.getY())
	            {
		            pongBall.setXVelocity(-pongBall.getXVelocity());
	            }
            }
            CreateGraphics().DrawString(right.getPoints() + "", new Font("Arial", 72), new SolidBrush(Color.White), new PointF(100, 100));
            CreateGraphics().DrawString(left.getPoints() + "", new Font("Arial", 72), new SolidBrush(Color.White), new PointF(600, 100));
            Console.WriteLine("Pong Ball Position - X: " + pongBall.getX() + " Y: " + pongBall.getY());
            Console.WriteLine("Paddle Left Position - X: " + left.getX() + " Y: " + left.getY());
            if (right.getPoints() >= numberOfPointsToWin)
            {
	            CreateGraphics().FillRectangle(new SolidBrush(Color.Black), 0, 0, 800,600);

	            CreateGraphics().DrawString("LEFT WINS!", new Font("Arial", 72), new SolidBrush(Color.White), new PointF(90, 100));
	            t.Enabled = false;
	            return;
            }
            if (left.getPoints() >= numberOfPointsToWin)
            {
	            CreateGraphics().FillRectangle(new SolidBrush(Color.Black), 0, 0, 800,600);

	            CreateGraphics().DrawString("Right WINS!", new Font("Arial", 72), new SolidBrush(Color.White), new PointF(100, 100));
	            t.Enabled = false;
	            return;
            }
        }

    }
}
 