using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame.Characters
{
    internal class Boss :Enemy
    {
        public Boss(string name, int hp, int LVL, int damage, int gold, int attackSpeed = 4000) : base($"Boss {name}", hp, LVL, damage, gold, attackSpeed, 0.4) { }
    }
}
