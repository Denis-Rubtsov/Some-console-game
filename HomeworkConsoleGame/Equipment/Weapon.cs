using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    internal struct Weapon : IEquippable
    {
        EquipmentType _equipmentType = EquipmentType.Weapon;
        public EquipmentSize EquipmentSize;
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
        public EquipmentType EquipmentType {get {return _equipmentType;}}

        public Weapon(EquipmentSize equipmentSize)
        {
            EquipmentSize = equipmentSize;
            SetCoast();
            SetAttackDamage();
        }

        void SetCoast()
        {
            if (this.EquipmentSize == EquipmentSize.Small) this.coast = 50;
            if (this.EquipmentSize == EquipmentSize.Medium) this.coast = 150;
            if (this.EquipmentSize == EquipmentSize.Large) this.coast = 250;
            if (this.EquipmentSize == EquipmentSize.ExtraLarge) this.coast = 350;
        }

        void SetAttackDamage()
        {
            if (this.EquipmentSize == EquipmentSize.Small) this.AttackDamage = 5;
            if (this.EquipmentSize == EquipmentSize.Medium) this.AttackDamage = 10;
            if (this.EquipmentSize == EquipmentSize.Large) this.AttackDamage = 15;
            if (this.EquipmentSize == EquipmentSize.ExtraLarge) this.AttackDamage = 20;
        }

        public string GetInfo()
        {
            return $"Оружие Размер: {EquipmentSize}, стоимость: {Coast}, атака: +{AttackDamage}%";
        }
    }
}
