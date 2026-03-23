using System;

class Program
{
    static void Main()
    {
        string[] stack = new string[10]; // array stack
        int top = -1;

        // Sample actions
        string[] actions = { "Type A", "Type B", "Type C", "Undo", "Undo" };

        foreach (string action in actions)
        {
            if (action.StartsWith("Type"))
            {
                // PUSH
                if (top < stack.Length - 1)
                {
                    top++;
                    stack[top] = action;
                }
            }
            else if (action == "Undo")
            {
                // POP
                if (top >= 0)
                {
                    top--;
                }
                else
                {
                    Console.WriteLine("Nothing to undo!");
                }
            }

            // Display current state
            Console.Write("Current State: ");
            for (int i = 0; i <= top; i++)
            {
                Console.Write(stack[i] + " ");
            }
            Console.WriteLine();
        }
    }
}