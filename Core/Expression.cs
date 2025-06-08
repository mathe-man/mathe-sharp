namespace Core;

public interface IReadable
{ public string ReadableForm(); }

public abstract class Expression : IReadable
{
    public abstract float Evaluate();
    public abstract string ReadableForm();
}

public class LiteralExpression : Expression
{
    public float Value;
    public LiteralExpression(float value) { Value = value; }
    public override float Evaluate() => Value;
    public override string ReadableForm() => $"{Value}";
}

public class BinaryExpression : Expression
{
    public Expression Left;
    public string Operator;
    public Expression Right;
    
    public BinaryExpression(Expression left, string op, Expression right)
    {
        Left = left;
        Operator = op;
        Right = right;
    }

    public override float Evaluate()
    {
        float l = Left.Evaluate();
        float r = Right.Evaluate();
        return Operator switch
        {
            "+" => l + r,
            "-" => l - r,
            "*" => l * r,
            "/" => l / r,
            _ => throw new Exception("Unknown operator: " + Operator)
        };
    }

    public override string ReadableForm()
        => $"({Left.Evaluate()} {Operator} {Right.Evaluate()} = {this.Evaluate()})";
}

public class SequenceExpression : Expression
{
    public List<Expression> Expressions {get;}
    
    public SequenceExpression(List<Expression> expressions)
    { Expressions = expressions; }

    public override float Evaluate()
    {
        float result = 0;
        foreach (Expression e in Expressions)
            result = e.Evaluate();
        
        return result;
    }

    public override string ReadableForm()
    {
        string result = "";
        foreach (Expression e in Expressions)
            result += e.ReadableForm() + "\n";
        
        return result;
    }
}