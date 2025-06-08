using Core;

namespace CLI;

class Program
{
    static void Main(string[] args)
    {
        string defaultProgram = "7 + 8 / 2";
        Console.WriteLine($"Default Program: {defaultProgram}");
        Console.Write(">>");
        string? input = Console.ReadLine();
        
        Lexer lexer = new Lexer(string.IsNullOrWhiteSpace(input) ? defaultProgram : input
        );
        Parser parser = new Parser(lexer.Tokenize());
        
        Console.WriteLine(parser.Parse().ReadableForm());
    }
}