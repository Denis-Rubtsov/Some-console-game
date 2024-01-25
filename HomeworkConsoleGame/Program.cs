using HomeworkConsoleGame.Characters;
using System.Net.Http.Headers;
namespace HomeworkConsoleGame
{
    internal class Program
    {
        static List<IEquippable> SellingItems()
        {
            Random random = new();
            List<IEquippable> defaultItems = new();
            defaultItems.Add(new Armor(EquipmentType.Helmet, EquipmentSize.Small));
            defaultItems.Add(new Armor(EquipmentType.Helmet, EquipmentSize.Medium));
            defaultItems.Add(new Armor(EquipmentType.Helmet, EquipmentSize.Large));
            defaultItems.Add(new Armor(EquipmentType.Helmet, EquipmentSize.ExtraLarge));
            defaultItems.Add(new Armor(EquipmentType.Bib, EquipmentSize.Small));
            defaultItems.Add(new Armor(EquipmentType.Bib, EquipmentSize.Medium));
            defaultItems.Add(new Armor(EquipmentType.Bib, EquipmentSize.Large));
            defaultItems.Add(new Armor(EquipmentType.Bib, EquipmentSize.ExtraLarge));
            defaultItems.Add(new Armor(EquipmentType.Leggins, EquipmentSize.Small));
            defaultItems.Add(new Armor(EquipmentType.Leggins, EquipmentSize.Medium));
            defaultItems.Add(new Armor(EquipmentType.Leggins, EquipmentSize.Large));
            defaultItems.Add(new Armor(EquipmentType.Leggins, EquipmentSize.ExtraLarge));
            defaultItems.Add(new Armor(EquipmentType.Boots, EquipmentSize.Small));
            defaultItems.Add(new Armor(EquipmentType.Boots, EquipmentSize.Medium));
            defaultItems.Add(new Armor(EquipmentType.Boots, EquipmentSize.Large));
            defaultItems.Add(new Armor(EquipmentType.Boots, EquipmentSize.ExtraLarge));
            defaultItems.Add(new Weapon(EquipmentSize.Small));
            defaultItems.Add(new Weapon(EquipmentSize.Medium));
            defaultItems.Add(new Weapon(EquipmentSize.Large));
            defaultItems.Add(new Weapon(EquipmentSize.ExtraLarge));
            var maxItems = defaultItems.Count;
            List<IEquippable> itemsToSale = new();
            for (int i = 0; i < random.Next(1,maxItems); i++)
            {
                var index = random.Next(-1, defaultItems.Count);
                if (index == -1) continue;
                itemsToSale.Add(defaultItems[index]);
            }
            return itemsToSale;
        }
        static Enemy GenerateEnemy(Character character, bool isBoss)
        {
            EnemyFactory enemyFactory = new EnemyFactory();
            string[] names = { "Rufus", "Bear", "Dakota", "Fido", "Vanya", "Samuel", "Koani", "Volodya", "Yiska", "Maggie", "Penny", "Saya", "Princess", "Abby", "Laila", "Sadie", "Olivia", "Starlight", "Talla", "Robert de Sablé", "Cesare Borgia", "Charles Lee", "Vieri Pazzi" };
            Random random = new Random();
            Enemy enemy = null;
            for (int i = 1; i <= 3; i++)
            {
                if (!isBoss)
                {
                    int enemyGenerationSeed = random.Next(1, 101);
                    if (enemyGenerationSeed >= 1 && enemyGenerationSeed <= 80)
                    {
                        enemy = enemyFactory.CreateDefaultEnemy(names[random.Next(0, names.Length)],
                                                             random.Next(character.Hp, character.Hp + 100),
                                                             random.Next(character.Lvl, character.Lvl + 10),
                                                             random.Next(character.Damage, character.Damage + 5),
                                                             random.Next(100, 500),
                                                             random.Next(2500, 3000));
                    }
                    if (enemyGenerationSeed >= 81 && enemyGenerationSeed <= 100)
                    {
                        enemy = enemyFactory.CreateMiniBoss(names[random.Next(0, names.Length)],
                                                             random.Next(2 * character.Hp, 2 * character.Hp + 100),
                                                             random.Next(character.Lvl, character.Lvl + 10),
                                                             random.Next(character.Damage, character.Damage + 10),
                                                             random.Next(100, 500),
                                                             random.Next(2500, 3000));
                    }
                }
                if (isBoss)
                {
                    enemy = enemyFactory.CreateBoss(names[random.Next(0, names.Length)],
                                                         random.Next(3 * character.Hp, 3 * character.Hp + 100),
                                                         random.Next(character.Lvl, character.Lvl + 10),
                                                         random.Next(character.Damage, character.Damage + 20),
                                                         random.Next(100, 500),
                                                         random.Next(2500, 3000));
                }
            }
            return enemy;
        }
        static void Battle(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine(player.GetInfo());
            while (enemy.Hp > 0 && player.Hp > 0)
            {
                Console.Clear();
                Console.WriteLine("Select attack direction");
                Console.WriteLine("1. Head");
                Console.WriteLine("2. Torso");
                Console.WriteLine("3. Hands");
                Console.WriteLine("4. Legs");
                var attackDirectionChoice = int.Parse(Console.ReadLine());
                var attackDirection = (AttackDirections)attackDirectionChoice;
                Console.WriteLine("Player attacks...");
                int enemyHPBeforeAttack = enemy.Hp;
                Thread.Sleep(player.AttackSpeed);
                try { player.Attack(enemy, attackDirection); }
                catch{Console.WriteLine("You missed");}
                Console.WriteLine($"Damage done: {enemyHPBeforeAttack - enemy.Hp}");
                if (enemy.Hp > 0)
                {
                    Random random = new();
                    Console.WriteLine("Enemy attacks...");
                    int playerHPBeforeAttack = player.Hp;
                    Thread.Sleep(enemy.AttackSpeed);
                    var enemyAttackDirection = (AttackDirections)random.Next(1, 5);
                    try { enemy.Attack(player, enemyAttackDirection); }
                    catch { Console.WriteLine("Enemy missed"); }
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
            List<string> maps = new List<string>() {"Map1.txt", "Map2.txt", "Map3.txt", "Map4.txt"};
            string path = "";
            Map map = new();
            Player player = null;
            int completedLevels = 0;
            bool died = false;
            Store store;
            foreach (var i in Directory.GetCurrentDirectory().Split('\\'))
            {
                if (i == "bin") { break; }
                path += $"{i}\\";
            }
            PlayerFactory playerFactory = new();
            Console.WriteLine(path);
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
            Random random = new();
            for (int i = 0; i < maps.Count; i++)
            {
                map.LoadMapFromFile($"{path}\\Resources\\" + maps[i]);
                player.Position = new(1, 1);
                while(!died)
                {
                    Console.Clear();
                    map.PrintMap();
                    var key = Console.ReadKey();
                    try
                    {
                        switch (key.Key)
                        {
                            case ConsoleKey.W:
                                player.Gold += map.MovePlayer(ref player.Position, player.Position.Plus(0, -1));
                                break;
                            case ConsoleKey.S:
                                player.Gold += map.MovePlayer(ref player.Position, player.Position.Plus(0, 1));
                                break;
                            case ConsoleKey.A:
                                player.Gold += map.MovePlayer(ref player.Position, player.Position.Plus(-1, 0));
                                break;
                            case ConsoleKey.D:
                                player.Gold += map.MovePlayer(ref player.Position, player.Position.Plus(1, 0));
                                break;
                        }
                    }
                    catch (BattleException)
                    {
                        var enemy = GenerateEnemy(player, false);
                        Battle(player, enemy);
                        if (player.Hp <= 0) died = true;
                    }
                    catch (BossBattleException)
                    {
                        var boss = GenerateEnemy(player, true);
                        Battle(player, boss);
                    }
                    catch (StoreException)
                    {
                        store = new(SellingItems());
                        store.Buy(player);
                    }
                    catch (EndOfLevelException)
                    {
                        break;
                    }
                    if (random.Next(1, 101) <= 30) map.MoveEnemy();
                    if (player.Hp <= 0) died = true;
                }
                if (died)
                {
                    Console.WriteLine("Game over");
                    break;
                }
                completedLevels++;
            }
            if (completedLevels == 4)
            {
                Console.WriteLine("You won!");
            }
            //while (player.Hp > 0)
            //{
                //Console.Clear();
                //Console.WriteLine("----- Menu -----");
                //Console.WriteLine("0. Exit from game");
                //Console.WriteLine("1. Fight the enemy");
                //Console.WriteLine("2. Buy item");
                //Console.WriteLine("3. Sell item");
                //Console.WriteLine("4. Use item");
                //Console.WriteLine("5. View inventory\n");

                //Console.WriteLine("----- Player's info -----");
                //Console.WriteLine(player.GetInfo());

                //int choice = int.Parse(Console.ReadLine());
                //if (choice == 0) break;
                //else if (choice == 1)
                //{
                    //Battle(player);
                //}
                //else if (choice == 2) store.Buy(player);
                //else if (choice == 3) player.Sell();
                //else if (choice == 4) player.EquipItemFromInventory();
                //else if (choice == 5) player.ShowInventory(true);
            //}
            Console.ReadKey();
        }
    }
}
