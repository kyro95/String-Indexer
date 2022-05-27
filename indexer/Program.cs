using System;

namespace Indexer 
{
    internal class Program
    {
        private static string Syntax { get; } = "indexer commands: " +
                                               "\n indexer -e [path] — exports strings from a file or a folder " +
                                               "\n indexer -i — imports all the strings saved which were exported in 'Strings.json'";

        static void Main(string[] args)
        {
            try
            {
                var option = args[0];

                switch (option)
                {
                    case "-e":
                    {
                        var path = args[1];
                        
                        Indexer.Export(path);
                        break;
                    }
                    case "-i":
                    {
                        Indexer.Import();
                        break;
                    }

                    default:
                    {
                        Console.WriteLine(Syntax);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(Syntax);
            }
        }
    }
}