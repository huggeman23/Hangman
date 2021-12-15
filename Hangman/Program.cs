using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{

    internal class Program
    {
        public static string[] words = { "sås" , "language" , "typo"};

        public static int wordIndex;
        public static StringBuilder incorectGuess = new StringBuilder();
        public static char[] word ;
        public static int tries =10;

        static void Main(string[] args)
        {
            Random r = new Random();
            wordIndex = r.Next(words.Length);

            word= words[wordIndex].ToCharArray();
            

            for (int i = 0; i < words[wordIndex].Length; i++)
            {
                word[i]=char.Parse("_");
            }


            

            while (tries>0)
            {
                Console.WriteLine($"guess a word or letter guesses left:{tries} wrong guesses:{incorectGuess.ToString()}");
                Console.WriteLine(String.Join(" ", word));

                string guess = Console.ReadLine().ToLower();
              

                switch (guess.Length)
                {
                    case 1:

                        if (word.Contains(char.Parse(guess)) == false && incorectGuess.ToString().Contains(guess) == false)
                        {
                            guessLetter(guess);
                        }
                        else
                        {
                            Console.WriteLine("alredy guessed");
                        }

                        break;
                    default:
                        guessWord(guess);
                        break;
                }
                Console.ReadLine();  

                if (words[wordIndex].Contains(String.Join("", word))){ break; }
            
                
                Console.Clear();
            }

        }
        public static void guessLetter(string guess)
        {

            if (words[wordIndex].Contains(guess))
            {
                for (int i = 0; i < words[wordIndex].Length; i++)
                {

                    if (words[wordIndex][i].ToString() == guess)
                    {

                        word[i] = char.Parse(guess);

                    }
                }
                
            }
            else
            {
                tries--;
                incorectGuess.Append(guess);
                
            }
        }

        public static void guessWord(string guess)
        {
            if (guess==words[wordIndex])
            {
                Console.WriteLine("you won");
            }
            else
            {
                tries--;
                Console.WriteLine("wrong word");
            }
        }
    }
}
