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
        Type Type { get; }
        int Parameter { get; }
        string GetInfo();
    }
}
