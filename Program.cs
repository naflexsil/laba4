 
/************************************
 *                                  *
 *     работа Стариковой Алины      *  
 *    "Стандартный ввод/вывод"      *
 *            4 лаба                *      
 *                                  *
 ***********************************/

using System;
using System.IO;

namespace laba4 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("введите полный путь к рабочей папке: ");
            string UserPath = @"C:\";
            bool Success = false;
            while (Success == false) {
                UserPath = Console.ReadLine();
                if (Directory.Exists(UserPath) && UserPath != string.Empty) {
                    Success = true;
                }
                else {
                    Console.WriteLine("неверный формат пути о_о. попробуй еще раз!");
                }
            }
            int YourChoise = 0; int Option = 4;
            while (YourChoise != Option) {
                Console.Clear();
                Console.WriteLine($"файловый менеджер к вашим услугам\n{UserPath}");
                Console.WriteLine("1) отредактировать файл\n2) найти файлы по ключевым словам\n" +
                    "3) проиндексировать все файлы в рабочей папке в отдельный файл\n4) хочу выйти");
                while (YourChoise < 1 || YourChoise > Option) {
                    if (int.TryParse(Convert.ToString(Console.ReadLine()), out YourChoise) == false) {
                        Console.WriteLine("неверные данные о_о.  попробуй ещё раз!");
                    }
                }
                Console.Clear();
                string NameFile;
                switch (YourChoise) {
                    case 1:
                        Console.Clear();
                        Console.Write("введите имя .txt файла, который хочется отредактировать: ");
                        NameFile = Console.ReadLine();
                        Editing.InitiateEdit(UserPath + @"\" + NameFile + ".txt", NameFile);
                        YourChoise = 0;
                        break;
                    case 2:
                        Console.Write("введите ключевые слова для поиска: ");
                        string UserKeywords = Console.ReadLine();
                        Console.Clear();
                        Searcher.KeywordsFilesSearcher(UserPath, UserKeywords);
                        Console.ReadKey();
                        YourChoise = 0;
                        break;
                    case 3:
                        Indexator.PerformIndexation(UserPath);
                        YourChoise = 0;
                        break;
                }
            }
        }
    }
}