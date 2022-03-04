namespace SistemaCovid
{
    public class NaoPreferencial
    {
        public Pessoa Cabeca { get; set; }
        public Pessoa Cauda { get; set; }

        public void Inserir(Pessoa pessoa)
        {
            if (Cauda == null)
            {
                Cabeca = Cauda = pessoa;
                return;
            }

            Cauda.Proximo = pessoa;
            Cauda = pessoa;
        }

        public void Remover()
        {
            Cabeca = Cabeca.Proximo;
        }
    }
}