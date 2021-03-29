using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeContaCorrente
    {

        private ContaCorrente[] _itens;
        private int _proximaPosicao;
        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        // Construtor da classe ListaDeContaCorrente
        public ListaDeContaCorrente(int capacidadeInicial = 5)
        {
            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;
        }

        // Criação de indexador
        private ContaCorrente GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }
        public ContaCorrente this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }
        public void Adicionar(ContaCorrente item)
        {
            // "Eu tenho espaço para adicionar +1 conta?"
            VerificarCapacidade(_proximaPosicao + 1);

            // Adicionar item no final do array de contas _itens
            Console.WriteLine($"Adicionando no índice {_proximaPosicao} conta {item.Agencia}/{item.Numero}");
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }
        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            foreach (ContaCorrente conta in itens)
            {
                Adicionar(conta);
            }
        }

        public void Remover(ContaCorrente item)
        {
            int indice = -1;

            // Encontrar o índice do elemento a ser removido em nosso array interno
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indice = i;
                    break;
                }
            }

            if (indice == -1)
            {
                throw new IndexOutOfRangeException("Elemento não encontrado");
            }

            // Deslocar todos os itens à direita do item a ser removido uma posição para a esquerda
            for (int i = indice; i < _proximaPosicao-1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            // Decrementar a próxima posição livre e atribuir nulo neste item
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;

        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            // Verificando a capacidade mínima necessaria para o novo array
            Console.WriteLine("Aumentando capacidade da lista!"); 
            int novoTamanho = _itens.Length * 2;

            if (novoTamanho < tamanhoNecessario)
            {
                Console.WriteLine("O dobro da capacidade atual não foi suficiente para garantir o tamanho necessário.");
                novoTamanho = tamanhoNecessario;
            }

            // Criando novo array que comporta os elementos antigos + o último adicionado
            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
            }

            // Substituindo o array antigo pelo de capacidade aumentada
            _itens = novoArray;

        }

    }
}
