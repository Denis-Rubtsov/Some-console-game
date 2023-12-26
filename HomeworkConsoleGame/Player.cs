using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    internal class Player : Entity
    {
        public int MaxHP;
        public List<IEquippable> Inventory = new List<IEquippable>();
        public Dictionary<string, IEquippable?> Equipped = new Dictionary<string, IEquippable?>()
        {
            ["Шлем"] = null,
            ["Нагрудник"] = null,
            ["Поножи"] = null,
            ["Ботинки"] = null,
            ["Оружие"] = null
        };
        public Player(int hp, int lvl, int damage) : base(hp, lvl, damage)
        {
            MaxHP = HP;
            Gold = 200;
        }

        public void Heal()
        {
            this.HP = this.MaxHP;
        }
        public void LevelUp(Entity entity)
        {
            this.LVL = Convert.ToInt32(Math.Round(Convert.ToDouble(Math.Abs(this.LVL - entity.LVL)/2)));
            this.MaxHP = Convert.ToInt32(1.25 * (MaxHP + 1));
            this.Damage = Convert.ToInt32(1.3 * (Damage + 1));
            this.Gold += entity.Gold;
            UseItems();
        }
        public void Equip(IEquippable Item)
        {
            if (Item.Type == Type.Helmet) Equipped["Шлем"] = Item;
            if (Item.Type == Type.Bib) Equipped["Нагрудник"] = Item;
            if (Item.Type == Type.Leggins) Equipped["Поножи"] = Item;
            if (Item.Type == Type.Boots) Equipped["Ботинки"] = Item;
            if (Item.Type == Type.Weapon) Equipped["Оружие"] = Item;

            UseItems();
        }

        void UseItems()
        {
            foreach (var i in Equipped)
            {
                if (i.Value != null)
                {
                    if (i.Value is Armor) this.GlobalProtection += Convert.ToDouble(i.Value.Parameter) / 100;
                    if (i.Value is Weapon) this.Damage = (int)(Convert.ToDouble(this.Damage) * (1 + Convert.ToDouble(i.Value.Parameter) / 100));
                }
            }
        }

        public void ShowInventory(bool fromMenu)
        {
            Console.Clear();
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. " + Inventory[i].GetInfo());
            }
            Console.WriteLine("\nИспользуется:");
            foreach (var i in Equipped)
            {
                if (i.Value != null)
                {
                    Console.WriteLine($"{i.Key}: {i.Value.GetInfo()}");
                }
            }
            if (fromMenu)
            {
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        public void Sell()
        {
            int goldFromSelling = 0;
            ShowInventory(false);
            Console.WriteLine("Выберите предмет на продажу (номер, начиная с 1; 0 - все; -1 - отмена");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                foreach (var i in Inventory) goldFromSelling += i.Coast;
            }
            else if (choice == -1) return;
            else goldFromSelling = Inventory[choice - 1].Coast;
            this.Gold += goldFromSelling;
        }

        public void EquipItemFromInventory()
        {
            Console.Clear();
            List<IEquippable> accessibleItems = new List<IEquippable>();
            foreach (var i in Inventory)
            {
                if (Equipped.ContainsValue(i)) continue;
                else accessibleItems.Add(i);
            }
            for (int i = 0; i <accessibleItems.Count; i++)
            {
                Console.WriteLine($"{i+1}. " + accessibleItems[i]);
            }
            Console.WriteLine("Введите номер предмета, который хотите использовать (начиная с 1; 0 - выход в меню)");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0) return;
            Equip(accessibleItems[choice - 1]);
        }
    }
}
