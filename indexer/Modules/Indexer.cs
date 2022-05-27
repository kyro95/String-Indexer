using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Indexer
{
    public class Indexer
    {
        public static readonly string JSONPath = $@"{Directory.GetCurrentDirectory()}/Strings.json";
        
        public static void Import()
        {
            var result = File.ReadAllText(JSONPath);
            var data = JsonConvert.DeserializeObject<List<Storage>>(result, new JsonSerializerSettings
            {
                //NullValueHandling = NullValueHandling.TryParse<string>(result)
            });

            foreach (var str in data!.Where(str => str.NewStr is {Length: >= 1}))
            {
                string lines = File.ReadAllText(str.Key);
                
                lines = lines.Replace(str.Str,str.NewStr);
                File.WriteAllText(str.Key, lines);
            }
            
            Console.WriteLine($"\nFile(s) strings correctly imported \n JSON Payload: {JSONPath}.");
        }
        
        public static void Export(string path)
        {
            if (!Path.IsPathRooted(path))
            {
                Console.WriteLine("Error: Path isn't valid");
                return;
            }
            
            var strings = new List<Storage>();
            var lines = File.ReadAllLines(path);
            
            for (var i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                
                // Add here your filters
                if (line.Contains("Console."))
                {
                    continue;
                }
                
                int start = line.IndexOf("\"", StringComparison.Ordinal)+1;
                int end = line.LastIndexOf("\"", StringComparison.Ordinal);
                
                string str = line.Substring(start, end - start);

                if (char.IsLower(str[0]) && !char.IsSymbol(str[0]))
                {
                    continue;
                }
                
                strings.Add(new Storage(path)
                    { Index = i+1, Start = start, End = end, Str = str, NewStr = ""});
            }
            
            File.WriteAllText(JSONPath, 
                JsonSerializer.Serialize(strings, 
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }), Encoding.UTF8);

            Console.WriteLine($"\nFile(s) strings correctly exported\nOutput {JSONPath}");
        }
    }
}
