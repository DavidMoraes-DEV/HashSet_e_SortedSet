using System;
using System.Collections.Generic;

namespace HashSet_e_SortedSet
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            * HashSer<T> e SortedSet<T> 
            - Representa um conjunto de elementos (Similar ao da Álgebra)
                - Não admite repetições
                - Elementos não possuem posição
                - Acesso m inserção e remoção de elementos são rápidos
                - Oferece operações eficientes de conjunto> interseção, união, diferença.

            * DIFERENÇAS:
            
            - HashSet
                - Armazenamento em table hash(Código)
                - Extremamente rápido: inserção, remoção e busca O(1) (Execução de modo geral é em 1 passo
                - A ordem dos elementos não é garantida

            - SortedSet
                - Armazenamento em árvore
                - Rápido: Inserção, remoção e busca O(log(n)) (Execução logarítimica)
                - Os elementos são armazenados ordenadamente conforme implementação IComparer<T>

            * ALGUNS MÉTODOS IMPORTANTES:
            - Add - Adiciona um elemento
            - Clear - Limpa um conjunto
            - Contains - Verifica se um elemento esta contido em um conjunto
            - UnionWith(other) - operação união: adiciona no conjunto os elementos do outro conjunto, sem repetição
            - IntersectWith(other) - operaçao interseção: remove do conjunto os elementos não contidos em other
            - ExceptWith(other) - operação diferença: remove do conjunto os elementos contidos em other
            - Remove(T) - Remove um elementos do conjunto
            - RemoveWhere(predicate) - Remove todos os elementos que atendam uma determinada condição

            EXEMPLO BÁSICO:
             */

            HashSet<string> set = new HashSet<string>(); //Instanciando um conjunto de strings

            set.Add("TV"); //Adiciona um elemento ao conjunto
            set.Add("Notebook");
            set.Add("Tablet");

            Console.WriteLine("Elementos do conjunto:");
            foreach (string str in set)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("\nExiste o elemento (Notebook) no conjunto set: " + set.Contains("Notebook")); //Verifica se existe o elemento "Notebook" no conjunto "set" retornando true ou false

            SortedSet<int> sort1 = new SortedSet<int>() { 0, 2, 4, 5, 6, 8, 10 }; //Instanciando um conjunto do tipo SortedSet e já colocando alguns valores.
            SortedSet<int> sort2 = new SortedSet<int>() { 5, 6, 7, 8, 9, 10 };

            Console.Write("\nUtilizando agora o SortedSet:\nsort1: ");
            PrintCollection(sort1);
            Console.Write("\nsort2: ");
            PrintCollection(sort2);

            //União entre dois conjuntos:
            SortedSet<int> sort3 = new SortedSet<int>(sort1); //Criando um novo conjunto e já incluindo todos os elementos do sort1
            sort3.UnionWith(sort2); //Realiza a união dos elementos do conjunto sort2 com os elementos do conjunto sort3 (obs. se o mesmo elemento existir nos dois conjunto permanecera apenas um, ou seja não há repetições de elementos dentro de um conjunto)      

            Console.Write("\nUnião entre sort1 e sort2: ");
            PrintCollection(sort3);

            //Interseção entre dois conjuntos:
            SortedSet<int> sort4 = new SortedSet<int>(sort1);
            sort4.IntersectWith(sort2); //Realiza a Interseção entre dois conjuntos, ou seja, remove os elementos não contidos no conjunto sort2

            Console.Write("\ninterseção entre sort1 e sort2: ");
            PrintCollection(sort4);

            //Diferença entre dois conjuntos:
            SortedSet<int> sort5 = new SortedSet<int>(sort1);
            sort5.ExceptWith(sort2); //Realiza a diferença entre dois conjuntos, ou seja, remove os elementos contidos em sort2

            Console.Write("\nDiferença entre sort1 e sort2: ");
            PrintCollection(sort5);

        }

        //Função auxiliar para imprimir o conjunto
        static void PrintCollection<T>(IEnumerable<T> collection) //IEnumerable é uma interface implementada por todas as coleções básicas do pacote System.Collections e o IEnumerable possui uma função chamada GetEnumerator() que retorna um Enumerator para que posso percorrer uma coleção de uma forma padronizada.
        {
            foreach (T obj in collection)
            {
                Console.Write(obj + " ");
            }
            Console.WriteLine();
        }
    }
}
