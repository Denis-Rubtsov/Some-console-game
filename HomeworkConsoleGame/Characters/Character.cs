using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Character
{
    public virtual int Hp { get; protected set; }
    public virtual int Lvl { get; protected set; }
    public virtual int Damage { get; protected set; }
    public virtual int Gold { get; set; }
    public double GlobalProtection { get; protected set; }
    public string Name { get; protected set; }
    public virtual int AttackSpeed { get; protected set; }

    public Character(int hp, int lvl, int damage, string name, int gold, int attackSpeed, double globalProtection)
    {
        Hp = hp;
        Lvl = lvl;
        Damage = damage;
        Name = name;
        Gold = gold;
        AttackSpeed = attackSpeed;
        GlobalProtection = globalProtection;
    }

    protected Character() { }

    public string GetInfo()
    {
        return $"{Name}   hp: {Hp}, level: {Lvl}, damage: {Damage}, gold: {Gold}, Protection: {GlobalProtection * 100}%";
    }

    public void Attack(Character target)
    {
        target.Hp -= (int)(Damage * (1 - target.GlobalProtection));
    }
}