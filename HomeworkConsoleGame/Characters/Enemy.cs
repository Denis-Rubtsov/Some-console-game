﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeworkConsoleGame
{
    internal class Enemy : Character
    {
        public string Name;
        public Enemy(string name, int hp, int LVL, int damage, int gold) : base(hp, LVL, damage)
        {
            Name = name;
            Gold = gold;
        }

        public override string GetInfo()
        {
            return $"{Name}   здоровье: {Hp}, уровень: {Lvl}, урон: {Damage}, золото {Gold}";
        }
    }
}
