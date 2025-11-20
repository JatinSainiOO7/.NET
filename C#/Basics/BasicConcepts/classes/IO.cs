using System;
using System.IO;

namespace BasicConceptsClasses
{
    // Simple IO utility class for reading and writing text files
    public static class IO {

        public static void Run()
        {
            string path = @"C:\Users\jatin\Desktop\.NET\C#\Basics\BasicConcepts\classes\ClassData";
            Directory.CreateDirectory(path);
            //Directory.CreateDirectory(path);
            string fileName = "data.txt";
            string fileName2 = "data2.txt";
            string filePath = Path.Combine(path, fileName);

            File.WriteAllText(filePath, "file_01");
            File.AppendAllText(filePath, "\nfile_02");
            File.AppendAllText(filePath, "\nfile_03");
            File.AppendAllText(filePath, "\nfile_06060");
            File.AppendAllText(filePath, "\nfile_06060");


            string filePath2 = Path.Combine(path, fileName2);
            File.WriteAllText(filePath2, "file_01");
            File.AppendAllText(filePath2, "\nfile_02");
            File.AppendAllText(filePath2, "\nfile_03");
            File.AppendAllText(filePath2, "\nfile_06060");
            File.AppendAllText(filePath2, "\nfile_06060");

            Console.ReadLine();
        }



        public static void Example()
        {
            // 1. Setup the path
            // We use CurrentDirectory so the file appears where the .exe is running
            string folderPath = @"C:\Users\jatin\Desktop\.NET\C#\Basics\BasicConcepts\classes\ClassData";
            string filePath = Path.Combine(folderPath, "todo_list.txt");

            Console.WriteLine($"Working with file at: {filePath}\n");

            // 2. Create Directory if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Created directory 'MyData'.");
            }

            // 3. Write to file using StreamWriter
            Console.WriteLine("Writing data...");
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("1. Learn C# Generics");
                sw.WriteLine("2. Learn File I/O");
                sw.WriteLine("3. Build a Portfolio");
                sw.WriteLine($"Last Updated: {DateTime.Now}");
            }

            // 4. Read from file using StreamReader
            Console.WriteLine("\nReading data back from file:");
            Console.WriteLine("----------------------------");

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    int counter = 1;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"Line {counter}: {line}");
                        counter++;
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found!");
            }

            Console.WriteLine("\nPress any key to exit...");
        }

    }
}