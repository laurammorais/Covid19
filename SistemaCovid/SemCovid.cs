using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCovid
{
    internal class SemCovid
    {
        public DateTime DataAtual { get; set; }

        public SemCovid()
        {
            DataAtual = DateTime.Now;
        }
    }
}
