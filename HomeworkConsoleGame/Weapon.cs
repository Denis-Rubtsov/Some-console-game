using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    internal struct Weapon : IEquippable
    {
        Type _type = Type.Weapon;
        public Size Size;
        public int coast;
        int AttackDamage;
        public int Parameter { get { return this.AttackDamage; } }
        public int Coast
        {
            get
            {
                return this.coast;
            }
        }
        public Type Type {get {return _type;}}

        public Weapon(Size size)
        {
            Size = size;
            SetCoast();
            SetAttackDamage();
        }

        void SetCoast()
        {
            if (this.Size == Size.Small) this.coast = 50;
            if (this.Size == Size.Medium) this.coast = 150;
            if (this.Size == Size.Large) this.coast = 250;
            if (this.Size == Size.ExtraLarge) this.coast = 350;
        }

        void SetAttackDamage()
        {
            if (this.Size == Size.Small) this.AttackDamage = 5;
            if (this.Size == Size.Medium) this.AttackDamage = 10;
            if (this.Size == Size.Large) this.AttackDamage = 15;
            if (this.Size == Size.ExtraLarge) this.AttackDamage = 20;
        }

        public string GetInfo()
        {
            return $"Оружие Размер: {Size}, стоимость: {Coast}, атака: +{AttackDamage}%";
        }
    }
}
