using System;
using System.Security.Cryptography.X509Certificates;

namespace BasicConceptsClasses
{
    // Simple IO utility class for reading and writing text files
    public static class IO
    {

        public static void Main(string[] args)
        {
            
            run();
            Console.ReadLine();
        }

        public static void run()
        {
            string path = @"C:\Users\jatin\Desktop\.NET\C#\Basics\BasicConcepts\classes\ClassData";
            Directory.CreateDirectory(path);

            string fileName = "data.txt";
            string filePath = Path.Combine(path, fileName);

            File.WriteAllText(filePath, "\nThis is a new line.");
            Console.ReadLine();
        }

    }
}