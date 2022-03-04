using System;
using System.Collections.Generic;
using System.IO;

namespace SistemaCovid
{
    public class Arquivo
    {
        public Arquivo(string caminho)
        {
            Caminho = caminho;
        }
        public string Caminho { get; set; }

        public void Salvar(Pessoa pessoa)
        {
            string sintomas = LerSintomas(pessoa.Registro.Triagem.Sintomas);

            string linha = $"{pessoa.Registro.Cpf};{pessoa.Registro.Nome};{pessoa.Registro.DataNascimento:d};{pessoa.Registro.Status};{pessoa.Registro.Triagem.Prioridade};{sintomas}";

            StreamWriter sw = File.AppendText(Caminho);
            sw.WriteLine(linha);
            sw.Close();
        }
        public void AdicionarCabecalho()
        {
            string linha = "CPF;Nome;Data de Nascimento;Status;Prioridade;Sintomas";

            StreamWriter sw = File.AppendText(Caminho);
            sw.WriteLine(linha);
            sw.Close();
        }
        public void BuscarPaciente(string cpf)
        {
            bool achou = false;
            string[] linhas = File.ReadAllLines(Caminho);
            if (linhas.Length > 1)
            {
                for (int i = 1; i < linhas.Length; i++)
                {
                    string linha = linhas[i];
                    string[] informacoesPaciente = linha.Split(';');
                    if (informacoesPaciente[0] == cpf)
                    {
                        achou = true;
                        Console.WriteLine($"Nome: {informacoesPaciente[1]}\nData de Nascimento: {informacoesPaciente[2]}\nStatus: {informacoesPaciente[3]}");
                    }
                }
            }
            if (!achou)
            {
                Console.WriteLine("\nPaciente não encontrado nos nossos registros.\n");
            }
        }

        private string LerSintomas(List<Sintoma> sintomas)
        {
            string textoDeSintomas = "";
            for (int i = 0; i < sintomas.Count; i++)
            {
                textoDeSintomas += $" {sintomas[i]}";
            }

            return textoDeSintomas;
        }
    }
}