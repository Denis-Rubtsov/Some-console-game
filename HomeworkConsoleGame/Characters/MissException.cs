using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame.Characters
{
    public class MissException : Exception
    {
        public MissException(string message) : base(message) { }
    }
}
