using System.Drawing;
using PhysicsBallWinFormsLibrary;

namespace AngryBirdsWinFormsApp
{
    public partial class GameForm : Form
    {
        static Graphics graphics;
        static Random random = new Random();

        static Bird bird;
        static Pig pig;

        static bool isStrech = false;
        static bool isUsing = false;

        public GameForm()
        {
            InitializeComponent();

            graphics = CreateGraphics();

            Ball.graphics = graphics;
            Ball.pen = new Pen(Color.Black);
            Ball.formPen = new Pen(BackColor);
            Ball.formBrush = new SolidBrush(BackColor);
            Ball.form = this;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            bird = new Bird(63, 285, 30, 0, 0, 0, Color.Red);
            pig = new Pig(random.Next(280, 280 + 454), random.Next(49, 49 + 261), 30, 0, 0, 0, Color.Green);

            bird.Show();
            pig.Show();
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
                {
                    bird.x = 23;
                    //bird.y = e.Location.Y - bird.radius;
                }

                if (bird.x > 103)
                {
                    bird.x = 103;
                    //bird.y = e.Location.Y - bird.radius;
                }


                if (bird.y > 285 + 40)
                {
                    bird.y = 285 + 40;
                    //bird.x = e.Location.X - bird.radius;
                }

                if (bird.y < 285 - 40)
                {
                    bird.y = 285 - 40;
                    //bird.x = e.Location.X - bird.radius;
                }

            }
        }
        public void GameForm_MouseUp(object sender, MouseEventArgs e)
        {
            isStrech = false;
            isUsing = true;

        }


    }
}
