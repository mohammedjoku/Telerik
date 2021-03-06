﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.IO;

namespace RemoveWordsWithPrefix
{
    class RemoveWordsWithPrefix
    {
        static void Main(string[] args)
        {
            string inputFileName = Console.ReadLine();

            try
            {
                StringBuilder result = new StringBuilder();
                StringBuilder word = new StringBuilder();
                const string prefix = "test";

                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        foreach (char symbol in line)
                        {
                            if ((symbol == '-') || (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= '0' && symbol <= '0'))
                            {
                                word.Append(symbol);
                            }
                            else
                            {
                                if (word.Length >= prefix.Length && prefix == word.ToString().Substring(0, prefix.Length))
                                {
                                    word.Clear();
                                }
                                result.Append(word.ToString());
                                result.Append(symbol);
                                word.Clear();
                            }
                        }

                        result.Append("\n");
                        line = reader.ReadLine();
                    }
                }

                using (StreamWriter writer = new StreamWriter(inputFileName))
                {
                    writer.Write(result.ToString());
                }
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
