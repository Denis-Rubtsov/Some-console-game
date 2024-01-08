using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    internal class Weapon : IEquippable
    {
        private EquipmentType _equipmentType = EquipmentType.Weapon;
        private EquipmentSize _equipmentSize;
        int AttackDamage;
        public int Parameter { get { return AttackDamage; } }
        public int Coast { get; private set; }
        public EquipmentType EquipmentType {get {return _equipmentType;}}

        public EquipmentSize Size => _equipmentSize;

        public Weapon(EquipmentSize equipmentSize)
        {
            _equipmentSize = equipmentSize;
            SetCoast();
            SetAttackDamage();
        }

        void SetCoast()
        {
            Coast = _equipmentSize switch
            {
                EquipmentSize.Small => 50,
                EquipmentSize.Medium => 150,
                EquipmentSize.Large => 250,
                EquipmentSize.ExtraLarge => 350,
                _ => Coast
            };
        }

        void SetAttackDamage()
        {
            AttackDamage = _equipmentSize switch
            {
                EquipmentSize.Small => 5,
                EquipmentSize.Medium => 10,
                EquipmentSize.Large => 15,
                EquipmentSize.ExtraLarge => 20,
                _ => Coast
            };
        }

        public string GetInfo()
        {
            return $"Оружие размер: {_equipmentSize}, стоимость: {Coast}, атака: +{AttackDamage}%";
        }
    }
}
