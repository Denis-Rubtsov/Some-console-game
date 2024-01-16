using HomeworkConsoleGame.Characters;
namespace HomeworkConsoleGame
{
    internal class Program
    {
        static List<Enemy> GetEnemies(Character character)
        {
            EnemyFactory enemyFactory = new EnemyFactory();
            string[] names = { "Rufus", "Bear", "Dakota", "Fido", "Vanya", "Samuel", "Koani", "Volodya", "Yiska", "Maggie", "Penny", "Saya", "Princess", "Abby", "Laila", "Sadie", "Olivia", "Starlight", "Talla" };
            Random random = new Random();
            List<Enemy> list = new List<Enemy>();
            for (int i = 1; i <= 3; i++)
            {
                int enemyGenerationSeed = random.Next(1,101);
                if(enemyGenerationSeed >= 1 && enemyGenerationSeed <= 80)
                {
                    list.Add(enemyFactory.CreateDefaultEnemy(names[random.Next(0, names.Length)],
                                                         random.Next(character.Hp, character.Hp + 100),
                                                         random.Next(character.Lvl, character.Lvl + 10),
                                                         random.Next(character.Damage, character.Damage + 5),
                                                         random.Next(100, 500),
                                                         random.Next(2500, 3000)));
                }
                if (enemyGenerationSeed >= 81 && enemyGenerationSeed <= 91)
                {
                    list.Add(enemyFactory.CreateMiniBoss(names[random.Next(0, names.Length)],
                                                         random.Next(2 * character.Hp, 2 * character.Hp + 100),
                                                         random.Next(character.Lvl, character.Lvl + 10),
                                                         random.Next(character.Damage, character.Damage + 10),
                                                         random.Next(100, 500),
                                                         random.Next(2500, 3000)));
                }
                if (enemyGenerationSeed >= 92 && enemyGenerationSeed <= 101)
                {
                    list.Add(enemyFactory.CreateBoss(names[random.Next(0, names.Length)],
                                                         random.Next(3 * character.Hp, 3 * character.Hp + 100),
                                                         random.Next(character.Lvl, character.Lvl + 10),
                                                         random.Next(character.Damage, character.Damage + 20),
                                                         random.Next(100, 500),
                                                         random.Next(2500, 3000)));
                }
            }
            return list;
        }
        static void Battle(Player player)
        {
            int choice;
            Console.Clear();
            List<Enemy> Enemies = GetEnemies(player);
            Console.WriteLine(player.GetInfo());
            Console.WriteLine("Enemies' info:");
            for (int i = 0; i < Enemies.Count; i++)
            {
                Console.WriteLine($"{i + 1}." + Enemies[i].GetInfo());
            }
            Console.WriteLine("Select enemy's number (0 - exit to menu)");
            int EnemyNumber = int.Parse(Console.ReadLine());
            if (EnemyNumber == 0) return;
            Enemy enemy = Enemies[EnemyNumber - 1];
            while (enemy.Hp > 0 && player.Hp > 0)
            {
                Console.Clear();
                Console.WriteLine("Player attacks...");
                int enemyHPBeforeAttack = enemy.Hp;
                Thread.Sleep(player.AttackSpeed);
                player.Attack(enemy);
                Console.WriteLine($"Damage done: {enemyHPBeforeAttack - enemy.Hp}");
                if (enemy.Hp > 0)
                {
                    Console.WriteLine("Enemy attacks...");
                    int playerHPBeforeAttack = player.Hp;
                    Thread.Sleep(4000);
                    enemy.Attack(player);
                    Console.WriteLine($"Damage taken: {playerHPBeforeAttack - player.Hp}");
                    Console.WriteLine($"Your hp: {player.Hp}");
                    Console.WriteLine($"Enemy's hp: {enemy.Hp}");
                    if (player.Hp <= 0)
                    {
                        Console.WriteLine($"Winner: {enemy.Name}");
                        break;
                    }
                    Console.WriteLine("Do you want to heal? (1 - yes, 2 - no)");
                    var Healchoice = int.Parse(Console.ReadLine());
                    if (Healchoice == 2) continue;
                    else if (Healchoice == 1) player.Heal();
                }
                else Console.WriteLine("Winner: player");
                Console.WriteLine("Prees any key to continue...");
                Console.ReadKey();
            }
            player.LevelUp(enemy.Lvl, enemy.Gold);
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Player player = null;
            Store store = new Store();
            PlayerFactory playerFactory = new();
            Console.WriteLine("Select class:");
            Console.WriteLine("1. Knight");
            Console.WriteLine("2. Assassin");
            Console.WriteLine("3. Ninja");
            var classChoice = int.Parse(Console.ReadLine());
            switch(classChoice)
            {
                case 1: player = playerFactory.CreateKnight(); break;
                case 2: player = playerFactory.CreateAssassin(); break;
                case 3: player = playerFactory.CreateNinja(); break;
            }
            while (player.Hp > 0)
            {
                Console.Clear();
                Console.WriteLine("----- Menu -----");
                Console.WriteLine("0. Exit from game");
                Console.WriteLine("1. Fight the enemy");
                Console.WriteLine("2. Buy item");
                Console.WriteLine("3. Sell item");
                Console.WriteLine("4. Use item");
                Console.WriteLine("5. View inventory\n");

                Console.WriteLine("----- Player's info -----");
                Console.WriteLine(player.GetInfo());

                int choice = int.Parse(Console.ReadLine());
                if (choice == 0) break;
                else if (choice == 1)
                {
                    Battle(player);
                }
                else if (choice == 2) store.Buy(player);
                else if (choice == 3) player.Sell();
                else if (choice == 4) player.EquipItemFromInventory();
                else if (choice == 5) player.ShowInventory(true);
            }
            Console.ReadKey();
        }
    }
}
