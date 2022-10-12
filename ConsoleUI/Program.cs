using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using WordCountLibrary;

namespace ConsoleUI
{
    class Program
    {
        private static string[] tests = new string[]
        {
            @"The test of the 
            best way to handle

multiple lines,   extra spaces and more.",
            @"Using the starter app, create code that will 
loop through the strings and identify the total 
character count, the number of characters
excluding whitespace (including line returns), and the
number of words in the string. Finally, list each word, ensuring it
is a valid word."
        };

        /* 
            First string (tests[0]) Values:
            Total Words: 14
            Total Characters: 89
            Character count (minus line returns and spaces): 60
            Most used word: the (2 times)
            Most used character: e (10 times)

            Second string (tests[1]) Values:
            Total Words: 45
            Total Characters: 276
            Character count (minus line returns and spaces): 230
            Most used word: the (6 times)
            Most used character: t (24 times)
        */

        static void Main(string[] args)
        {
            foreach (string test in tests)
            {
                WordCounter counter = new WordCounter(test);

                Console.WriteLine("String Values: ");
                Console.WriteLine($"Total Words: {counter.TotalWords}");
                Console.WriteLine($"Total Characters: {counter.TotalCharacters}");
                Console.WriteLine($"Character count: {counter.CharacterCount}");
                Console.WriteLine($"Most used word: {counter.MostUsedWord.word} ({counter.MostUsedWord.count} times)");
                Console.WriteLine($"Most used character: {counter.MostUsedCharacter.character} ({counter.MostUsedCharacter.count} times)");
                Console.WriteLine($"All words: {String.Join(", ", counter.WordsInString)}");
                Console.WriteLine($"Unique words:{String.Join(", ", counter.UniqueWords)} ");
                Console.WriteLine($"Unique Characters:{String.Join(", ", counter.UniqueCharacters)} ");

                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
