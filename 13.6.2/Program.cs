using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        var path = @"C:\Courses C#\Module13\Text1.txt";
        var textFile = new SortedDictionary<string, Words>();
        var myList = File.ReadAllLines(path);
        var stackStrings = new Stack<string>();
        var stackCouter = new Stack<long>();
        
        foreach (var item in myList)
        {
            string str =  SymbolCheker(item);
            string[] strings = str.Split(' ');
            foreach(string s in strings)
            {
                if (s != "")
                {
                    if (textFile.ContainsKey(s))
                    {
                        textFile.TryGetValue(s, out Words word);
                        word.count++;
                    }
                    else
                    {
                        textFile.Add(s, new Words(1));
                    }
                }
            }
        }
        foreach(var item in textFile.OrderBy(pair => pair.Value.count))
        {
           stackStrings.Push(item.Key);
           stackCouter.Push(item.Value.count);
        }
        for(int i = 0; i<10; i++)
        {
            Console.WriteLine("{0} место. Слово: \"{1}\", используется {2} раз.", i+1, stackStrings.Pop(), stackCouter.Pop() );
        }
    }
       
    public static string SymbolCheker(string symbol)
    {
        symbol= new string(symbol.Where(c => !char.IsPunctuation(c)).ToArray());
        symbol = symbol.ToLower();
        return symbol;
    }
}

