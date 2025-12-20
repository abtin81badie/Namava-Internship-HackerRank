using System;
using System.Collections.Generic;
using System.IO;

public static class QueryValidator
{
    public static void ValidateQueryCount(int q)
    {
        if (q < 1 || q > Math.Pow(10, 5))
            throw new ArgumentException(
                $"Query count must be between 1 and 100000.");
    }

    public static void ValidateType(int type)
    {
        if (type < 1 || type > 3)
            throw new ArgumentException(
                "Query type must be between 1 and 3.");
    }

    public static void ValidateValue(long value)
    {
        if (Math.Abs(value) > Math.Pow(10, 9) || Math.Abs(value) < 1)
            throw new ArgumentException(
                $"Abs Value must be in range of 1 to 1000000000.");
    }
}

public class TwoStackQueue<T>
{
    private readonly Stack<T> _inStack = new();
    private readonly Stack<T> _outStack = new();

    public void Enqueu(T item)
    {
        _inStack.Push(item);
    }

    public T Dequeue()
    {
        MoveIfNeeded();
        return _outStack.Pop();
    }

    public T Peek()
    {
        MoveIfNeeded();
        return _outStack.Peek();
    }

    private void MoveIfNeeded()
    {
        if (_outStack.Count == 0)
        {
            while (_inStack.Count > 0)
                _outStack.Push(_inStack.Pop());
        }
    }
}

public class QueryProcessor
{
    private readonly TwoStackQueue<int> _queue;

    public QueryProcessor(TwoStackQueue<int> queue)
    {
        _queue = queue;
    }

    public List<int> Process(List<string> queries)
    {
        var output = new List<int>();


        foreach (var query in queries)
        {
            var parts = query.Split(' ');
            int.TryParse(parts[0], out var type);

            QueryValidator.ValidateType(type);

            if (type == 1)
            {
                QueryValidator.ValidateValue(int.Parse(parts[1]));
                _queue.Enqueu(int.Parse(parts[1]));
            }
            else if (type == 2)
                _queue.Dequeue();
            else if (type == 3)
                output.Add(_queue.Peek());
        }

        return output;
    }

}

class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int q = int.Parse(Console.ReadLine());
        QueryValidator.ValidateQueryCount(q);

        var queries = new List<string>(q);
        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine());
        }

        var queue = new TwoStackQueue<int>();
        var processor = new QueryProcessor(queue);

        var results = processor.Process(queries);

        foreach (var value in results)
        {
            Console.WriteLine(value);
        }
    }
}