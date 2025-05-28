using System;
using System.IO;

namespace ArquivosExpDados
    {
    class Program
        {
        static void Main(string[] args) {

            string filePath = @"c:\temp\arquivo.txt";
            string targetPath = @"c:\temp\arquivo2.txt";
            //string filePath = @"c:\temp\arquivo.txt";//Exeptions tratada

            try
                {
                string[] lines = File.ReadAllLines(filePath);

                using (StreamWriter sw = File.AppendText(targetPath))
                    {
                    foreach (string line in lines)
                        {
                        sw.WriteLine(line.ToUpper());

                        }
                    }
                }
            catch (Exception ex)
                {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + ex.Message);
                }
        }
    }
}


/*
 *     class Program
        {
        static void Main(string[] args) {

            string filePath = @"c:\temp\arquivo.txt";
            string targetPath = @"c:\temp\arquivo2.txt";
            //string filePath = @"c:\temp\arquivo.txt";//Exeptions tratada

            try
                {
                //using (FileStream fs = new FileStream(filePath, FileMode.Open)){
                //  using (StreamReader sr = new StreamReader(fs)) { 
                using (StreamReader sr = File.OpenText(filePath)) {
                    string line;
                    while (!sr.EndOfStream)
                        {
                        line = sr.ReadLine();
                        Console.WriteLine(line);
                        }
                    }
                }
            //}//modo antigo do FileStream StreamReader 
            catch (Exception ex){
                        Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + ex.Message);
            }
        }
    }
*/
