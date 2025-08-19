using System.Drawing;
using PhysicsBallWinFormsLibrary;

namespace AngryBirdsWinFormsApp
{
    public partial class GameForm : Form
    {
        static Graphics graphics;
        static Random random = new Random();

        Bird bird;
        Pig pig;

        static bool isStrech = false;
        static bool isUsing = false;

        static bool shouldPlus = false;

        public GameForm()
        {
            InitializeComponent();
            DoubleBuffered = true;

            graphics = CreateGraphics();

            Ball.pen = new Pen(Color.Black);
            Ball.formPen = new Pen(BackColor);
            Ball.formBrush = new SolidBrush(BackColor);
            Ball.form = this;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            CreateNewBird();
        }

        public void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Math.Pow(e.X - bird.centerX, 2) + Math.Pow(e.Y - bird.centerY, 2) <= MathF.Pow(bird.radius, 2) && !isUsing)
            {
                isStrech = true;
            }
        }
        public void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isStrech)
            {
                bird.Clear();

                bird.x = e.Location.X - bird.radius;
                bird.y = e.Location.Y - bird.radius;

                if (bird.x < 23)
                    bird.x = 23;

                if (bird.x > 103)
                    bird.x = 103;


                if (bird.y > 325)
                    bird.y = 325;

                if (bird.y < 245)
                    bird.y = 245;

            }
        }
        public void GameForm_MouseUp(object sender, MouseEventArgs e)
        {
            isStrech = false;
            isUsing = true;

            bird.Vx = 63 - bird.x;
            bird.Vy = 285 - bird.y;

            bird.g = 2.5f;

            bird.isFly = true;
        }

        public void CreateNewBird() 
        {
            pig?.timer.Stop();
            pig?.Clear();

            graphics.Clear(BackColor);

            isUsing = false;

            scoreLabel.Text = shouldPlus ? (int.Parse(scoreLabel.Text) + 1).ToString() : (int.Parse(scoreLabel.Text) - 1).ToString();

            shouldPlus = false;

            bird = new Bird(63, 285, 30, 0, 0, 0, Color.Red, CreateNewBird);
            bird.timer.Interval = 25;
            Bird.IsTouched = ChekcColision;

            pig = new Pig(random.Next(280, 280 + 454), random.Next(49, 49 + 261), 30, 0, 0, 0, Color.Green);

            bird.Show();
            pig.Show();
        }

        public bool ChekcColision() 
        {
            if (MathF.Abs(bird.centerX - pig.centerX) <= bird.radius + pig.radius && MathF.Abs(bird.centerY - pig.centerY) <= bird.radius + pig.radius) 
            {
                shouldPlus = true;
                return true;
            }
            return false;
        }

        public void ChangeAndClear() 
        {

        }
    }
}
