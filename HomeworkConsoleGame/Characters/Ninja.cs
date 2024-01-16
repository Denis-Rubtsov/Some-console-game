using System;
using HomeworkConsoleGame;

namespace HomeworkConsoleGame.Characters
{
	internal class Ninja : Player
	{
        public override int Hp { get; protected set; } = 100;
        public override int Lvl { get; protected set; } = 1;
        public override int Damage { get; protected set; } = 42;
        public override int AttackSpeed { get; protected set; } = 2400;

        public Ninja(string name) : base(name, new List<EquipmentSize>() { EquipmentSize.Medium, EquipmentSize.Small })
        {
		}
	}
}

