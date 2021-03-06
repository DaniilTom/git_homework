﻿using MyGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    /// <summary>
    /// Базовый класс для отрисовываемых объектов. Определяет методы <see cref="Draw()"/>
    /// и <see cref="Update()"/>
    /// </summary>
    abstract class BaseObject : ICollision
    {
        /// <summary>
        /// Содержит текущую позицию на холсте.
        /// </summary>
        protected Point Pos;

        /// <summary>
        /// Определяет велечину перемещения за один кадр.
        /// </summary>
        protected Point Dir;

        /// <summary>
        /// Содержит размеры объекта.
        /// </summary>
        protected Size Size;

        public delegate void Message();

        protected BaseObject(Point pos, Point dir, Size size)
        {
            if (size.Height <= 0 && size.Width <= 0) throw new GameObjectException("Неверные размеры");
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
        public abstract void Update();

        /// <summary>
        /// Вовзращает объект в первоначальную позицию.
        /// </summary>
        public abstract void Reset();

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}
