using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace laba4 {
    class Memento {
        public Dictionary<string, string> Content { get; set; }
        public List<string> NameFile { get; set; }
    }


    public class Caretaker {  // ф-я хранения объекта Memento
        private object memento;
        public void SaveState(IOriginator originator) {
            originator.SetMemento(memento);
        }

        public void RestoreState(IOriginator originator) {
            memento = originator.GetMemento();
        }
    }


    [Serializable]
    class TextClass : IOriginator {
        public Dictionary<string, string> Content { get; set; }
        public List<string> NameFile { get; set; }
        public object FileName { get; internal set; }

        public TextClass() {
            Content = new Dictionary<string, string>();
            NameFile = new List<string>();
        }
        public TextClass(string Content, string NameFile) {
            this.Content.Add(NameFile, Content);
            this.NameFile.Add(NameFile);
        }

        public void BinarySerialization(FileStream fs) {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Flush();
            fs.Close();
        }

        public void BinaryDeserialization(FileStream fs) {
            BinaryFormatter bf = new BinaryFormatter();
            TextClass deserialized = (TextClass)bf.Deserialize(fs);
            Content = deserialized.Content;
            NameFile = deserialized.NameFile;
            fs.Close();
        }

        public void XmlSerialization(FileStream fs) {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(TextClass));
            xmlserializer.Serialize(fs, this);
            fs.Flush();
            fs.Close();
        }

        public void XmlDeserialization(FileStream fs) {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(TextClass));
            TextClass deserialized = (TextClass)xmlserializer.Deserialize(fs);
            Content = deserialized.Content;
            NameFile = deserialized.NameFile;
            fs.Close();
        }


        // Р А Б О Т А   О Р И Г И Н А Т О Р А
        object IOriginator.GetMemento() {
            return new Memento { Content = this.Content, NameFile = this.NameFile };
        }
        void IOriginator.SetMemento(object memento) {
            if (memento is Memento) {
                var memen = memento as Memento;
                Content = memen.Content;
                NameFile = memen.NameFile;
            }
        }
    }
 }