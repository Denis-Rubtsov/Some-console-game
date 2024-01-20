using System;
using HomeworkConsoleGame;

namespace HomeworkConsoleGame.Characters
{
	internal class Knight : Player
	{
        public override int Hp { get; protected set; } = 120;
        public override int Lvl { get; protected set; } = 1;
        public override int Damage { get; protected set; } = 70;
        public override int AttackSpeed { get; protected set; } = 2600;

        public Knight(string name) : base(name, new List<EquipmentSize>() { EquipmentSize.Large, EquipmentSize.ExtraLarge})
		{
		}
	}
}