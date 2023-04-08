using System;
using System.IO;
using System.Threading.Tasks;

namespace FileReadingExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] fileNames = { "AI1.txt", "AI2.txt", "AI3.txt" };

            foreach (var fileName in fileNames)
            {
                await Task.Run(() => ReadFile(fileName));
            }

            Console.WriteLine("File reading completed.");
        }

        static void ReadFile(string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
            {
                int N = 0;
                if (int.TryParse(streamReader.ReadLine(), out N))
                {
                    Console.WriteLine($"File: {fileName}, N: {N}");
                    for (int i = 0; i < N; i++)
                    {
                        if (int.TryParse(streamReader.ReadLine(), out int number))
                        {
                            Console.WriteLine($"File: {fileName}, Number: {number}");
                        }
                    }
                }
            }
        }
    }
}
