using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    internal class Store
    {
        List<IEquippable> Items = new List<IEquippable>();

        public Store()
        {
            Items.Add(new Armor(Type.Helmet,Size.Small));
            Items.Add(new Armor(Type.Helmet,Size.Medium));
            Items.Add(new Armor(Type.Helmet,Size.Large));
            Items.Add(new Armor(Type.Helmet,Size.ExtraLarge));
            Items.Add(new Armor(Type.Bib, Size.Small));
            Items.Add(new Armor(Type.Bib, Size.Medium));
            Items.Add(new Armor(Type.Bib, Size.Large));
            Items.Add(new Armor(Type.Bib, Size.ExtraLarge));
            Items.Add(new Armor(Type.Leggins, Size.Small));
            Items.Add(new Armor(Type.Leggins, Size.Medium));
            Items.Add(new Armor(Type.Leggins, Size.Large));
            Items.Add(new Armor(Type.Leggins, Size.ExtraLarge));
            Items.Add(new Armor(Type.Boots, Size.Small));
            Items.Add(new Armor(Type.Boots, Size.Medium));
            Items.Add(new Armor(Type.Boots, Size.Large));
            Items.Add(new Armor(Type.Boots, Size.ExtraLarge));
            Items.Add(new Weapon(Size.Small));
            Items.Add(new Weapon(Size.Medium));
            Items.Add(new Weapon(Size.Large));
            Items.Add(new Weapon(Size.ExtraLarge));
        }
        public void Buy(Player player)
        {
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < Items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. " + Items[i].GetInfo());
                }
                Console.WriteLine("Выберите предмет (номер, начиная с 1; 0 - выход)");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0) return;
                else if (Items[choice - 1].Coast > player.Gold)
                {
                    Console.WriteLine("Недостаточно золота!");
                    continue;
                }
                else
                {
                    player.Inventory.Add(Items[choice - 1]);
                    player.Gold -= Items[choice - 1].Coast;
                    Console.WriteLine("Использовать? (1 - да, 2 -нет)");
                    int Equip = int.Parse(Console.ReadLine());
                    if (Equip == 1)
                    {
                        player.Equip(Items[choice - 1]);
                    }
                    else { }
                    Items.RemoveAt(choice - 1);
                }
            }
        }
    }
}
