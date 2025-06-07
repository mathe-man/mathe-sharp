namespace Core;

public enum TokenType
{
    Number,
    Operator,
    EndOfFile
}

public class Token
{
    public TokenType Type { get; set; }
    public string TextValue { get; set; }
    
    public Token(TokenType type, string textValue)
    {
        Type = type;
        TextValue = textValue;
    }
}