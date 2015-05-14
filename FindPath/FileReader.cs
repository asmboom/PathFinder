using System;
using System.IO;
using System.Collections.Generic;

namespace FindPath
{
    public static class FileReader
    {
        public static List<Item> items;
        public static Node root;

        public static void StreamIn(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName + ".txt"))
                {
                    Item path = new Item();
                    items = new List<Item>();
                    String line;

                    if ((line = sr.ReadLine()) != null)
                        path = new Item(GetStrByIndex(line, 0), GetStrByIndex(line, 1), 0f);
                   

                    while ((line = sr.ReadLine()) != null)
                        items.Add(new Item(GetStrByIndex(line, 0), GetStrByIndex(line, 1), float.Parse(GetStrByIndex(line, 2))));

                    sr.Close();
                    Controller.InitGraph(path, items);
                }
            }
            catch (Exception e)
            {
                View.PrintMessage(e.Message);
            }
        }

        public static void StreamOut(string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.WriteLine(Controller.GetResult());
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                View.PrintMessage(e.Message);
            }
        }

        public static string GetStrByIndex(string str, int index)
        {
            string[] split = str.Split(new Char [] { ' ', ',' });

            try
            {
                return split[index];
            }
            catch (Exception e)
            {
                View.PrintMessage(e.Message);
                return "";
            }
        }
    }
}
