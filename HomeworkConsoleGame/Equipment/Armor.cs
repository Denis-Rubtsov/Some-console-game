using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    internal class Armor : IEquippable
    {
        private readonly EquipmentSize _equipmentSize;
        int Protection;
        public int Parameter => Protection;

        public int Coast { get; private set; }
        public EquipmentType EquipmentType { get; private init; }

        public EquipmentSize Size => _equipmentSize;

        public Armor(EquipmentType equipmentType, EquipmentSize equipmentSize)
        {
            EquipmentType = equipmentType;
            _equipmentSize = equipmentSize;
            SetCoast();
            SetProtection();
        }

        private void SetCoast()
        {
            Coast = _equipmentSize switch
            {
                EquipmentSize.Small => 100,
                EquipmentSize.Medium => 250,
                EquipmentSize.Large => 400,
                EquipmentSize.ExtraLarge => 550,
                _ => Coast
            };
        }

        private void SetProtection()
        {
            Protection = _equipmentSize switch
            {
                EquipmentSize.Small => 4,
                EquipmentSize.Medium => 8,
                EquipmentSize.Large => 12,
                EquipmentSize.ExtraLarge => 24,
                _ => Protection
            };
        }

        public string GetInfo()
        {
            return $"Тип: {EquipmentType}, размер: {_equipmentSize}, стоимость: {Coast}, защита: {Protection}%";
        }
    }
}
