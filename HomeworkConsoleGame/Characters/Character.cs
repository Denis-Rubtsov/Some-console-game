using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Character
{
    public virtual int Hp { get; set; }
    public virtual int Lvl { get; set; }
    public virtual int Damage { get; set; }
    public virtual int Gold { get; set; }
    public double GlobalProtection { get; set; }
    public string Name { get; set; }
    public virtual int AttackSpeed { get; set; }

    public Character(int hp, int lvl, int damage, string name, int gold, int attackSpeed)
    {
        Hp = hp;
        Lvl = lvl;
        Damage = damage;
        Name = name;
        Gold = gold;
        AttackSpeed = attackSpeed;
    }

    protected Character() { }

    public string GetInfo()
    {
        return $"{Name}   hp: {Hp}, level: {Lvl}, damage: {Damage}, gold: {Gold}";
    }

    public void Attack(Character target)
    {
        target.Hp -= (int)(Damage * (1 - target.GlobalProtection));
    }
}