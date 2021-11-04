using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaLongPaths;

namespace dirlist
{
    class Program
    {
        static void Main(string[] args)
        {
            bool recursive = false;
            string path = string.Empty;

            var parser = new CommandLine();
            parser.Parse(args);

            if (parser.Arguments.Count > 0)
            {
                if (parser.Arguments.ContainsKey("s"))
                {
                    recursive = true;
                }
                if (parser.Arguments.ContainsKey("path"))
                {
                    path = parser.Arguments["path"][0];
                }
            }

            try
            {
                if (ZlpIOHelper.FileExists(path))
                {
                    ZlpFileInfo fi = new ZlpFileInfo(path);
                    Console.WriteLine(fi.FullName);
                }
                else if (ZlpIOHelper.DirectoryExists(path))
                {
                    ZlpDirectoryInfo di = new ZlpDirectoryInfo(path);
                    Dir(di);
                }
                else { Console.WriteLine("File Not Found"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static void Dir(ZlpDirectoryInfo dir)
        {
            try
            {
                Console.WriteLine(dir.FullName);

                // Show files
                foreach (ZlpFileInfo f in dir.GetFiles())
                {
                    Console.WriteLine(f);
                }

                // Enumerate folders
                foreach (ZlpDirectoryInfo d in dir.GetDirectories())
                {
                    Dir(d);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
