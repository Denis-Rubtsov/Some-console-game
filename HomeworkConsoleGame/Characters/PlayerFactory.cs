using System;
namespace HomeworkConsoleGame.Characters
{
	internal interface IPlayerFactory
	{
        public Knight CreateDefaultKnight();
        public Assassin CreateDefaultAssassin();
        public Ninja CreateDefaultNinja();
        public Knight CreateKnight();
        public Assassin CreateAssassin();
        public Ninja CreateNinja();
    }

    internal class PlayerFactory : IPlayerFactory
    {
        public Assassin CreateAssassin()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter hp");
            int hp = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter level");
            int lvl = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter damage");
            int damage = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter attack time in milliseconds");
            int attackSpeed = int.Parse(Console.ReadLine());
            return new Assassin(name, hp, lvl, damage, attackSpeed);
        }

        public Assassin CreateDefaultAssassin()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            return new Assassin(name);
        }

        public Knight CreateDefaultKnight()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            return new Knight(name);
        }

        public Ninja CreateDefaultNinja()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            return new Ninja(name);
        }

        public Knight CreateKnight()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter hp");
            int hp = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter level");
            int lvl = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter damage");
            int damage = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter attack time in milliseconds");
            int attackSpeed = int.Parse(Console.ReadLine());
            return new Knight(name, hp, lvl, damage, attackSpeed);
        }

        public Ninja CreateNinja()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter hp");
            int hp = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter level");
            int lvl = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter damage");
            int damage = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter attack time in milliseconds");
            int attackSpeed = int.Parse(Console.ReadLine());
            return new Ninja(name, hp, lvl, damage, attackSpeed);
        }
    }
}

