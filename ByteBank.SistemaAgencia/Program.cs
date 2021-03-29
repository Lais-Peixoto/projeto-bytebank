using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tipo genérico de classes:");

            Lista<int> idades = new Lista<int>();

            idades.AdicionarVarios(63, 15, 21, 50);
            idades.Remover(15);

            Console.WriteLine($"Idade: {idades[0]}");

            Lista<string> cursos = new Lista<string>();
            cursos.AdicionarVarios("C# Parte 1", "C# Parte 2", "C# Parte 3");

            Console.WriteLine($"Curso: {cursos[0]}");

            Lista<ContaCorrente> contas = new Lista<ContaCorrente>();
            contas.AdicionarVarios(new ContaCorrente(124, 54354), new ContaCorrente(201, 44354));

            Console.WriteLine($"Conta: {contas[1]}");

            Console.ReadLine();
        }

        static void ListaTipoEspecifico()
        {
            //ListaDeContaCorrente lista = new ListaDeContaCorrente();

            //lista.AdicionarVarios(
            //    new ContaCorrente(100, 40010),
            //    new ContaCorrente(101, 40011),
            //    new ContaCorrente(102, 40012),
            //    new ContaCorrente(103, 40013)
            //);

            //for (int i = 0; i < lista.Tamanho; i++)
            //{
            //    ContaCorrente conta = lista[i];
            //}

            //Console.WriteLine("Testando pegar elemento fora do tamanho do array.");
            //try
            //{
            //    ContaCorrente elementoFora = lista[4];
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.WriteLine("Testando remoção de elemento não presente no array.");
            //try
            //{
            //    lista.Remover(new ContaCorrente(111, 11111));
            //}
            //catch (IndexOutOfRangeException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
        static void StringRegex()
        {
            string urlParametros = "http://bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL(urlParametros);

            Console.WriteLine(extrator.URL);

            string valor = extrator.GetValor("moedaOrigem");
            Console.WriteLine("Valor de moedaOrigem: " + valor);

            string valorD = extrator.GetValor("moedaDestino");
            Console.WriteLine("Valor de moedaDestino: " + valorD);

            Console.WriteLine(extrator.GetValor("VALOR"));

            Console.ReadLine();
        }
        static void DatasNuGet()
        {
            ContaCorrente minhaConta = new ContaCorrente(123, 1234567);
            minhaConta.Titular = new Cliente();
            minhaConta.Titular.Nome = "Lais";
            Console.WriteLine("Olá, " + minhaConta.Titular.Nome);
            Console.WriteLine("Número da agência: " + minhaConta.Agencia);
            Console.WriteLine("Número da conta: " + minhaConta.Numero);
            Console.WriteLine("Seu saldo é: " + minhaConta.Saldo);

            minhaConta.Depositar(200);
            Console.WriteLine("Seu novo saldo é de: " + minhaConta.Saldo);

            // Dia 17 de Agosto de 2018
            DateTime dataFimPagamento = new DateTime(2018, 8, 17);
            // Data corrente no momento de execução do código ou DateTime.Today para criar sem horário
            DateTime dataCorrente = DateTime.Now;
            TimeSpan diferenca = dataFimPagamento - dataCorrente;

            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(mensagem);
        }
    }
}
