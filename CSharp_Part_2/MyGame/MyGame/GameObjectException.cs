using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    /// <summary>
    /// Исключение, выбрасываемое при неправильном создании объектов типа <see cref="BaseObject"/>
    /// </summary>
    class GameObjectException : Exception
    {
        public GameObjectException() : base() { }
        public GameObjectException(string msg) : base(msg) { }
    }
}
