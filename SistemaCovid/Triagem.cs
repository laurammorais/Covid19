using System.Collections.Generic;

namespace SistemaCovid
{
    public class Triagem
    {
        public Triagem(List<Sintoma> sintomas, bool emergencia, bool chanceDeCovid, string tempoDeSintoma, int comorbidades, string prioridade)
        {
            Sintomas = sintomas;
            Emergencia = emergencia;
            ChanceDeCovid = chanceDeCovid;
            TempoDeSintoma = tempoDeSintoma;
            Comorbidades = comorbidades;
            Prioridade = prioridade;
        }

        public List<Sintoma> Sintomas { get; set; }
        public bool Emergencia { get; set; }
        public bool ChanceDeCovid { get; set; }
        public string TempoDeSintoma { get; set; }
        public int Comorbidades { get; set; }
        public string Prioridade { get; set; }
    }
}
