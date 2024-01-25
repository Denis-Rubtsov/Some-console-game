using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    public class BossBattleException: Exception
    {
        public BossBattleException(string message): base(message) { }
    }
}
