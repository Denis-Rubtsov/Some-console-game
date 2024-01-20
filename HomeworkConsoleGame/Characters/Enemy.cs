using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeworkConsoleGame
{
    internal abstract class Enemy : Character
    {
        public Enemy(string name, int hp, int LVL, int damage, int gold, int attackSpeed = 4000, double globalProtection = 0) : base(hp, LVL, damage, name, gold, attackSpeed, globalProtection) { }

    }
}
