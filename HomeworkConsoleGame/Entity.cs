using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    public class Entity
    {
        public int HP;
        public int LVL;
        public int Damage;
        public int Gold;
        public double GlobalProtection = 0;

        public Entity(int hp, int lvl, int damage)
        {
            HP = hp;
            LVL = lvl;
            Damage = damage;
        }

        public virtual string GetInfo()
        {
           return $"Здоровье: {HP}, уровень: {LVL}, урон: {Damage}, золото: {Gold}";
        }

        public void Attack(Entity entity)
        {
            entity.HP -= (int)(Damage * (1 - entity.GlobalProtection));
        }
    }
}
