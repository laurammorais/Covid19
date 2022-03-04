using System;
using System.Collections.Generic;

namespace SistemaCovid
{
    public class Registro
    {
        public Registro(string nome, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            CalcularIdade();
        }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public Triagem Triagem { get; set; }
        public string Status { get; set; }

        private void CalcularIdade()
        {
            Idade = (DateTime.Now - DataNascimento).Days / 365;
        }

        public void DefinirTriagem()
        {
            List<Sintoma> sintoma = new List<Sintoma>();
            int opcaoSintoma = 1;
            bool comSintomas = false;
            int comorbidade = 0;
            int dias = 0;
            string prioridade = null;

            while (opcaoSintoma != 0 && opcaoSintoma != 6 && opcaoSintoma != 5)
            {
                Console.WriteLine("\nEscolha um sintoma do paciente: \n1-Febre\n2-Perda do paladar\n3-Perda do olfato\n4-Dor de cabeça\n5-Outros\n6-Sem Sintomas\n0-Sair");
                Console.Write("Sintoma: ");
                opcaoSintoma = int.Parse(Console.ReadLine());

                if (opcaoSintoma > 6 || opcaoSintoma < 0)
                {
                    Console.WriteLine("Opção Inválida, digite uma opção disponível");
                }
                else if (opcaoSintoma != 0 && opcaoSintoma != 6)
                {
                    sintoma.Add((Sintoma)opcaoSintoma);
                    if (opcaoSintoma != 5)
                    {
                        comSintomas = true;
                    }
                }
            }

            if (comSintomas)
            {
                while (dias != 1 && dias != 2)
                {
                    Console.WriteLine("\nQuantidade de dias com sintoma: \n1-Até 3 dias\n2-Mais de 3 dias");
                    Console.Write("Escolha a opção 1 ou 2: ");
                    dias = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (dias == 1)
                    {
                        Console.WriteLine("Paciente sem suspeita de covid");
                    }
                    else if (dias == 2)
                    {
                        Console.WriteLine("Paciente com suspeita de covid");
                    }
                    else
                    {
                        Console.WriteLine("ERRO! Informe uma opção válida");
                    }
                }
                if (dias == 2)
                {
                    Console.Write("Número de comorbidades do paciente: ");
                    comorbidade = int.Parse(Console.ReadLine());

                    if (comorbidade < 0)
                    {
                        Console.WriteLine("Número de comorbidade inexistente");
                    }
                    else if (comorbidade == 0)
                    {
                        Console.WriteLine("Paciente com nível prioritário verde");
                        prioridade = "Verde";
                    }
                    else if (comorbidade <= 2)
                    {
                        Console.WriteLine("Paciente com nível prioritário amarelo");
                        prioridade = "Amarelo";
                    }
                    else if (comorbidade >= 3)
                    {
                        Console.WriteLine("Paciente com nível prioritário vermelho");
                        prioridade = "Vermelho";
                    }
                    Console.WriteLine();
                }
            }
            bool chanceDeCovid = ChanceDeCovid(dias, comSintomas);
            string tempoDeSintoma = ReceberDias(dias);
            string emergencia = "";
            bool necessitaDeEmergencia = false;

            if (!chanceDeCovid)
            {
                Console.WriteLine("\nPaciente recebeu alta!");
                Status = "Alta";
            }

            while (chanceDeCovid && emergencia != "S" && emergencia != "N")
            {
                Console.Write("\nPaciente necessita de emergência?[S/N]:");
                emergencia = Console.ReadLine().ToUpper();

                if (emergencia == "S")
                {
                    necessitaDeEmergencia = true;
                    Status = "Quarentena";
                    Console.WriteLine("\nPaciente será encaminhado para o leito.");
                }
                else if (emergencia == "N")
                {
                    Status = "Quarentena";
                    Console.WriteLine("\nPaciente ficará de quarentena!");
                }
                else
                {
                    Console.WriteLine("Digite apenas [S] ou [N]");
                }
            }
            Triagem = new Triagem(sintoma, necessitaDeEmergencia, chanceDeCovid, tempoDeSintoma, comorbidade, prioridade);
        }

        public bool ChanceDeCovid(int dias, bool comSintomas)
        {
            if (dias == 2 && comSintomas)
            {
                return true;
            }
            return false;
        }

        public string ReceberDias(int dias)
        {
            if (dias == 1)
            {
                return "Até 3 dias";
            }

            return "Mais de 3 dias";
        }
    }
}
