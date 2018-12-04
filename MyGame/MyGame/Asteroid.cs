using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Asteroid : BaseObject
    {
        Bitmap asteroidImage;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            asteroidImage = new Bitmap(ResourceImage.asteroid, size);
            
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(asteroidImage, Pos);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
