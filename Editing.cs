using System;
using System.Collections.Generic;
using System.IO;

namespace laba4 {
    internal static class Editing {
        public static void InitiateEdit(string FilePath, string FileName)  {
            Console.Write("\n ваши действия?\n\n  | 1) изменить текст\n" +
                "  | 2) запомнить состояние\n  | 3) откатить изменения\n\n ");
            int YourChoise = 0; int Option = 3;
            while (YourChoise < 1 || YourChoise > Option) {
                if (int.TryParse(Convert.ToString(Console.ReadLine()), out YourChoise) == false) {
                    Console.WriteLine(" неверно( попробуй еще раз!");
                }
            }

            FileStream file = new FileStream(FilePath, FileMode.OpenOrCreate);
            switch (YourChoise) {
                case 1:
                    FileReader(file, FileName);
                    Console.Clear();
                    Console.WriteLine("\n\t -------------------------------------------\n\t |\t  введите желаемый текст!\t   | \n " +
                        "\t -------------------------------------------\n\t");
                    char choise;
                    int element;
                    string Input = "";
                    do {
                        element = Console.Read();
                        try {
                            choise = Convert.ToChar(element);
                            Input += choise;
                        }
                        catch (OverflowException) {
                            Console.WriteLine($"{element} - значение неприкольное, мне не нравится");
                            choise = Char.MinValue;
                        }
                    } while (choise != '\n');
                    FileWriter(Input, FilePath, FileName);
                    Console.Clear();
                    Console.WriteLine(" \n\tизменения внесены!");
                    Console.ReadKey();
                    break;
                case 2:
                    FileReader(file, FileName);
                    ct.SaveState(textFile);
                    break;
                case 3:
                    try {
                        file.Close();
                        RestoreData(FilePath, FileName);
                    }
                    catch (KeyNotFoundException) {
                        Console.WriteLine(" \n\tизменения не внесены!");
                        Console.ReadKey();
                    }
                    break;
            }
            file.Close();
        }

        static TextClass textFile = new TextClass();
        static Caretaker ct = new Caretaker();

        private static void FileReader(FileStream file, string FileName) {
            string outString = "";
            var reader = new StreamReader(file);

            while (!reader.EndOfStream) {
                outString += reader.ReadLine();
            }
            try {
                textFile.Content.Add(FileName, outString);
                textFile.FileName = FileName;
            }
            catch (Exception) {
                textFile.Content[FileName] = outString;
            }
            reader.Close();
        }

        private static void FileWriter(string input, string FilePath, string FileName) {
            using (StreamWriter writer = new StreamWriter(FilePath, true)) {
                writer.Write(input);
            }
        }

        private static void RestoreData(string FilePath, string FileName) {
            ct.RestoreState(textFile);
            using (StreamWriter writer = new StreamWriter(FilePath, false)) {
                writer.Write(textFile.Content[FileName]);
            }
        }
    }
}