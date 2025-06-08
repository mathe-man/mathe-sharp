namespace Core;

public class Parser
{
    private List<Token> _tokens;
    private int _pos;

    private static Dictionary<string, int> _precedence = new()
    {
        { "+", 1 },
        { "-", 2 },
        { "*", 3 },
        { "/", 4 }
    };
    
    public Parser(List<Token> tokens) { _tokens = tokens; }

    public Expression Parse()
    { return ParseExpression(0); }

    private Expression ParseExpression(int minPrecedence)
    {
        Expression left = ParsePrimary();

        while (true)
        {
            Token op = Peek();
            
            if (op.Type != TokenType.Operator || !_precedence.ContainsKey(op.TextValue))
                break;
            
            int prec = _precedence[op.TextValue];
            if (prec < minPrecedence)
                break;
            
            Advance();
            Expression right = ParseExpression(prec + 1);
            left = new BinaryExpression(left, op.TextValue, right);
        }

        Console.WriteLine($"{left.ReadableForm()}");
        return left;
    }

    private Expression ParsePrimary()
    {
        Token token = Advance();
        
        if (token.Type == TokenType.Number)
            return new LiteralExpression(int.Parse(token.TextValue));
        
        throw new Exception($"Unexpected primary expression, token type: {token.Type} at position {_pos}");
    }
    
    private Token Peek() => _tokens[_pos];
    private Token Advance() => _tokens[_pos++];
}