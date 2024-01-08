using System;
using HomeworkConsoleGame;

namespace HomeworkConsoleGame.Characters
{
	internal class Assassin : Player
	{
		public Assassin(string name, int hp = 100, int lvl = 1, int damage = 56, int attackSpeed = 2500) : base(hp, lvl, damage, name, new List<EquipmentSize>() { EquipmentSize.Medium, EquipmentSize.Large }, attackSpeed)
		{
		}
	}
}