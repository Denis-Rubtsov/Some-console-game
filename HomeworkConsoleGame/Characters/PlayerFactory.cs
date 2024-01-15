using System;
namespace HomeworkConsoleGame.Characters
{
	internal interface IPlayerFactory
	{
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
            return new Assassin(name);
        }

        public Knight CreateKnight()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            return new Knight(name);
        }

        public Ninja CreateNinja()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            return new Ninja(name);
        }
    }
}

