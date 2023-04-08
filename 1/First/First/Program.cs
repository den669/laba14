using System;
using System.Threading;

namespace ThreadExample
{
    class Program
    {
        static int[] arr; 
        static int minValue; 
        static int maxValue; 

        static void Main(string[] args)
        {
            Console.WriteLine("Введіть розмір масиву:");
            int size = Convert.ToInt32(Console.ReadLine());

            arr = new int[size];

            Console.WriteLine("Введіть елементи масиву:");

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Елемент {i + 1}: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            
            Thread threadMax = new Thread(FindMax);
            
            Thread threadMin = new Thread(FindMin);

            
            threadMax.Start();
            threadMin.Start();

            
            threadMax.Join();
            threadMin.Join();

            
            Console.WriteLine($"Максимум: {maxValue}");
            Console.WriteLine($"Мінімум: {minValue}");
        }

        static void FindMax()
        {
            
            maxValue = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }
            }
        }

        static void FindMin()
        {
            
            minValue = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }
            }
        }
    }
}
