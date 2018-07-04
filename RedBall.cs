using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

class RedBall : Form
{
    private int ballx = 150;
    private int bally = 150;
    private int ballxspeed = 7;
    private int ballyspeed = 5;
    private int pdellx = 50;
    private int score = 0;
    private int bestscore = 0;
    private int finallscore = 0;
    bool satrted, gameover;

   // Jocker programming language...

    public static void Main()
    {
        Application.Run(new RedBall());
    }

    public RedBall()
    {
        Text = "RedBall..";
        ClientSize = new Size(800, 600);
        ForeColor = SystemColors.WindowText;
        BackColor = SystemColors.Window;
        FormBorderStyle = FormBorderStyle.Fixed3D;
        MaximizeBox = false;

        //ResizeRedraw = true;

        Timer timer = new Timer();
        timer.Interval = 18;
        timer.Tick += new EventHandler(TimerOn);
        timer.Start();

    }

    protected override void OnMouseMove(MouseEventArgs e)
    {

        pdellx = e.X-10;
        ResizeRedraw = true;
    }
    protected override void OnKeyDown(KeyEventArgs e)
    {

        if (e.KeyData == Keys.Left)
        {
            pdellx = e.GetHashCode();
        }
    }
    protected virtual void TimerOn(object obj, EventArgs ea)
    {
        Graphics graf = CreateGraphics();
        Brush brush = new SolidBrush(Color.Cyan);
        Point pt = new Point();
        Rectangle rect = new Rectangle(0, 0,800, 600);
        // graf.FillEllipse(brush, rect);
        graf.FillRectangle(brush, rect);
        graf.FillRectangle(new SolidBrush(Color.Green), new Rectangle(0, 550,800, 100));
        graf.FillEllipse(new SolidBrush(Color.Red), new Rectangle(ballx, bally, 30, 30));
        graf.FillRectangle(new SolidBrush(ForeColor), new Rectangle(pdellx, 520, 100, 20));
        graf.Dispose();

        ballx = ballx + ballxspeed;
        bally = bally + ballyspeed;

        if ((ballx >= pdellx) && (ballx <= pdellx + 100) && (bally >= 500))
        {
            ballyspeed = -7;
        }

        if (bally >= 600)
        {
            bally = 30;
            gameover = true;
        }

        if (bally <= 0)
        {
            ballyspeed = 7;
        }

        if (ballx >= 775)
        {
            ballxspeed = -5;
        }

        if (ballx <= 0)
        {
            ballxspeed = 5;
        }

       // ResizeRedraw = true;
    }

    

}
