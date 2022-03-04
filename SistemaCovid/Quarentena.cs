using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCovid
{
    internal class Quarentena
    {
        public int Permanencia { get; set; }

        public Quarentena(int permanencia)
        {
            Permanencia = permanencia;
        }
    }
}
