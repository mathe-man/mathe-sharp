namespace Core;

public class Lexer
{
    private readonly List<string> _input;
    private string _current;
    private int _pos;
    
    public Lexer(List<string> input) { _input = input; }

    public List<Token> Tokenize()
    {
        List<Token> tokens = new ();

        for (int i = 0; i < _input.Count; i++)
        {
            _current = _input[i];
            _pos = 0;
            while (_pos < _current.Length)
            {
                char c = _current[_pos];

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
            tokens.Add(new Token(TokenType.NewLine, "\n"));
        }

        tokens.Add(new Token(TokenType.EndOfFile, "")); // End of program
        return tokens;
    }
    
    private string ReadWhile(Func<char, bool> predicate)
    {
        int start = _pos;
        while (_pos < _current.Length && predicate(_current[_pos]))
            _pos++;
        return _current.Substring(start, _pos - start);
    }
}