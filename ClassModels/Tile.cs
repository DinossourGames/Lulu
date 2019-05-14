using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    class Tile
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public bool IsPlayer { get; private set; }

        public bool IsLocked { get; private set; }
        public Tile(int x, int y, bool isPlayer, bool isLocked)
        {
            X = x;
            Y = y;
            IsPlayer = isPlayer;
            IsLocked = isLocked;
        }

    }
}
