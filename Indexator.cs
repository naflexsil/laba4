using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace laba4 {
    // И Н Д Е К С А Т О Р 
    internal static class Indexator {
        public static void PerformIndexation(string Path) {
            List<string> extensions = new List<string>();
            Console.WriteLine("\n\t-----------------------------------------------\n \t|  какое расширение у файлов для индексации?  |" +
                "\n\t-----------------------------------------------\n \t\t\t[ $ - СТОП ] ");
            while (!extensions.Contains("$")) {
                extensions.Add(Console.ReadLine());
            }
            extensions.Remove("$");
            Console.Write("\n\t-----------------------------------------------\n \t|\t  как будет называться файл?\t      | " +
                "\n\t-----------------------------------------------\n");
            string loggingFileName = Path + @"\" + Console.ReadLine();
            FileStream indexatedFile = new FileStream(loggingFileName, FileMode.OpenOrCreate);
            using (StreamWriter writer = new StreamWriter(indexatedFile))
                foreach (string currentExtension in extensions) {
                    var extensionFiles = Directory. EnumerateFiles(Path, "*)" + currentExtension,
                        SearchOption.AllDirectories);
                    writer.WriteLine(currentExtension + " файл:");
                    foreach (string currentFile in extensionFiles){
                        string fileName = currentFile.Substring(Path.Length);
                        writer.WriteLine(fileName);
                    }
                }
            indexatedFile.Close();
        }
    }


    // П О И С К   Ф А Й Л О В
    internal class Search {
        public static void KeywordsFilesSearcher(string Path, string Keywords) {
            List<string> ReadyList = new List<string>();
            try {
                var txtFiles = Directory.EnumerateFiles(Path, "*.txt", SearchOption.AllDirectories);
                foreach (string currentFile in txtFiles) {
                    string fileName = currentFile.Substring(Path.Length);
                    if (File.ReadLines(Path + fileName).Any(line => line.Contains(Keywords)) || fileName.Contains(Keywords)) {
                        ReadyList.Add(fileName);
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            if (ReadyList.Count != 0) {
                for (int ElementIndex = 0; ElementIndex < ReadyList.Count; ++ElementIndex) {
                    Console.Write($"{ElementIndex + 1}. {ReadyList[ElementIndex]}\n");
                }
            }
            else{
                Console.WriteLine(" подходящих файлов нет о_о");
            }
        }
    }


    // Р А Б О Т А   О Р И Г И Н А Т О Р А (создает объект хранителя для сохранения своего состояния)
    public interface IOriginator {
            object GetMemento();
            void SetMemento(object memento);
        }
}