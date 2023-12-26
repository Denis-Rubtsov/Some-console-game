using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    internal class Armor : IEquippable
    {
        Type _type;
        Size _size;
        public int coast;
        int Protection;
        public int Parameter { get { return this.Protection; } }
        public int Coast
        {
            get
            {
                return this.coast;
            }
        }
        public Type Type
        { get { return this._type; } }

        public Armor(Type type, Size size)
        {
            _type = type;
            _size = size;
            SetCoast();
            SetProtection();
        }

        void SetCoast()
        {
                if (this._size == Size.Small) this.coast = 100;
                else if (this._size == Size.Medium) this.coast = 250;
                else if (this._size == Size.Large) this.coast = 400;
                else if (this._size == Size.ExtraLarge) this.coast = 550;
        }

        void SetProtection()
        {
            if (this._size == Size.Small) this.Protection = 4;
            else if (this._size == Size.Medium) this.Protection = 8;
            else if (this._size == Size.Large) this.Protection = 12;
            else if (this._size == Size.ExtraLarge) this.Protection = 24;
        }

        public string GetInfo()
        {
            return $"Тип: {_type}, размер: {_size}, стоимость: {coast}, защита: {Protection}%";
        }
    }
}
