using Core;

namespace CLI;

class Program
{
    static void Main(string[] args)
    {
        List<string> defaultProgram = [
                "7 + 8 / 2",
                "4 + 4 / 4"];
        
        List<string> program = new ();
        while (true)
        {
            Console.Write(">>");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                break;
            
            program.Add(input);
        }

        if (program.Count == 0)
        {
            program = defaultProgram;
            Console.WriteLine("Program is :");
            foreach (string line in program)
                Console.WriteLine(line);
        }
        Console.WriteLine("____________\n");
        
        Lexer lexer = new Lexer(program);
        
        Parser parser = new Parser(lexer.Tokenize());
        
        Console.WriteLine($"Parser result: \n{parser.Parse().ReadableForm()}");
    }
}