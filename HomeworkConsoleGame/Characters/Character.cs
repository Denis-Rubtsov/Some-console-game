using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Character
{
    public int Hp { get; set; }
    public int Lvl { get; set; }
    public int Damage { get; set; }
    public int Gold { get; set; }
    public double GlobalProtection { get; set; }
    public string Name { get; set; }
    public int AttackSpeed { get; set; }

    public Character(int hp, int lvl, int damage, string name, int gold, int attackSpeed)
    {
        Hp = hp;
        Lvl = lvl;
        Damage = damage;
        Name = name;
        Gold = gold;
        AttackSpeed = attackSpeed;
    }

    public virtual string GetInfo()
    {
        return $"Здоровье: {Hp}, уровень: {Lvl}, урон: {Damage}, золото: {Gold}";
    }

    public void Attack(Character target)
    {
        target.Hp -= (int)(Damage * (1 - target.GlobalProtection));
    }
}