using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Hangman
{

    public class Program
    {
        public static string[] words={"sås","typo","language"};

        public static int wordIndex;
        public static StringBuilder incorectGuess = new StringBuilder();
        public static char[] word;
        private static int tries = 10;

        public void WordSet(int wor) 
        { 
            wordIndex = wor;
            word = words[wordIndex].ToCharArray();
            for (int i = 0; i < words[wordIndex].Length; i++)
            {
                word[i] = char.Parse("_");
            }
        }
        public int Try{ get { return tries; } }
        public string[] Words{ get { return words; } }


        static void Main(string[] args)
        {
            Random r = new Random();
            Program p = new Program();

            var path=Path.Combine(Directory.GetCurrentDirectory(), "text.txt");
            using (StreamReader sw = File.OpenText(path))
            {
                string fi = sw.ReadLine();
                words =fi.Split(',');
            }
           
            p.WordSet(r.Next(words.Length));
            
            while (tries>0)
            {
                Console.WriteLine($"guess a word or letter guesses left:{tries} wrong guesses:{incorectGuess.ToString()}");
                Console.WriteLine(String.Join(" ", word));

                string guess = Console.ReadLine().ToLower();
              

                switch (guess.Length)
                {
                    case 0:
                        Console.WriteLine("you must write something");
                        break;
                    case 1:

                        if (word.Contains(char.Parse(guess)) == false && incorectGuess.ToString().Contains(guess) == false)
                        {
                            p.guessLetter(guess);
                        }
                        else
                        {
                            Console.WriteLine("alredy guessed");
                        }

                        break;
                    default:
                        p.guessWord(guess);
                        break;
                }
                Console.ReadLine();  

                if (words[wordIndex].Contains(String.Join("", word))){ break; }
            
                
                Console.Clear();
            }

        }
        public void guessLetter(string guess)
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

        public void guessWord(string guess)
        {
            if (guess==words[wordIndex])
            {                
                Console.WriteLine("you won");
                tries = 0;
            }
            else
            {
                tries--;
                Console.WriteLine("wrong word");
            }
        }
    }
}
