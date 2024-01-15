using System;
using HomeworkConsoleGame;

namespace HomeworkConsoleGame.Characters
{
	internal class Assassin : Player
	{
        public override int Hp { get; set; } = 110;
        public override int Lvl { get; set; } = 1;
        public override int Damage { get; set; } = 56;
        public override int AttackSpeed { get; set; } = 2500;

        public Assassin(string name) : base(name, new List<EquipmentSize>() { EquipmentSize.Medium, EquipmentSize.Large })
		{
		}
	}
}