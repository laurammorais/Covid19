using System;
using System.IO;

namespace SistemaCovid
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-= BEM VINDOS AO HOSPITAL DE CAMPANHA COVID 19 =-=-=-=-=-=-=-=-=-=-=");
            FilaDeChegada filaDeChegada = new FilaDeChegada();
            Preferencial preferencial = new Preferencial();
            NaoPreferencial naoPreferencial = new NaoPreferencial();
            Arquivo arquivo = new Arquivo(@"C:\temp\5by5-covid\Pacientes.csv");
            Leito leito = new Leito();
            bool acabou = false;
            int senha = 1;
            int contador = 0;

            ValidarArquivo(arquivo);

            while (!acabou)
            {
                Console.WriteLine("\n1 - Novo Paciente");
                Console.WriteLine("2 - Recepção");
                Console.WriteLine("3 - Atendimento");
                Console.WriteLine("4 - Buscar paciente");
                Console.WriteLine("5 - Finalizar");
                Console.Write("\nDigite a opção que deseja escolher: ");
                int opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcao)
                {
                    case 1:
                        {
                            Console.WriteLine($"Senha:{senha}");
                            Pessoa pessoa = new Pessoa(senha);
                            filaDeChegada.Inserir(pessoa);
                            senha++;
                            break;
                        }

                    case 2:
                        {
                            if (filaDeChegada.Cabeca != null)
                            {
                                Console.Write("Nome: ");
                                string nome = Console.ReadLine();
                                Console.Write("CPF: ");
                                string cpf = Console.ReadLine();
                                Console.Write("Data de Nascimento: ");
                                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
                                filaDeChegada.Cabeca.Registro = new Registro(nome, dataNascimento, cpf);

                                if (filaDeChegada.Cabeca.Registro.Idade < 60)
                                {
                                    naoPreferencial.Inserir(filaDeChegada.Cabeca);
                                    Console.WriteLine("Paciente Não Preferencial\n");
                                }
                                else
                                {
                                    preferencial.Inserir(filaDeChegada.Cabeca);
                                    Console.WriteLine("Paciente Preferencial\n");
                                }
                                filaDeChegada.Remover();
                            }
                            else
                            {
                                Console.WriteLine("Sem Pacientes na Fila de chegada\n");
                            }
                            break;
                        }
                    case 3:
                        {
                            if (preferencial.Cabeca != null && contador < 2)
                            {
                                Console.WriteLine("Atendendo Preferencial...");
                                Console.WriteLine($"Atendendo o paciente: {preferencial.Cabeca.Registro.Nome}\n");
                                Pessoa pessoa = preferencial.Cabeca;
                                preferencial.Remover();
                                pessoa.Registro.DefinirTriagem();
                                contador++;
                                EncaminharParaLeito(leito, pessoa);
                                arquivo.Salvar(pessoa);
                            }
                            else if (naoPreferencial.Cabeca != null)
                            {
                                Console.WriteLine("Atendendo Não Preferencial...");
                                Console.WriteLine($"Atendendo o paciente: {naoPreferencial.Cabeca.Registro.Nome}\n");
                                Pessoa pessoa = naoPreferencial.Cabeca;
                                naoPreferencial.Remover();
                                pessoa.Registro.DefinirTriagem();
                                contador = 0;
                                EncaminharParaLeito(leito, pessoa);
                                arquivo.Salvar(pessoa);
                            }
                            else
                            {
                                Console.WriteLine("Não há pacientes na fila de atendimento.");
                                contador = 0;
                            }
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Digite um paciente para a busca: ");
                            string cpf = Console.ReadLine();
                            arquivo.BuscarPaciente(cpf);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Finalizando...");
                            acabou = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Escolha uma opção válida!");
                            break;
                        }
                }
            }
        }

        public static void EncaminharParaLeito(Leito leito, Pessoa pessoa)
        {
            if (pessoa.Registro.Triagem.Emergencia)
            {
                pessoa.Registro.Status = "Leito";
                leito.Quantidade++;
            }
        }

        public static void ValidarArquivo(Arquivo arquivo)
        {
            if (!Directory.Exists(@"C:\temp\5by5-covid"))
            {
                Directory.CreateDirectory(@"C:\temp\5by5-covid");
            }
            if (!File.Exists(arquivo.Caminho))
            {
                FileStream file = File.Create(arquivo.Caminho);
                file.Close();
                arquivo.AdicionarCabecalho();
            }
        }
    }
}

