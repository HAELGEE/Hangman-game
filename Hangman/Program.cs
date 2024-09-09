using System.Data;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace HangMan;

internal class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("========= Hangman =========");

        Name();
        MaskedWord();
        Letter();        
        

    }

    public static string name { get; set; }
    public static string maskedWord { get; set; }
    public static List<int> tries { get; set; } = new List<int>();
    public static List<char> letter { get; set; } = new List<char>();

    public static void Name()
    {
        Console.Write("What's the name you want the other to guess?: ");
        name = ReadHiddenInput().ToUpper();

        while (true)
        {
            if (name.Length < 6)
            {
                Console.WriteLine("\nThe word you just input need to be atleast 6 character long. Try again");
                name = ReadHiddenInput().ToUpper();
            }
            else
            {
                break;
            }
            
            
        }
        Console.WriteLine("\nThe name you just entered have been saved.");
    }
    static void Letter()
    {
        char[] maskedWordArray = new string('_', name.Length).ToCharArray();
        while (tries.Count < 6)
        {     
            Console.Write("\nPlease write a letter: ");
            string input = Console.ReadLine().ToUpper();

            if (string.IsNullOrEmpty(input) || input.Length != 1)
            {
                Console.WriteLine("Invalid input. Try again but with a single letter");
                continue;
            }

            char inputLetter = input[0];
            if (letter.Contains(inputLetter))
            {
                Console.WriteLine("You have already guessed that letter, try another one!");
            }
            else
            {
                letter.Add(inputLetter); 
                bool found = false;

                for (int i = 0; i < name.Length; i++)
                {
                    if (inputLetter == name[i])
                    {
                        maskedWordArray[i] = inputLetter;                        
                        found = true; 
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"The letter '{input}' is not in the word.");
                    tries.Add(1);
                }


                Game(tries.Count);
                
                maskedWord = new string(maskedWordArray);

                Console.WriteLine($"Current word: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(maskedWord);
                Console.ForegroundColor = ConsoleColor.Gray;

                if (maskedWord == name)
                {
                    Console.WriteLine("Congratulations! You guessed the word.");
                    break;
                }
            }

        }
    }
    static void MaskedWord()
    {
       
        Console.Clear();
        Console.Write($"This is the masked word: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(maskedWord + "\n");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    static void Game(int tries)
    {

        if (tries == 1)
        {

            Console.WriteLine("---------------");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");
        }
        else if (tries == 2)
        {

            Console.WriteLine("         |-----------");
            Console.WriteLine("         |");
            Console.WriteLine("         |");
            Console.WriteLine("         |");
            Console.WriteLine("         |");
            Console.WriteLine("---------------");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");
        }
        else if (tries == 3)
        {

            Console.WriteLine("         ------------");
            Console.WriteLine("         |          |");
            Console.WriteLine("         |          ");
            Console.WriteLine("         |");
            Console.WriteLine("         |");
            Console.WriteLine("         |");
            Console.WriteLine("---------------");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");
        }
        else if (tries == 4)
        {

            Console.WriteLine("         ------------");
            Console.WriteLine("         |          |");
            Console.WriteLine("         |          ()");
            Console.WriteLine("         |         ");
            Console.WriteLine("         |            ");
            Console.WriteLine("         |            ");
            Console.WriteLine("---------------");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");
        }
        else if (tries == 5)
        {

            Console.WriteLine("         ------------");
            Console.WriteLine("         |          |");
            Console.WriteLine("         |          ()");
            Console.WriteLine("         |         |()|");
            Console.WriteLine("         |            ");
            Console.WriteLine("         |            ");
            Console.WriteLine("---------------");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");
        }
        else if (tries == 6)
        {

            Console.WriteLine("         ---/--------");
            Console.WriteLine("         | /         |");
            Console.WriteLine("         |/         ()");
            Console.WriteLine("         |         |()|");
            Console.WriteLine("         |         _||_");
            Console.WriteLine("         |");
            Console.WriteLine("---------------");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");
            Console.WriteLine(" ||          ||");

            Console.WriteLine("(:=  GAME OVER  =:)");            
            
            Console.Write($"The word was: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name);
            Console.ForegroundColor = ConsoleColor.Gray;

        }
        
    }

    static string ReadHiddenInput()
    {
        string input = "";
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.Key != ConsoleKey.Enter)
            {
                input += keyInfo.KeyChar;
            }
        }
        while (keyInfo.Key != ConsoleKey.Enter);

        return input;
    }
}
    
