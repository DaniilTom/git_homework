using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    /// <summary>
    /// Базовый класс для отрисовываемых объектов. Определяет методы <see cref="Draw()"/>
    /// и <see cref="Update()"/>
    /// </summary>
    abstract class BaseObject
    {
        /// <summary>
        /// Хранит текущую позицию на холсте.
        /// </summary>
        protected Point Pos;

        /// <summary>
        /// Определяет велечину перемещения за один кадр.
        /// </summary>
        protected Point Dir;

        /// <summary>
        /// Хранит размеры объекта.
        /// </summary>
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        /// <summary>
        /// Выполняет отрисовку объекта в буффер.
        /// </summary>
        public abstract void Draw();


        /// <summary>
        /// Выполняет расчет перемещения объекта.
        /// </summary>
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
