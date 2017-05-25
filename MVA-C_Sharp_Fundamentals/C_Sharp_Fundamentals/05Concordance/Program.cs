using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05Concordance {
    class Program {
        static void Main(string[] args) {
            Concordance larrysConcordance = new Concordance();
            larrysConcordance.generateConcordance(@"C:\Users\harry.tian\My Local Documents\input.txt");
            larrysConcordance.print();
            Console.ReadLine();
        }
    }

    public class Concordance {
        private HashSet<String> AbbreviationSet {
            get {
                if (_abbreviationSet == null) {
                    // read from file into _abbbre
                }
                return _abbreviationSet;
            };
        }
        private Dictionary<String, int> ConcordanceMap { get; set; }
        private const string ABBREVIATIONFILE = "Abbreviations.txt";
        private HashSet<String> _abbreviationSet = null;

        public Concordance() {
            ConcordanceMap = new Dictionary<String, int>();
            AbbreviationSet = new HashSet<string>();
            List<string> stringArr = HelperClass.ReadFile(ABBREVIATIONFILE);
            foreach (var abbrv in stringArr) {
                AbbreviationSet.Add(abbrv);
            }
        }

        public Dictionary<String, List<int>> generateConcordance(string inputFile) {
            List<string> inputFileArr = HelperClass.ReadFile(inputFile);
            foreach (var line in inputFileArr) {
                string[] maybeWordArr = Regex.Split(line, "(\\s|\\(|\\)|;|:|,|\")");
                foreach (var maybeWord in maybeWordArr) {
                    parseAndAddWord(maybeWord.ToLower());
                }
                ConcordanceMap.Remove("");
            }
            return null;
        }

        private void parseAndAddWord(String maybeWord) {
            string actualWord = "";
            int occuranceCount;
            if (maybeWord.EndsWith(".")) {
                if (AbbreviationSet.Contains(maybeWord)) {
                    actualWord = maybeWord;
                }
                else {
                    string[] maybeWordArr = Regex.Split(maybeWord, "\\.");
                    foreach (var word in maybeWordArr) {
                        parseAndAddWord(word);
                    }
                }
            }
            else {
                actualWord = (Regex.Match(maybeWord, "[\\w'-]*")).ToString();
            }

            try {
                if (ConcordanceMap.TryGetValue(actualWord, out occuranceCount)) {
                    ConcordanceMap[actualWord]++;
                }
                else {
                    ConcordanceMap.Add(actualWord, 1);
                }
            }
            catch (Exception e) {
                Console.WriteLine("There was no word match for {0}", maybeWord);
            }
        }

        public void print() {
            foreach (KeyValuePair<string, int> element in ConcordanceMap) {
                Console.WriteLine("Word: {0} | Occurance Count: {1}", element.Key, element.Value);
            }
        }
    }

    public static class HelperClass {
        public static List<string> ReadFile(string fileName) {
            List<string> stringArr = new List<string>();
            try {
                using (StreamReader myReader = new StreamReader(fileName)) {
                    String line = "";
                    while ((line = myReader.ReadLine()) != null) {
                        stringArr.Add(line);
                    }
                }
            }
            catch (FileNotFoundException e) {
                Console.WriteLine("The file {0} does not exist", fileName);
                Console.WriteLine(e.ToString());
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            return stringArr;
        }
    }
}

