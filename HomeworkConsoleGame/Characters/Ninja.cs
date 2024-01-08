using System;
using HomeworkConsoleGame;

namespace HomeworkConsoleGame.Characters
{
	internal class Ninja : Player
	{
		public Ninja(string name, int hp = 100, int lvl = 1, int damage = 56, int attackSpeed = 2500) : base(hp, lvl, damage, name, new List<EquipmentSize>() { EquipmentSize.Medium, EquipmentSize.Small }, attackSpeed)
        {
		}
	}
}

