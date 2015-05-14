using System;
using System.Collections.Generic;
using System.Linq;

namespace FindPath
{
    public class Controller
    {
        public static string inputFileName = "input";
        public static string outputFileName = "output";
        private static Node tree;
        public static Item path;
        public static List<Item> items;
        public static Dictionary <List<string>, float> allPaths;
        private static Controller instance;

        private Controller()
        {
        }

        public static Controller Instance
        {
            get
            {
                if (instance == null)
                    Init();

                return instance;
            }
        }

        private static void Init()
        {
            instance = new Controller();
            allPaths = new Dictionary<List<string>, float>();
            FileReader.StreamIn(inputFileName);
        }

        public static void InitGraph(Item root, List<Item> items)
        {
            path = root;
            tree = path.ToNode();
            Controller.items = items;

            SetGraph(tree);
            FindPath(tree, new List<string>(), 0f);

            FileReader.StreamOut(outputFileName);
        }

        private static void SetGraph(Node node)
        {
            foreach (var i in items)
            {
                if (node.name.Equals(i.start))
                {
                    var temp = new Node(i.end, i.weight);
                    SetGraph(temp);
                    node.AddChild(temp);
                }
            }
        }

        private static void FindPath(Node node, List<string> route, float weight)
        {
            route.Add(node.name);
            var length = weight + node.weight;

            if (node.children.Count == 0 || node.name == path.end)
            {   
                if (route.Contains(path.start) && route.Contains(path.end))
                    allPaths.Add(route, length);
                
                return;
            }
                
            foreach (var i in node.children)
            {
                var list = route.ToList();
                FindPath(i, list, length);
            }
        }

        public static string GetResult()
        {
            if (allPaths.Count == 0)
                return "null";
            
            var sortedDict = from entry in allPaths 
                orderby entry.Value
                ascending
                select entry;

            string str = "";

            foreach (var s in sortedDict.First().Key)
                str += s + " ";

            return ("Path: " + str +
            "\nFuel: " + sortedDict.First().Value);
        }

       
    }
}

