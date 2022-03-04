namespace SistemaCovid
{
    public class FilaDeChegada
    {
        public Pessoa Cabeca { get; set; }
        public Pessoa Cauda { get; set; }

        public void Inserir(Pessoa pessoa)
        {
            if (Cabeca == null)
            {
                Cabeca = Cauda = pessoa;
                return;
            }

            Cauda.Proximo = pessoa;
            Cauda = pessoa;
        }

        public void Remover()
        {
            var cabeca = Cabeca;
            Cabeca = cabeca.Proximo;
            cabeca.Proximo = null;
        }

    }
}
