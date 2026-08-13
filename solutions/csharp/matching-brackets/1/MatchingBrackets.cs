public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        var stack = new Stack<char>();

        foreach (char c in input)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                    stack.Push(c);
                    break;
                case ')':
                case ']':
                case '}':
                    {
                        char expected = c == ')' ? '(' : c == ']' ? '[' : '{';
                        if (stack.Count == 0 || stack.Pop() != expected) return false;
                        break;
                    }
                default:
                    break;
            }
        }
        
        return stack.Count == 0;
    }
}
