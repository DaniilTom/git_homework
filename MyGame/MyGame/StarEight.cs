using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    /// <summary>
    /// Рисует восьмиконечную звезду, наследуется от Star
    /// </summary>
    class StarEight : Star
    {
        public StarEight(Point pos, Point dir, Size size) : base(pos, dir, size)
        { }

        public override void Draw()
        {
            base.Draw(); //рисует косое перекрестье, остается добавить еще две линии

            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width/2, Pos.Y - 5,
                                                      Pos.X + Size.Width/2, Pos.Y + Size.Height + 5);

            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X - 5, Pos.Y + Size.Height/2,
                                                        Pos.X + Size.Width + 5, Pos.Y + Size.Height/2);
        }
    }
}
