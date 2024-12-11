using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctypora
{
    internal class Program
    {
        static void ModifyStringInFile(string filePath, string oldString, string newString)
        {
            if (!File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"File {filePath} not found。\nPlease put the tool in the program root directory");
                Console.ResetColor();
                return;
            }

            string fileContent;
            try
            {
                fileContent = File.ReadAllText(filePath, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Read file {filePath} error: {ex.Message}");
                Console.ResetColor();
                return;
            }

            fileContent = fileContent.Replace(oldString, newString);

            try
            {
                File.WriteAllText(filePath, fileContent, Encoding.UTF8);
                Console.WriteLine($"ok");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Write file {filePath} error: {ex.Message}\nPlease run as administrator.");
                Console.ResetColor();
            }
        }
        static void Main(string[] args)
        {
            string filePath = @"resources\page-dist\static\js\LicenseIndex.180dd4c7.5c394f9a.chunk.js";
            string oldString = "e.hasActivated=\"true\"==e.hasActivated";
            string newString = "e.hasActivated=\"true\"==\"true\"";
            ModifyStringInFile(filePath, oldString, newString);
            Console.Read();
        }
    }
}
