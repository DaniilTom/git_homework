using MyGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    class FirsAidKit : BaseObject
    {
        Image img;

        public FirsAidKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = new Bitmap(ResourceImage.AidKit, size);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);
        }

        public override void Reset()
        {
            Pos.X = Game.Width + Size.Width;
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y += (int)(10 * Math.Sin(Pos.X/50) );
            if (Pos.X < 0) Reset();
        }
    }
}
