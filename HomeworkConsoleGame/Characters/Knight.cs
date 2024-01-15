using System;
using HomeworkConsoleGame;

namespace HomeworkConsoleGame.Characters
{
	internal class Knight : Player
	{
        public override int Hp { get; set; } = 120;
        public override int Lvl { get; set; } = 1;
        public override int Damage { get; set; } = 70;
        public override int AttackSpeed { get; set; } = 2600;

        public Knight(string name) : base(name, new List<EquipmentSize>() { EquipmentSize.Large, EquipmentSize.ExtraLarge})
		{
		}
	}
}