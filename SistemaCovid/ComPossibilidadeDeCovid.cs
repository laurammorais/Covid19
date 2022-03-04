using System;

namespace SistemaCovid
{
    public class ComPossibilidadeDeCovid
    {
        public ComPossibilidadeDeCovid(bool alta)
        {
            DataAtual = DateTime.Now;
            Alta = alta;
        }

        public DateTime DataAtual { get; set; }
        public bool Alta { get; set; }
    }
}