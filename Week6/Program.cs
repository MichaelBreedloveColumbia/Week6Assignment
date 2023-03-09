using Week6;
using static System.Console;

bool Working = true;
while (Working)
{
    Write("Please enter a string: ");
    Permutator permutator = new Permutator(ReadLine(), 5);

    Write("Would you like to repeat this process with another string? [Y/N]");
    Working = ReadLine().ToUpper() == "Y";
}