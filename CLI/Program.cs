using Core;

namespace CLI;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write(">>");
        Lexer lexer = new Lexer(Console.ReadLine());
        
        foreach (Token token in lexer.Tokenize())
            Console.Write(token.Type + " ");
    }
}