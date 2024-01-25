using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    public struct Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Plus(int plusX, int plusY)
        {
            return new Position(X + plusX, Y + plusY);
        }

        public override bool Equals(object obj)
        {
            var otherPosition = (Position)obj;
            if (otherPosition.X == X && otherPosition.Y == Y) return true;
            return false;
        }
    }
}
