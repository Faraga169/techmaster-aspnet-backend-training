namespace Solution07
{
    internal class Program
    {
        public static bool IsValid(string s)
        {

            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {

                if (c == '{' || c == '[' || c == '(')
                {

                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0)
                    {

                        return false;
                    }
                    var top = stack.Pop();
                    if ((c == ')' && top != '(') ||
                       (c == ']' && top != '[') ||
                       (c == '}' && top != '{'))
                    {
                        return false;
                    }

                }
            }
            return stack.Count == 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("()"));        // True
            Console.WriteLine(IsValid("()[]{}"));    // True
            Console.WriteLine(IsValid("{[]}"));      // True

            Console.WriteLine(IsValid("(]"));        // False
            Console.WriteLine(IsValid("([)]"));      // False

            Console.WriteLine(IsValid("["));         // False
            Console.WriteLine(IsValid("]"));         // False
            Console.WriteLine(IsValid(")("));        // False

            Console.WriteLine(IsValid("((()))"));     // True
            Console.WriteLine(IsValid("((())"));      // False
            Console.WriteLine(IsValid("({[]})"));     // True

            Console.WriteLine(IsValid(""));          // True
        }
    }
}
