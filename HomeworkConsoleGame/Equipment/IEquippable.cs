using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    internal interface IEquippable
    {
        int Coast {  get; }
        EquipmentType EquipmentType { get; }
        int Parameter { get; }
        EquipmentSize Size { get; }
        string GetInfo();
    }
}
