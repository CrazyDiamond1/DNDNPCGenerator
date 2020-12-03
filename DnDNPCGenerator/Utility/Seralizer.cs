using DnDNPCGenerator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml;

namespace DnDNPCGenerator.Utility
{
    public static class Seralizer
    {
        static string FileName { get; set; }
        static string FilePath { get; set; }

        public static void SerializeCharacters(List<Character> characters)
        {
            FileName = "/Characters.json";
            FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DNDNPCGenerator";
            JsonSerializer serializer = new JsonSerializer();

            if (!Directory.Exists(FilePath))
            {
                DirectoryInfo di = Directory.CreateDirectory(FilePath);
            }

            using (StreamWriter sw = new StreamWriter(FilePath + FileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, characters);
            }
        }

        public static List<Character> DeserializeCharacters()
        {
            FileName = "/Characters.json";
            FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DNDNPCGenerator";

            if (!Directory.Exists(FilePath))
            {
                DirectoryInfo di = Directory.CreateDirectory(FilePath);
            }
            if (File.Exists(FilePath+FileName))
            {
                string jsonString = File.ReadAllText(FilePath+FileName);
                List<Character> characters = JsonConvert.DeserializeObject<List<Character>>(jsonString);
                return characters;
            }
            else
            {
                return new List<Character>();
            }
        }
    }
}
