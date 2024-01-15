using HomeworkConsoleGame;

internal class Player : Character
{
    protected const int DefaultGold = 200;

    protected int _maxHp;
    protected readonly List<IEquippable> _inventory = new();
    protected readonly Dictionary<EquipmentType, IEquippable?> _equipped = new();
    public virtual List<EquipmentSize> AllowableSizes { get; init; }
    public override int Gold { get; set; } = 200;

    public Player(string name, List<EquipmentSize> allowableSizes)
    {
        _maxHp = Hp;
        AllowableSizes = allowableSizes;
        Name = name;
    }

    public void Heal()
    {
        Hp = _maxHp;
    }

    public void LevelUp(int enemyLevel, int enemyGold)
    {
        Lvl = Convert.ToInt32(Math.Round(Convert.ToDouble(Math.Abs(Lvl - enemyLevel) / 2)));
        _maxHp = Convert.ToInt32(1.25 * (_maxHp + 1));
        Damage = Convert.ToInt32(1.3 * (Damage + 1));
        Gold += enemyGold;
    }

    public void Equip(IEquippable item)
    {
        _equipped[item.EquipmentType] = item;

        UseItems();
    }

    public void ShowInventory(bool fromMenu)
    {
        Console.Clear();
        for (int i = 0; i < _inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. " + _inventory[i].GetInfo());
        }

        Console.WriteLine("\nEquipped:");
        foreach (var i in _equipped)
        {
            if (i.Value != null)
            {
                Console.WriteLine($"{i.Key}: {i.Value.GetInfo()}");
            }
        }

        if (fromMenu)
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }

    public void Sell()
    {
        int goldFromSelling = 0;
        ShowInventory(false);
        Console.WriteLine("Select the number of item for sale (beggining with 1; 0 - sell all items; -1 - cancel sale");
        int choice = int.Parse(Console.ReadLine());

        if (choice > _inventory.Count)
        {
            Console.WriteLine("There is no item with this number");
            return;
        }
        
        switch (choice)
        {
            case 0:
            {
                goldFromSelling += _inventory.Sum(i => i.Coast);
                _inventory.Clear();
                break;
            }
            case -1:
                return;
            default:
                goldFromSelling = _inventory[choice - 1].Coast;
                _inventory.RemoveAt(choice);
                break;
        }

        Gold += goldFromSelling;
    }

    public void EquipItemFromInventory()
    {
        Console.Clear();
        List<IEquippable> accessibleItems = new List<IEquippable>();
        foreach (var i in _inventory)
        {
            if (_equipped.ContainsValue(i)) continue;
            accessibleItems.Add(i);
        }

        for (int i = 0; i < accessibleItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. " + accessibleItems[i]);
        }

        Console.WriteLine("Enter the number of the item you want to use (beggining with 1; 0 - exit)");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 0) return;
        Equip(accessibleItems[choice - 1]);
    }

    public void AddToInventory(IEquippable item) => _inventory.Add(item);
    
    protected void UseItems()
    {
        foreach (var i in _equipped.Where(i => i.Value != null))
        {
            switch (i.Value)
            {
                case Armor:
                    GlobalProtection += Convert.ToDouble(i.Value.Parameter) / 100;
                    break;
                case Weapon:
                    Damage = (int)(Convert.ToDouble(Damage) * (1 + Convert.ToDouble(i.Value.Parameter) / 100));
                    break;
            }
        }
    }
}