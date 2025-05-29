using System;
using System.Globalization;
using System.IO;
using ArquiovosExportacaoDados.Entities;

namespace ArquivosExpDados
    {
    class Program
        {
        static void Main(string[] args) {

            Console.WriteLine("Digite o caminho do arquivo de origem:");
            string filePath = Console.ReadLine();

            try
                {
                string[] lines = File.ReadAllLines(filePath);
                
                string sourceFolderPath = Path.GetDirectoryName(filePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\resumo.csv";

                Directory.CreateDirectory(targetFolderPath); // Cria o diretório de destino se não existir


                using (StreamWriter sw = File.AppendText(targetFilePath))
                    {
                    foreach (string line in lines)
                        {
                        string[] fields = line.Split(',');
                        string descProduct = fields[0];
                        double precoUnit = double.Parse(fields[1],CultureInfo.InvariantCulture);
                        int quantidProduct = int.Parse(fields[2]);

                        Product prod = new Product(descProduct, precoUnit, quantidProduct);

                        sw.WriteLine(prod.DescProcuct + "," + prod.TotalPreco().ToString("F2", CultureInfo.InvariantCulture));

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


