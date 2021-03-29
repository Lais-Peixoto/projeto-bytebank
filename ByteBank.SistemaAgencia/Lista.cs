using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class Lista<T>
    {
        private T[] _itens;
        private int _proximaPosicao;
        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        // Construtor da classe Lista
        public Lista(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }

        // Criação de indexador
        private T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }
        public T this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }
        public void Adicionar(T item)
        {
            // "Eu tenho espaço para adicionar +1 conta?"
            VerificarCapacidade(_proximaPosicao + 1);

            // Adicionar item no final do array de contas _itens
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }
        public void AdicionarVarios(params T[] itens)
        {
            foreach (T item in itens)
            {
                Adicionar(item);
            }
        }

        public void Remover(T item)
        {
            int indice = -1;

            // Encontrar o índice do elemento a ser removido em nosso array interno
            for (int i = 0; i < _proximaPosicao; i++)
            {
                T itemAtual = _itens[i];

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
            for (int i = indice; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            // Decrementar a próxima posição livre e atribuir nulo neste item
            _proximaPosicao--;
            //_itens[_proximaPosicao] = null;

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
            T[] novoArray = new T[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
            }

            // Substituindo o array antigo pelo de capacidade aumentada
            _itens = novoArray;
        }
    }
}
