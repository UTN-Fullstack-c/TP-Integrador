using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class IndiceInvalido : Exception
    {
        public IndiceInvalido(string msg) : base(msg) { }
    }
}
