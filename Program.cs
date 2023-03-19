 
/************************************
 *                                  *
 *     работа Стариковой Алины      *  
 *    "Стандартный ввод/вывод"      *
 *             4 лаба               *      
 *                                  *
 ***********************************/

using System;
using System.IO;

namespace laba4 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("\n\t -------------------------------------------\n" +
                          "\t |           полный путь к папке?          |\n" + "\t -------------------------------------------\n\n");
            string FilePath = @"C:\";
            bool Success = false;
            while (Success == false) {
                FilePath = Console.ReadLine();
                if (Directory.Exists(FilePath) && FilePath != string.Empty) {
                    Success = true;
                }
                else {
                    Console.WriteLine(" \n путь указан неверно о_о.  попробуй еще раз!");
                }
            }
            int YourChoise = 0; int Option = 4;
            while (YourChoise != Option) {
                Console.Clear();
                Console.WriteLine($"\n\t -------------------------------------------\n " +
                                   $"\t |\t         что желаем?               |\n\t -------------------------------------------\n\n{FilePath}");
                Console.WriteLine("\t\n -----------------------------\n | 1) отредактировать файл\n | 2) найти файлы по ключевым словам\n" +
                    " | 3) проиндексировать все файлы в рабочей папке в отдельный файл\n | 4) хочу выйти\n -------");
                while (YourChoise < 1 || YourChoise > Option) {
                    if (int.TryParse(Convert.ToString(Console.ReadLine()), out YourChoise) == false) {
                        Console.WriteLine(" неверные данные о_о.  попробуй ещё раз!");
                    }
                }
                Console.Clear();
                string NameFile;
                switch (YourChoise) {
                    case 1:
                        Console.Clear();
                        Console.Write(" \n\t ---------------------------------------------------------\n \t |     введите имя .txt файла для его редактирования:    |" +
                            " \n\t ---------------------------------------------------------\n ");
                        NameFile = Console.ReadLine();
                        Editing.InitiateEdit(FilePath + @"\" + NameFile + ".txt", NameFile);
                        YourChoise = 0;
                        break;
                    case 2:
                        Console.Write("\n\t -------------------------------------------\n \t |   введите ключевые слова для поиска:    |\n" +
                           "\t -------------------------------------------\n");
                        string UserKeywords = Console.ReadLine();
                        Console.Clear();
                        Search.KeywordsFilesSearcher(FilePath, UserKeywords);
                        Console.ReadKey();
                        YourChoise = 0;
                        break;
                    case 3:
                        Indexator.PerformIndexation(FilePath);
                        YourChoise = 0;
                        break;
                }
            }
        }
    }
}