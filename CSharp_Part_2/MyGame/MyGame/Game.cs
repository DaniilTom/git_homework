using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    static class Game
    {
        private static int width;
        private static int height;

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;

        public static int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Ширина экрана не может быть отрицательной");
                // не понятно задание с исключением, ведь Width присваивается разрешение монитора (см. строку 16 Program.cs)
                // обычно в наши дни это побольше 1000
                //if (value > 1000) throw new ArgumentOutOfRangeException("");
                else width = value;
            }
        }
        public static int Height
        {
            get => height;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Высота экрана не может быть отрицательной");
                else height = value;
            }
        }

        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(100, 100));

        static Game() { }

        private static Timer timer = new Timer { Interval = 100 };
        public static Random Rnd = new Random();

        public static void Init(Form form)
        {
            Graphics g;


            _context = BufferedGraphicsManager.Current;

            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            //Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;

            Ship.MessageDie += Finish;
            
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(
                new Point(_ship.Rect.X + _ship.Rect.Width, _ship.Rect.Y + _ship.Rect.Height /2),
                new Point(4, 0),
                new Size(4, 1));

            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

        private static void Form_KeyUp(object sender, KeyEventArgs e)
        {
            _ship.Reset();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {

            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(ResourceImage.space, new Rectangle(0, 0, Width, Height));
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }
            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Buffer.Render();
        }

        public static void Update()
        {
            foreach(BaseObject obj in _objs) obj.Update();

            _bullet?.Update();

            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullet = null;
                    continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                var rnd = new Random();
                _ship?.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship?.Die();
            }
        }

        public static void Load()
        {
            Random rnd = new Random(); // процедурная генерация некоторых объектов фона

            _objs = new BaseObject[30];

            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[3];

            for (int i = 0; i < _objs.Length / 3; i++)

                //пояс астероидов сверху
                _objs[i] = new Meteor(
                    new Point(600, i * rnd.Next(1, 20)), 
                    new Point(15 - i, 15 - i), 
                    new Size(rnd.Next(5, 40), rnd.Next(5, 40))
                    );

            for (int i = _objs.Length / 3; i < 2 * (_objs.Length / 3); i++)
                _objs[i] = new Star(
                    new Point(600, i * rnd.Next(0, 50)),
                    new Point(i, 0),
                    new Size(5, 5)
                    );

            for (int i = 2 * (_objs.Length / 3); i < _objs.Length; i++)
            {
                int _size = rnd.Next(5, 15);

                _objs[i] = new StarEight(   
                    new Point(600, i * rnd.Next(1, 30)),
                    new Point(rnd.Next(1, 30), 0),
                    new Size(_size, _size)
                    );
            }

            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(
                    new Point(1000, rnd.Next(0, Game.Height)),
                    new Point(-r / 5, r),
                    new Size(r, r)
                    );
            }
        }

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
    }
}
