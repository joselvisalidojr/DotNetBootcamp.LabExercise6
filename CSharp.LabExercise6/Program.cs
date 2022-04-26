using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharp.LabExercise6
{
    internal class Program
    {   

        class ScrabbleScorer
        {
            public int totalScore { get; set; }

            private static Dictionary<char, int> pointsPerLetter = new Dictionary<char, int>(){
                {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1},
                {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
                {'D', 2}, {'G', 2},
                {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
                {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
                {'K', 5},
                {'J', 8}, {'X', 8},
                {'Q',10}, {'Z',10},
            };

            private int points;
            public int Score(string word)
            {
                totalScore = 0;
                foreach (char ch in word)
                {
                    pointsPerLetter.TryGetValue(ch, out points);
                    totalScore += points;
                }

                return totalScore;

            }
        }

        class WordValidator
        {
            private int errorCount;
            public bool validateWord(string word)
            {
                errorCount = 0;
                if (this.checkWhiteSpaces(word))
                {
                    errorCount++;
                }
                if (this.checkSpecialCharacters(word))
                {
                    errorCount++;
                }
                if (this.checkNumbers(word))
                {
                    errorCount++;
                }

                if(errorCount > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            private bool checkWhiteSpaces(string word)
            {
                bool hasWhitespace = word.Contains(" ");
                if (hasWhitespace)
                {
                    Console.WriteLine("Input has Whitespace/s!");
                }
                return hasWhitespace;
            }

            private bool checkSpecialCharacters(string word)
            {
                Regex rgx = new Regex("[^A-Za-z0-9 ]");
                bool hasSpecialCharacters = rgx.IsMatch(word);
                if (hasSpecialCharacters)
                {
                    Console.WriteLine("Input has Special Character/s!");

                }
                return hasSpecialCharacters;
            }

            private bool checkNumbers(string word)
            {
                bool hasNumbers = word.Any(char.IsDigit);
                if (hasNumbers)
                {
                    Console.WriteLine("Input has Number/s!");
                }
                return hasNumbers;
            }

        }
        static void Main(string[] args)
        {   
            WordValidator validate = new WordValidator();
            ScrabbleScorer scrabble = new ScrabbleScorer();
            string continueLoop;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Activity 6, Scrabble Scorer");
                Console.Write("\nEnter Word: ");
                string wordInput = Console.ReadLine();
                if(validate.validateWord(wordInput))
                {
                    Console.WriteLine($"Total Score: {scrabble.Score(wordInput.ToUpper())}");
                }

                Console.Write("\nInput 'y' to try again: ");
                continueLoop = Console.ReadLine();
            } while (continueLoop.ToLower() == "y");
        }
    }
}
