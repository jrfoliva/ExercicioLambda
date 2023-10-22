using System;
using ExercicioLambda.Entities;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExercicioLambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = @"c:\temp\products.txt";
            Console.WriteLine(path);

            List<Product> list = new List<Product>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        list.Add(new Product(fields[0], double.Parse(fields[1], CultureInfo.InvariantCulture)));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred.");
                Console.WriteLine(e);
            }

            /* Ler um arquivo no formato csv contendo o nome do produto e o valor.
             * Exibir o preço médio entre os preços da lista de produtos.
             * Exibir o nome dos produtos que os preços sejam inferiores ao preço médio. Deve 
             * ser exibido em orderm decrescente.
             */
            //Respondendo conforme as necessidades do problema.
            var avgPrice = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Average Price: " + avgPrice.ToString("F2", CultureInfo.InvariantCulture));

            //var l1 = list.Where(p => p.Price < avgPrice).OrderByDescending(p => p.Name).Select(p => p.Name);
            /*var l1 =
                (from p in list
                 where p.Price < avgPrice
                 orderby p.Name descending
                 select p.Name); */
            /*
            foreach(string pName in l1)
            {
                Console.WriteLine(pName);
            }
            */

            // Exibindo todas as informações de produtos
            //var l2 = list.Where(p => p.Price < avgPrice).OrderByDescending(p => p.Name);
            var l2 =
                (from p in list
                 where p.Price < avgPrice
                 orderby p.Name descending
                 select p);
            if (l2.Count() > 0)
            {
                Console.WriteLine("\nProdutos com preço inferiores a média em ordem decrescente de nome...");
                foreach (Product p in l2)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}