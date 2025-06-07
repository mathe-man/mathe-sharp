namespace Core;

public class Lexer
{
    private readonly string _input;
    private int _pos;
    
    public Lexer(string input) { _input = input; }

    public List<Token> Tokenize()
    {
        List<Token> tokens = new ();

        while (_pos < _input.Length)
        {
            char c = _input[_pos];
            
            // Skip spaces
            if (char.IsWhiteSpace(c))
                _pos++;
            else if (char.IsDigit(c))
            {
                string number = ReadWhile(char.IsDigit); // Read the whole number
                tokens.Add(new Token(TokenType.Number, number));
            }
            else if ("+-*/".Contains(c))
            {
                tokens.Add(new Token(TokenType.Operator, c.ToString()));
                _pos++;
            }
            else
                throw new Exception($"Invalid character '{c}' at index {_pos}");
            
            
        }
        
        tokens.Add(new Token(TokenType.EndOfFile, "")); // End of program
        return tokens;
    }
    
    private string ReadWhile(Func<char, bool> predicate)
    {
        int start = _pos;
        while (_pos < _input.Length && predicate(_input[_pos]))
            _pos++;
        return _input.Substring(start, _pos - start);
    }
}