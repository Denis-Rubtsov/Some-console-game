using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame.Characters
{
    internal class EnemyFactory
    {
        public DefaultEnemy CreateDefaultEnemy(string name, int hp, int LVL, int damage, int gold, int attackSpeed = 4000)
        {
            DefaultEnemy enemy = new(name, hp, LVL, damage, gold, attackSpeed);
            return enemy;
        }

        public Boss CreateBoss(string name, int hp, int LVL, int damage, int gold, int attackSpeed = 4000)
        {
            Boss boss = new(name, hp, LVL, damage, gold, attackSpeed);
            return boss;
        }

        public MiniBoss CreateMiniBoss(string name, int hp, int LVL, int damage, int gold, int attackSpeed = 4000)
        {
            MiniBoss miniBoss = new(name, hp, LVL, damage, gold, attackSpeed);
            return miniBoss;
        }
    }
}
