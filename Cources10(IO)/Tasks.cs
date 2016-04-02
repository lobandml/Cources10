using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Cources10_IO_
{
    class Tasks
    {
        private static int IntParseInput(string message)
        {
            int result;
            do
            {
                Console.WriteLine(message);
            }
            while (!Int32.TryParse(Console.ReadLine(), out result));
            return result;
        }

        public static void Task1(int countOfFolders)
        {
            string prefix = "Folder_";

            for (int i = 0; i < countOfFolders; i++)
            {
                Directory.CreateDirectory(prefix + i.ToString());
            }
            for (int i = 0; i < countOfFolders; i++)
            {
                Directory.Delete(prefix + i.ToString());
            }
        }
        public static void Task2()
        {
            string path = "TestFile.txt";
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine("Съешь ещё этих мягких французских булок,");
                    writer.WriteLine("да выпей же чаю.");
                }
            }

            using (StreamReader sr = new StreamReader(path))
            {
                string str;
                while (!sr.EndOfStream)
                {
                    //str = sr.ReadLine();
                   str= sr.ReadToEnd();
                   Console.WriteLine(str);
                    //Console.WriteLine(str);
                }
            }

            
        }
        public static void Task3()
        {
            bool correctdirectory=false;;
            bool correctfile=false;
            string directory=string.Empty;
            string file=string.Empty;
            while (!correctdirectory)
            {
                Console.WriteLine("Введите директорию");
                directory = Console.ReadLine();
                correctdirectory = System.IO.Directory.Exists(directory);
            }
                Console.WriteLine("Введите название файла");
                file = Console.ReadLine();
                correctfile = System.IO.File.Exists(directory+"\\"  +file);

                if (correctfile)
                {
                    Compress(directory + "\\" + file);
                    ToNotepad(directory + "\\" + file);
                }
                else
                {
                    Console.WriteLine("Ничего не найдено");
                }
            
        }
        static void Compress(string path)
        {
            using (FileStream fsOpen = new FileStream(path, FileMode.Open))
            {
                using (FileStream compressedFileStream = File.Create(path + ".zip"))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                       CompressionMode.Compress))
                    {
                        fsOpen.CopyTo(compressionStream);
                    }
                }
            }
            Console.WriteLine("Получен файл {0}.zip",path);
        }
        static void ToNotepad(string path)
        {

            Process.Start("notepad.exe", path);
            Console.WriteLine("Файл открыт в блокноте");
            
        }
        
    }
}
