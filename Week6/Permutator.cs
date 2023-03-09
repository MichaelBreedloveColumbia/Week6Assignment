using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Week6
{
    public class Permutator
    {
        char[] Chars;
        int Size;

        public Permutator(string chars, int size = 5)
        {
            Size = size;

            Chars = chars.ToCharArray();

            while (Chars.Length < Size)
            {
                Clear();
                Write($"Your input was too short. It must be {Size} characters in length. Please enter a new string.");
                Chars = ReadLine().ToCharArray();
            }

            Clear();

            if (Chars.Length > Size)
            {
                Array.Resize(ref Chars, Size);
                ForegroundColor = ConsoleColor.Red;
                Write($"NOTICE: ");
                ForegroundColor = ConsoleColor.White;
                Write($"Your input was longer than {Size} characters. It has been shortened to ");
                ForegroundColor = ConsoleColor.DarkYellow;
                WriteLine(MakeStringFromChars(Chars) + ".");
                ForegroundColor = ConsoleColor.White;
                ReadKey();
            }

            Clear();
            Write("Your input was ");
            ForegroundColor = ConsoleColor.DarkYellow;
            Write(MakeStringFromChars(Chars));
            ForegroundColor = ConsoleColor.White;
            WriteLine(". Press any key to retrieve its permutations, ordered partitions, and combinations.");
            ReadKey();

            Process();
        }

        void Process()
        {
            //I decided to make it customizable to work with multiple sizes, so anything that relies on "5" in the assignment description just defaults to the last element, since
            //that's what it would be in inputs of size 5.

            WriteLine($"There are a total of {NumPermutations()} permutations which can be made from your input string.");
            WriteLine("All of the possible permutations for your input string are:");
            Permutation(MakeStringFromChars(Chars), 0, Chars.Length - 1);

            WriteLine($"All of the ordered partitions of N, where N is the length of your input ({Size}) are:");
            OrderedPartitions();

            WriteLine($"There are a total of {NumCombinations()} combinations which can be made from your input string.");
            WriteLine("All of the possible combinations for your input string are:");
            Combination(MakeStringFromChars(Chars), 0, Chars.Length - 1);
        }

        //Calculates the number of permutations given the permutation count formula.
        int NumPermutations()
        {
            int num = Size;

            for (int i = Size - 1; i > 1; i--)
            {
                num *= i;
            }

            return num;
        }
        //Cycles through each char in our input and swaps it with another until we have attained all permutations.
        void Permutation(string input, int CurrentValue, int Length)
        {
            if (CurrentValue == Length) //We have reached the end of this cycle, meaning we've finished this permutation. Print it to the console.
            {
                WriteLine(input);
            }
            else
            {
                for (int i = CurrentValue; i <= Length; i++) //As long as we have not reached the end of this cycle, meaning we have not swapped every char in this cycle:
                {
                    input = SwapTwoChars(input, CurrentValue, i);   //1. Swap our current char in the main cycle with our current char in this smaller cyle.
                    Permutation(input, CurrentValue + 1, Length);   //2. Start a new permutation cycle, using our new permutation, starting with the next char in the main cycle.
                    input = SwapTwoChars(input, CurrentValue, i);   //3. Swap once again to return to the old permutation. We then advance to the next char in this cycle and repeat.
                }
            }
        }

        void OrderedPartitions()
        {
            WriteLine("I don't know.");
        }

        //Calculates the number of combinations given the combination count formula.
        int NumCombinations()
        {
            return (int)Math.Pow(Size, Size);
        }

        //Cycles through each char in our input and swaps it with another until we have attained all combinations.
        void Combination(string input, int CurrentValue, int Length)
        {
            WriteLine("I don't know.");
        }

        //Swaps the position of two characters in a string, and returns the result.
        string SwapTwoChars(string input, int a, int b)
        {
            //Start by turning out input into a char array.
            char[] chars = input.ToCharArray();

            //Store A for later.
            char Placeholder = chars[a];

            //Replace A with B.
            chars[a] = chars[b];

            //Replace B with Placeholder, which is A.
            chars[b] = Placeholder;

            //Return a new string created by our char array.
            return new string(chars);
        }

        //Removes a char from a string and returns the result.
        string RemoveCharFromString(string input, int removal)
        {
            char[] chars = input.ToCharArray();

            if (removal == chars.Length - 1)
            {
                Array.Resize(ref chars, chars.Length - 1);
            }
            else
            {
                for (int i = removal; i < chars.Length - 1; i++)
                {
                    chars[i] = chars[i + 1];
                }

                Array.Resize(ref chars, chars.Length - 1);
            }

            return new string(chars);
        }

        //Converts a char array to a string.
        string MakeStringFromChars(char[] chars)
        {
            return new string(chars);
        }
    }
}
