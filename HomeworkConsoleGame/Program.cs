﻿namespace HomeworkConsoleGame
{
    internal class Program
    {
        static List<Enemy> GetEnemies(Character character)
        {
            string[] names = { "Rufus", "Bear", "Dakota", "Fido", "Vanya", "Samuel", "Koani", "Volodya", "Yiska", "Maggie", "Penny", "Saya", "Princess", "Abby", "Laila", "Sadie", "Olivia", "Starlight", "Talla" };
            Random random = new Random();
            List<Enemy> list = new List<Enemy>();
            for (int i = 1; i <= 3; i++)
            {
                list.Add(new Enemy(names[random.Next(0, names.Length)], random.Next(character.Hp, character.Hp + 100),
                    random.Next(character.Lvl, character.Lvl + 10), random.Next(character.Damage, character.Damage + 5),
                    random.Next(100, 500)));
            }
            return list;
        }
        static void Battle(Player player)
        {
            int choice;
            Console.Clear();
            List<Enemy> Enemies = GetEnemies(player);
            Console.WriteLine(player.GetInfo());
            Console.WriteLine("Информация о противниках:");
            for (int i = 0; i < Enemies.Count; i++)
            {
                Console.WriteLine($"{i + 1}." + Enemies[i].GetInfo());
            }
            Console.WriteLine("Выберете номер врага (0 - выход в меню)");
            int EnemyNumber = int.Parse(Console.ReadLine());
            if (EnemyNumber == 0) return;
            Enemy enemy = Enemies[EnemyNumber - 1];
            while (enemy.Hp > 0 && player.Hp > 0)
            {
                Console.Clear();
                Console.WriteLine("Игрок атакует...");
                int enemyHPBeforeAttack = enemy.Hp;
                Thread.Sleep(2500);
                player.Attack(enemy);
                Console.WriteLine($"Нанесено урона: {enemyHPBeforeAttack - enemy.Hp}");
                if (enemy.Hp > 0)
                {
                    Console.WriteLine("Враг атакует...");
                    int playerHPBeforeAttack = player.Hp;
                    Thread.Sleep(4000);
                    enemy.Attack(player);
                    Console.WriteLine($"Получено урона: {playerHPBeforeAttack - player.Hp}");
                    Console.WriteLine($"Ваше здоровье: {player.Hp}");
                    Console.WriteLine($"Здоровье противника: {enemy.Hp}");
                    if (player.Hp <= 0)
                    {
                        Console.WriteLine($"Победитель: {enemy.Name}");
                        break;
                    }
                    Console.WriteLine("Подлечиться? (1 - да, 2 - нет)");
                    var Healchoice = int.Parse(Console.ReadLine());
                    if (Healchoice == 2) continue;
                    else if (Healchoice == 1) player.Heal();
                }
                else Console.WriteLine("Победитель: игрок");
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
            }
            player.LevelUp(enemy.Lvl, enemy.Gold);
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Store store = new Store();
            Console.WriteLine("Введите количество здоровья");
            int HP = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите уровень");
            int LVL = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество наносимого урона");
            int Damage = int.Parse(Console.ReadLine());
            Player player = new Player(HP, LVL, Damage);
            while (player.Hp > 0)
            {
                Console.Clear();
                Console.WriteLine("----- Меню -----");
                Console.WriteLine("0. Выйти из игры");
                Console.WriteLine("1. Сразится с врагом");
                Console.WriteLine("2. Купить предмет");
                Console.WriteLine("3. Продать предмет");
                Console.WriteLine("4. Использовать предмет");
                Console.WriteLine("5. Посмотреть инвентарь\n");

                Console.WriteLine("----- Состояние -----");
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
