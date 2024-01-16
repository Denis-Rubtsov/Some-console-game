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

        public Store()
        {
            _items.Add(new Armor(EquipmentType.Helmet,EquipmentSize.Small));
            _items.Add(new Armor(EquipmentType.Helmet,EquipmentSize.Medium));
            _items.Add(new Armor(EquipmentType.Helmet,EquipmentSize.Large));
            _items.Add(new Armor(EquipmentType.Helmet,EquipmentSize.ExtraLarge));
            _items.Add(new Armor(EquipmentType.Bib, EquipmentSize.Small));
            _items.Add(new Armor(EquipmentType.Bib, EquipmentSize.Medium));
            _items.Add(new Armor(EquipmentType.Bib, EquipmentSize.Large));
            _items.Add(new Armor(EquipmentType.Bib, EquipmentSize.ExtraLarge));
            _items.Add(new Armor(EquipmentType.Leggins, EquipmentSize.Small));
            _items.Add(new Armor(EquipmentType.Leggins, EquipmentSize.Medium));
            _items.Add(new Armor(EquipmentType.Leggins, EquipmentSize.Large));
            _items.Add(new Armor(EquipmentType.Leggins, EquipmentSize.ExtraLarge));
            _items.Add(new Armor(EquipmentType.Boots, EquipmentSize.Small));
            _items.Add(new Armor(EquipmentType.Boots, EquipmentSize.Medium));
            _items.Add(new Armor(EquipmentType.Boots, EquipmentSize.Large));
            _items.Add(new Armor(EquipmentType.Boots, EquipmentSize.ExtraLarge));
            _items.Add(new Weapon(EquipmentSize.Small));
            _items.Add(new Weapon(EquipmentSize.Medium));
            _items.Add(new Weapon(EquipmentSize.Large));
            _items.Add(new Weapon(EquipmentSize.ExtraLarge));
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
