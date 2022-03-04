namespace SistemaCovid
{
    public class Preferencial
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
            Cabeca = Cabeca.Proximo;
        }
    }
}