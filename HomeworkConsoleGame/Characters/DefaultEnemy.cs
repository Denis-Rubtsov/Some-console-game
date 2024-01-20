using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame.Characters
{
    internal class DefaultEnemy : Enemy
    {
        public DefaultEnemy(string name, int hp, int LVL, int damage, int gold, int attackSpeed = 4000, double globalProtection = 0) : base(name, hp, LVL, damage, gold, attackSpeed) { }
    }
}
