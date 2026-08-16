using System.Collections;

namespace Solution05
{
    internal class Program
    {
        public static int CalPoints(string[] operations)
        {
            Stack<int> Stack = new Stack<int>();
            int Sum = 0;
            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i] == "+")
                {
                    int last = Stack.Pop();
                    int previouslast = Stack.Pop();
                    Stack.Push(previouslast);
                    Stack.Push(last);
                    Stack.Push(last + previouslast);
                }

                else if (operations[i] == "D")
                {
                    Stack.Push(Stack.Peek() * 2);
                }


                else if (operations[i] == "C")
                {
                    Stack.Pop();
                }

                else
                {
                    int number = int.Parse(operations[i]);
                    Stack.Push(number);
                }


            }


            foreach (var i in Stack)
            {
                Sum += i;
            }

            return Sum;
        }
        static void Main(string[] args)
        {
            string[][] testCases =
     {
        new[] { "5", "2", "C", "D", "+" },
        new[] { "5", "-2", "4", "C", "D", "9", "+", "+" },
        new[] { "1", "2", "3", "+" },
        new[] { "5", "10", "C", "D", "+" }
    };

            foreach (var operations in testCases)
            {
                int result = CalPoints(operations);

                Console.WriteLine(
                    $"Operations: [{string.Join(", ", operations)}]");

                Console.WriteLine($"Result: {result}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}
