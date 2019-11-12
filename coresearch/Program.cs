﻿using System;
using System.Collections.Generic;
using System.IO;

namespace coresearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // sample data http://mlg.ucd.ie/datasets/bbc.html
            Coresearch coresearch = new Coresearch(true);

            foreach (string file in Directory.EnumerateFiles("./", "*.txt", SearchOption.AllDirectories))
            {
                foreach (string line in File.ReadLines(file))
                {
                    coresearch.InsertResource(file, line.Replace(";", ""), file);
                }

                GC.Collect();
                
            }

            Console.WriteLine($"Words inserted {coresearch.Count}");

            while (true)
            {
                string userInput = Console.ReadLine();

                List<string> results = coresearch.Get(userInput);
                Console.WriteLine($"{results.Count} results for {userInput}");

                foreach (string el in results)
                {
                    Console.WriteLine(el);
                }
            }
        }
    }
}
