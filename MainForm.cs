/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 10/5/2024
 * Time: 9:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace linesMagneticsDistance
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public Graphics g;
		public Pen p = new Pen(Color.Red,1);
		public Font f;
		public Brush b = new SolidBrush(Color.Black);
		
		
		public double GetDistance(double x1, double y1, double x2, double y2)
		{
		   return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
		}
		
		public int ismousedown = 0;
		public int startx ;
		public int starty ;
		public int currentx;
		public int currenty;
		public string direction = "stop";
		
		
		void MainFormLoad(object sender, EventArgs e)
		{
			g = this.panel1.CreateGraphics();
			f = this.Font;
			
		}
		void Panel1MouseMove(object sender, MouseEventArgs e)
		{
			if(ismousedown==1)
			{
				
				g.Clear(this.panel1.BackColor);
				
				
				currentx = e.X;
				currenty = e.Y;
				int x = currentx - startx;
				int y = currenty - starty;
			
				
				double distanta = GetDistance((double)startx,(double)starty,(double)currentx,(double)currenty);
				
				Text = distanta.ToString() + " ";
				
				
				g.DrawLine(p,100,100,e.X, e.Y);
				g.DrawLine(p,100-50,100-50,e.X-50, e.Y-50);
				g.DrawLine(p,100+50,100+50,e.X+50, e.Y+50);
				g.DrawLine(p,100+50,100,e.X+50, e.Y);
				g.DrawLine(p,100,100+50,e.X, e.Y+50);
				g.DrawString(GetDistance(100,100,e.X, e.Y).ToString(),f,b,e.X, e.Y);
			
				
				g.DrawLine(p,startx,starty,currentx,currenty);
			
			}
		}
		void Panel1MouseDown(object sender, MouseEventArgs e)
		{
			ismousedown=1;
			startx = e.X;
			starty = e.Y;
		}
		void Panel1MouseUp(object sender, MouseEventArgs e)
		{
			ismousedown=0;
		}
	}
}
