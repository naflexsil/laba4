using System;
using System.Collections.Generic;
using System.IO;

namespace laba4 {
    internal static class Editing {
        public static void InitiateEdit(string UserPath, string NameFile)  {
            Console.Write(" ваши действия?\n\n1) изменить текст\n" +
                "2) запомнить состояние\n3) откатить изменения\n\nвведите номер желаемого действия - ");
            int YourChoise = 0; int Option = 3;
            while (YourChoise < 1 || YourChoise > Option) {
                if (int.TryParse(Convert.ToString(Console.ReadLine()), out YourChoise) == false) {
                    Console.WriteLine("неверно( попробуй еще раз!");
                }
            }

            FileStream file = new FileStream(UserPath, FileMode.OpenOrCreate);
            switch (YourChoise) {
                case 1:
                    FileReader(file, NameFile);
                    Console.Clear();
                    Console.WriteLine(" каким будет новое содержание файла? [ ~ для выхода ]: ");
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
                            Console.WriteLine($"{element} - неподходящее знач-е");
                            choise = Char.MinValue;
                        }
                    } while (choise != '~');
                    FileWriter(Input, UserPath, NameFile);
                    Console.Clear();
                    Console.WriteLine("изменения внесены!");
                    Console.ReadKey();
                    break;
                case 2:
                    FileReader(file, NameFile);
                    ct.SaveState(textFile);
                    break;
                case 3:
                    try {
                        file.Close();
                        RestoreData(UserPath, NameFile);
                    }
                    catch (KeyNotFoundException) {
                        Console.WriteLine("изменений не было!");
                        Console.ReadKey();
                    }
                    break;
            }
            file.Close();
        }
        static TextClass textFile = new TextClass();
        static Caretaker ct = new Caretaker();
        private static void FileReader(FileStream file, string NameFile) {
            string outString = "";
            var reader = new StreamReader(file);

            while (!reader.EndOfStream) {
                outString += reader.ReadLine();
            }
            try {
                textFile.Content.Add(NameFile, outString);
                textFile.NameFile.Add(NameFile);
            }
            catch (Exception) {
                textFile.Content[NameFile] = outString;
            }
            reader.Close();
        }

        private static void FileWriter(string input, string UserPath, string NameFile) {
            using (StreamWriter writer = new StreamWriter(UserPath, true)) {
                writer.Write(input);
            }
        }
        private static void RestoreData(string UserPath, string NameFile) {
            ct.RestoreState(textFile);
            using (StreamWriter writer = new StreamWriter(UserPath, false)) {
                writer.Write(textFile.Content[NameFile]);
            }
        }
    }
}