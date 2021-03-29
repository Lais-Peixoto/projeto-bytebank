using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    // Usando abstração para criar uma classe base para outras que herdarão suas características
    // Ou seja, herdarão os campos e implementarão os métodos
    public abstract class Funcionario
    {
        public static int TotalDeFuncionarios { get; private set; }
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }
        public Funcionario(double salario, string cpf)
        {
            Console.WriteLine("Criando FUNCIONARIO");

            CPF = cpf;
            Salario = salario;

            TotalDeFuncionarios++;
        }

        // O modificador 'abstract' garante que os metodos herdados
        // terão comportamentos distintos de acordo com a classe
        public abstract void AumentarSalario();
        protected internal abstract double GetBonificacao();
    }
}
