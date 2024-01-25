using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    public class BattleException : Exception
    {
        public BattleException(string message): base(message) { }
    }
}
