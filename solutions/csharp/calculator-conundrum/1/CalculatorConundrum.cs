using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        int result = 0;
        switch (operation) {
            case "+":
                result = operand1 + operand2;
                break;
            case "*":
                result = operand1 * operand2;
                break;
            case "/":
                if (operand2 == 0) return "Division by zero is not allowed.";
                result = operand1 / operand2;
                break;
            case null:
                throw new ArgumentNullException();
            case "":
                throw new ArgumentException();
            default:
                throw new ArgumentOutOfRangeException();
        }
        return $"{operand1} {operation} {operand2} = {result}";
    }
}
