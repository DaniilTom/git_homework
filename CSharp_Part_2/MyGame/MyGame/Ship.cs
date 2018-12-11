using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    /// <summary>
    /// Описывает объект "корабль", управляемый игроком. Наследуется от <see cref="BaseObject"/>
    /// </summary>
    class Ship : BaseObject
    {
        public static event Message MessageDie;

        /// <summary>
        /// Содержит графические изображения корабля.
        /// </summary>
        ImageList ship = new ImageList();

        private int _energy = 100;
        public int Energy => _energy;

        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            // подгружаем спрайт с кораблем (после выполнения конструктора объект будет выгружен из стека)
            using (Bitmap allSprite = ResourceImage.allSpritesRes)
            {
                // укажем номер нужного изображения (условно, главный спрайт можно рассматривать как матрицу)
                // [0, 0] - прямолетящий корабль с включенными двигателями
                ship.Images.Add(CutTheSprite(0, 0, allSprite));
                ship.ImageSize = Size;//new Size(100, 100); // увеличим размер изображени (а то маленькие получаются)
            }
        }

        /// <summary>
        /// Вырезает из картинки нужную часть и возвращает ссылку на новый объект.
        /// </summary>
        /// <param name="imgColumn">Номер изображения по горизонтали</param>
        /// <param name="imgRow">Номер изображения по вертикали</param>
        /// <param name="src">Исходное изображение</param>
        /// <returns></returns>
        private Image CutTheSprite(int Column, int Row, Bitmap src)
        {
            // делить на 10, т.к. 10 изображений по ширине и высоте
            int spriteHeight = src.Height / 10;
            int spriteWidth = src.Width / 10;

            // для читаемости "упакуем" координаты верхнего левого угла изображения
            // и его размеры в соответствующие структуры
            Size spriteSize = new Size(spriteWidth, spriteHeight);
            Point TopLeft = new Point(Column * spriteWidth, Row * spriteHeight);

            // создадим структуру Rectangle для использования в методе Clone()
            Rectangle rect = new Rectangle(TopLeft, spriteSize);

            // клонируем область src и возвращаем новый объект
            // примечание: неверно выбранный формат выдаст OutOfMemoryException
            return src.Clone(rect, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        }

        public override void Draw()
        {
            //Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(ship.Images[0], Pos);
        }
        public override void Update()
        { }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }

        /// <summary>
        /// Реализация метода <see cref="BaseObject.Reset()"/> в классе <see cref="Ship"/> подразумевает
        /// установку изображения корабля, летящего вперед.
        /// </summary>
        public override void Reset() { }
    }
}
