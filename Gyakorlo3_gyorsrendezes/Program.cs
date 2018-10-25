using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Gyakorlo3_gyorsrendezes
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            //after 9990 - stackoverflowexception
            int[] generatedNumbers = new int[30];

            for (int i = 0; i < generatedNumbers.Length; i++)
            {   
                generatedNumbers[i] = r.Next(1000);
                Console.Write(generatedNumbers[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            QuickSort(generatedNumbers, 0, generatedNumbers.Length-1);

            foreach (int i in generatedNumbers)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            Console.ReadKey();
        }

        //ctrl ck uk
        static void QuickSort(int[] array, int startIndex, int endIndex)
        {   
            //exit state
            if (startIndex >= endIndex)
            {
                return;
            }

            int pivot = array[startIndex];
            int indexOfFirstOpenedCard = startIndex+1;

            //partitioning
            for (int i = startIndex+1; i <= endIndex; i++)
            {
                if (array[i] < pivot)
                {
                    int temp = array[i];
                    array[i] = array[indexOfFirstOpenedCard];
                    array[indexOfFirstOpenedCard] = temp;
                    indexOfFirstOpenedCard++;
                }       
            }
            //swap last closed card with pivot
            array[startIndex] = array[indexOfFirstOpenedCard - 1];
            array[indexOfFirstOpenedCard - 1] = pivot;

            QuickSort(array, startIndex, indexOfFirstOpenedCard - 2);
            QuickSort(array, indexOfFirstOpenedCard, endIndex);
        }
    }
}
