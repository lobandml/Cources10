using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cources10_IO_
{
    class Tasks
    {
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

        }
    }
}
