using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    internal class Store
    {
        readonly List<IEquippable> _items = new();

        public Store(List<IEquippable> items)
        {
            _items = items;
        }
        public void Buy(Player player)
        {
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < _items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. " + _items[i].GetInfo());
                }
                Console.WriteLine("Select item (number, beginning with 1; 0 - exit)");
                var choice = int.Parse(Console.ReadLine());
                if (choice == 0) return;
                if (_items[choice - 1].Coast > player.Gold)
                {
                    Console.WriteLine("Not enough gold!");
                    Console.ReadKey();
                }
                else
                {
                    if (player.AllowableSizes.Contains(_items[choice - 1].Size))
                    {
                        player.AddToInventory(_items[choice - 1]);
                        player.Gold -= _items[choice - 1].Coast;
                        Console.WriteLine("Use item? (1 - yes, 2 - no)");
                        var equip = int.Parse(Console.ReadLine());
                        if (equip == 1)
                        {
                            player.Equip(_items[choice - 1]);
                        }

                        _items.RemoveAt(choice - 1);
                    }
                    else { Console.WriteLine("Invalid size!"); Console.ReadKey(); }
                }
            }
        }
    }
}
