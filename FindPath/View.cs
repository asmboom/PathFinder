using System;

namespace FindPath
{
    public static class View
    {
        public static void PrintResult()
        {
            Console.WriteLine(Controller.GetResult());
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void PrintItems()
        {
            foreach (var i in Controller.items)
                i.Print();
        }
    }
}

