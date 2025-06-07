namespace Core;

public abstract class Expression
{
    public abstract float Evaluate();
    public abstract string ReadeableForm();
}

public class LiteralExpression : Expression
{
    public float Value;
    public LiteralExpression(float value) { Value = value; }
    public override float Evaluate() => Value;
    public override string ReadeableForm() => $"{Value}";
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

    public override string ReadeableForm()
        => $"({Left.Evaluate()} {Operator} {Right.Evaluate()} = {this.Evaluate()})";
}