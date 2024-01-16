using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame.Characters
{
    internal class MiniBoss : Enemy
    {
        public MiniBoss(string name, int hp, int LVL, int damage, int gold, int attackSpeed = 4000) : base($"Miniboss {name}", hp, LVL, damage, gold, attackSpeed, 0.2) { }
    }
}
