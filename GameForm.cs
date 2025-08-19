using System.Drawing;
using PhysicsBallWinFormsLibrary;

namespace AngryBirdsWinFormsApp
{
    public partial class GameForm : Form
    {
        static Graphics graphics;
        static Random random = new Random();

        static Bird bird = new Bird(63, 385, 30, 0, 0, 0.2f, Color.Red);
        static Pig pig = new Pig(random.Next(280, 280 + 454), random.Next(49, 49 + 261), 30, 0, 0, 0, Color.Green);

        static bool isStrech = false;
        static bool isUsing = false;

        public GameForm()
        {
            graphics = CreateGraphics();

            Ball.graphics = graphics;
            Ball.pen = new Pen(Color.Black);
            Ball.formPen = new Pen(BackColor);
            Ball.formBrush = new SolidBrush(BackColor);
            Ball.form = this;


            bird.Show();
            pig.Show();

            bird.timer.Start();
            pig.timer.Start();

            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            Ball ball = new Ball(10, 10, 100, 0, 0);
            ball.Show();

            bird.Show();
            pig.Show();
        }

        public void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Math.Pow(e.X - bird.centerX, 2) + Math.Pow(e.Y - bird.centerY, 2) <= MathF.Pow(bird.radius, 2) && !isUsing)
            {
                isStrech = true;
                bird.x = e.Location.X - bird.radius;
                bird.y = e.Location.Y - bird.radius;

            }
        }
        public void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isStrech)
            {

            }
        }
        public void GameForm_MouseUp(object sender, MouseEventArgs e)
        {
            isStrech = false;
            isUsing = true;
        }

        
    }
}
