using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Nick
{
    internal class Konto : Kunder
    {
        public List<string> KontoNr { get; set; } = new List<string>();
        public int KontoValuta { get; set; }
    }
}
