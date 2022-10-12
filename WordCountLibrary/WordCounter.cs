using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCountLibrary
{
    public class WordCounter
    {
        public int TotalWords { get; set; }
        public int TotalCharacters { get; set; }
        public int CharacterCount { get; set; }
        public (string word, int count) MostUsedWord { get; set; }
        public (char character, int count) MostUsedCharacter { get; set; }
        public List<string> WordsInString { get; set; }
        public List<string> UniqueWords { get; set; }
        public List<char> UniqueCharacters { get; set; }

        public WordCounter(string lines)
        {
            lines = lines.Replace(Environment.NewLine, " ");

            TotalWords = GetWordsFromString(lines).Count;

            TotalCharacters = CountCharacters(lines);

            CharacterCount = CheckCharacterCount(lines).Count;

            MostUsedWord = CheckMostUsedWord(lines);
            MostUsedCharacter = CheckMostUsedCharacter(lines);
            WordsInString = GetWordsFromString(lines).ConvertAll(x=> x.ToLower());
            UniqueWords = WordsInString.Distinct().ToList();
            UniqueCharacters = CheckCharacterCount(lines).Distinct().ToList();
        }

        private (char, int) CheckMostUsedCharacter(string lines)
        {
            List<char> chars = CheckCharacterCount(lines);
            chars = chars.ConvertAll(x => x.ToString().ToLower()[0]);

            var mostOccurances = chars.GroupBy(i => i).OrderByDescending(grp => grp.Count()).First();
            return (mostOccurances.Key, mostOccurances.Count());
        }

        private (string, int) CheckMostUsedWord(string lines)
        {
            List<string> words = GetWordsFromString(lines);
            words = words.ConvertAll(x => x.ToLower());

            var mostOccurances = words.GroupBy(i=>i).OrderByDescending(grp => grp.Count()).First();
            return (mostOccurances.Key,mostOccurances.Count());
        }

        private List<char> CheckCharacterCount(string lines)
        {
            lines = lines.Replace(" ","");
            return lines.ToCharArray().ToList();

        }

        private int CountCharacters(string lines)
        {
            return lines.ToCharArray().Length;
        }

        private List<string> GetWordsFromString(string lines)
        {
            Regex alphaCheck = new Regex("[^a-zA-Z ]");
            string cleanLines = alphaCheck.Replace(lines, "");

            List<string> words = cleanLines.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            return words;
        }
    }
}
