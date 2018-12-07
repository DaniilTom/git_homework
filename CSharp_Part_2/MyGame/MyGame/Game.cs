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

        Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(ResourceImage.space, new Rectangle(0, 0, Width, Height));
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            _bullet.Draw();

            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();

            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();

                    //т.к. нельзя напрямую изменить Pos пули (protected)
                    // присвоим переменной ссылку на новый объект
                    // и скопируем всю информацию, какую сможем;
                    // тогда новый экземпляр будет (в целом) идентичен предыдущему
                    _bullet = new Bullet(
                        new Point(0, _bullet.Rect.Top),
                        new Point(5, 0),
                        _bullet.Rect.Size
                        );

                    // с астероидом не так просто, ведь переменная "a" используется в foreach
                    for(int i = 0; i < _asteroids.Length; i++)
                    {
                        if (a == _asteroids[i]) // узнаем, на какой элемент ссылается Asteroid "a" цикла foreach
                            _asteroids[i] = new Asteroid( // также создадим новый объект
                                new Point(Width, _asteroids[i].Rect.Top),   // вытаскиваем инфу об астероиде
                                _asteroids[i].Direction, // направление создается ранодмно, поэтому пришлось добавить
                                _asteroids[i].Rect.Size               // св-во, которое возвращает это направление
                                );
                    }

                    // но это не совсем правильно: менять объект перечисляемой foreach коллекции;
                    // поэтому все тоже самое лучше сделать в цикле for
                }
            }


            //for (int i = 0; i < _asteroids.Length; i++)
            //{
            //    _asteroids[i].Update();
            //    if (_asteroids[i].Collision(_bullet))
            //    {
            //        System.Media.SystemSounds.Hand.Play();

            //        _bullet = new Bullet(
            //            new Point(0, _bullet.Rect.Top),
            //            new Point(5, 0),
            //            _bullet.Rect.Size
            //            );

            //        _asteroids[i] = new Asteroid(
            //            new Point(Width, _asteroids[i].Rect.Top),
            //            _asteroids[i].Direction,
            //            _asteroids[i].Rect.Size
            //            );
            //    }
            //}

            _bullet.Update();
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
    }
}
