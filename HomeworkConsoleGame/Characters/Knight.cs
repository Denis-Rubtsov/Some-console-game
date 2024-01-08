using System;
using HomeworkConsoleGame;

namespace HomeworkConsoleGame.Characters
{
	internal class Knight : Player
	{
		public Knight(string name, int hp = 120, int lvl = 1, int damage = 70, int attackSpeed = 2600) : base(hp, lvl, damage, name, new List<EquipmentSize>() { EquipmentSize.Large, EquipmentSize.ExtraLarge}, attackSpeed)
		{
		}

	}
}