using HomeworkConsoleGame.Characters;
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

    protected Dictionary<AttackDirections, int> _chanceOfCriticalDamage = new()
    {
        [AttackDirections.Head] = 20,
        [AttackDirections.Torso] = 25,
        [AttackDirections.Hands] = 30,
        [AttackDirections.Legs] = 40
    };

    protected virtual double CriticalDamageCoefficient { get; set; } = 1.2;

    protected static Dictionary<AttackDirections, int> _chanceOfMiss = new()
    {
        [AttackDirections.Head] = 20,
        [AttackDirections.Torso] = 5,
        [AttackDirections.Hands] = 10,
        [AttackDirections.Legs] = 8
    };

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

    public void Attack(Character target, AttackDirections attackDirection)
    {
        Random random = new();
        var missChance = random.Next(1, 101);
        if (missChance <= _chanceOfMiss[attackDirection]) throw new MissException("Character missed");
        var criticalDamageChance = random.Next(1, 101);
        if (criticalDamageChance <= _chanceOfCriticalDamage[attackDirection])
        {
            target.Hp -= (int)(Damage * (1 - target.GlobalProtection) * CriticalDamageCoefficient);
            Console.WriteLine("Critical damage!");
        }
        target.Hp -= (int)(Damage * (1 - target.GlobalProtection));
    }
}