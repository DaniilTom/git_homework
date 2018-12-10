using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    /// <summary>
    /// Описывает объект декорации "метеорит". Наследуется от <see cref="BaseObject"/>.
    /// В отличии от <see cref="Asteroid"/> не сталкивается с другими объектами.
    /// </summary>
    class Meteor : BaseObject
    {
        Bitmap meteorImage;

        /// <summary>
        /// Открытый конструктор. Подгружает картику из <see cref="ResourceImage"/> с
        /// название <see cref="ResourceImage.meteor"/>.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Meteor(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            meteorImage = new Bitmap(ResourceImage.meteor, size);
            
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(meteorImage, Pos);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Reset();
        }

        public override void Reset()
        {
            Pos.X = Game.Width + Size.Width;
        }
    }
}
