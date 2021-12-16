using System;
using System.IO;


namespace _1consol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //1
                Console.WriteLine("\t Нажмите любую клавишу, чтобы перейти к шагу 1 ");
                Console.ReadKey();
                string rootPath = @"C:\temp";
                Console.Write("Введите название папки 1: ");
                string path1 = ($@"\{Console.ReadLine()}");
                Console.Write("Введите название папки 2: ");
                string path2 = ($@"\{Console.ReadLine()}");

                if (path1 == path2 || path1 == "\\" || path2 == "\\")
                {
                    throw new Exception();
                }
                Directory.CreateDirectory($@"{rootPath}{path1}");
                Directory.CreateDirectory($@"{rootPath}{path2}");

                Console.WriteLine("\t Нажмите любую клавишу, чтобы перейти к шагу 2 ");
                Console.ReadKey();
                //2
                File.WriteAllText($@"{rootPath}{path1}\t1.txt", "Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
                File.WriteAllText($@"{rootPath}{path1}\t2.txt", "Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");

                Console.WriteLine("\t Нажмите любую клавишу, чтобы перейти к шагу 3 и 4 ");
                Console.ReadKey();
                //3 и 4
                string[] file1 = File.ReadAllLines($@"{rootPath}{path1}\t1.txt");
                string[] file2 = File.ReadAllLines($@"{rootPath}{path1}\t2.txt");
                Console.WriteLine($"\n\tТекст первого файла:");
                for (int i = 0; i < file1.Length; i++)
                {
                    File.WriteAllText($@"{rootPath}{path2}\t3.txt", file1[i]);
                    Console.WriteLine($"\t\t {file1[i]}");
                }

                Console.WriteLine($"\n\tТекст второго файла: ");
                for (int i = 0; i < file2.Length; i++)
                {
                    File.AppendAllText($@"{rootPath}{path2}\t3.txt", $"\n{file2[i]}");
                    Console.WriteLine($"\t\t {file2[i]}");
                }

                string[] file3 = File.ReadAllLines($@"{rootPath}{path2}\t3.txt");
                Console.WriteLine($"\n\tТекст третьего файла:");
                for (int i = 0; i < file3.Length; i++)
                {
                    Console.WriteLine($"\t\t {file3[i]}");
                }

                Console.WriteLine("\t Нажмите любую клавишу, чтобы перейти к шагу 5 ");
                Console.ReadKey();

                //5
                Directory.Move($@"{rootPath}{path1}\t2.txt", $@"{rootPath}{path2}\t2.txt");

                Console.WriteLine("\t Нажмите любую клавишу, чтобы перейти к шагу 6 ");
                Console.ReadKey();
                //6
                File.Copy($@"{rootPath}{path1}\t1.txt", $@"{rootPath}{path2}\t1.txt");

                Console.WriteLine("\t Нажмите любую клавишу, чтобы перейти к шагу 7 ");
                Console.ReadKey();
                //7
                Directory.Move($@"{rootPath}{path2}", $@"{rootPath}\ALL");
                Directory.Delete($@"{rootPath}{path1}", true);


                Console.WriteLine("\t Нажмите любую клавишу, чтобы перейти к шагу 8 ");
                Console.ReadKey();
                //8
                DirectoryInfo dinf = new DirectoryInfo("c:\\temp\\ALL");
                string[] FileAllDirectory = Directory.GetFiles($@"{rootPath}\ALL");
                foreach (string filename in FileAllDirectory)
                {
                    Console.WriteLine(filename);
                }

                //clear
                Console.WriteLine("\t Нажмите любую клавишу, чтобы удалить последнюю папку ALL");
                Console.ReadKey();
                Directory.Delete($@"{rootPath}\ALL", true);
            }
            catch (Exception)
            {
                Console.WriteLine($"\n\n\t**** Ошибка: вы ввели одинаковое название двум папкам или оставили поле(-я) пустыми ****\n\n");
            }
        }
    }
}
