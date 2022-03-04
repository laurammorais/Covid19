namespace SistemaCovid
{
    public class Pessoa
    {
        public Pessoa(int senha)
        {
            Senha = senha;
        }

        public int Senha { get; set; }
        public Pessoa Proximo { get; set; }
        public Registro Registro { get; set; }
    }

}
