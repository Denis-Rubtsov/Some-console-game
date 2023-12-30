using HomeworkConsoleGame;

internal class Player : Character
{
    private const int DefaultGold = 200;

    private int _maxHp;
    private readonly List<IEquippable> _inventory = new();
    private readonly Dictionary<EquipmentType, IEquippable?> _equipped = new();

    public Player(int hp, int lvl, int damage) : base(hp, lvl, damage)
    {
        _maxHp = Hp;
        Gold = DefaultGold;
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

        Console.WriteLine("\nИспользуется:");
        foreach (var i in _equipped)
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

        if (choice > _inventory.Count)
        {
            Console.WriteLine("lox");
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

        Console.WriteLine("Введите номер предмета, который хотите использовать (начиная с 1; 0 - выход в меню)");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 0) return;
        Equip(accessibleItems[choice - 1]);
    }

    public void AddToInventory(IEquippable item) => _inventory.Add(item);
    
    private void UseItems()
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