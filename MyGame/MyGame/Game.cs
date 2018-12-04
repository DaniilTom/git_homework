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
        /*
         * Томашевич
         * 
         * 1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон,
         *          похожий на полет в звездном пространстве.
         * 2. *Заменить кружочки картинками, используя метод DrawImage.
         * */

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static BaseObject[] _objs;

        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game() { }

        public static void Init(Form form)
        {
            Graphics g;


            _context = BufferedGraphicsManager.Current;

            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            /*Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Render();*/

        Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(ResourceImage.space, new Rectangle(0, 0, Width, Height));
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

        public static void Load()
        {
            Random rnd = new Random(); // процедурная генерация некоторых объектов фона

            _objs = new BaseObject[30];

            for (int i = 0; i < _objs.Length / 3; i++)

                //пояс астероидов сверху
                _objs[i] = new Asteroid(
                    new Point(600, i * rnd.Next(1, 20)), 
                    new Point(15 - i, 15 - i), 
                    new Size(rnd.Next(5, 40), rnd.Next(5, 40))
                    );

            for (int i = _objs.Length / 3; i < 2 * (_objs.Length / 3); i++)
                _objs[i] = new Star(
                    new Point(600, i * 20),
                    new Point(i, 0),
                    new Size(5, 5)
                    );

            for (int i = 2 * (_objs.Length / 3); i < _objs.Length; i++)
            {
                int _size = rnd.Next(5, 15);

                _objs[i] = new StarEight(   
                    new Point(600, i * rnd.Next(1, 20)),
                    new Point(rnd.Next(1, 30), 0),
                    new Size(_size, _size)
                    );
            }
        }
    }
}
