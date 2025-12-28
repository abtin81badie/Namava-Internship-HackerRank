
using System.ComponentModel.DataAnnotations;
using System.Text;

public class InputValidator
{
    private long _totalWLength = 0;
    private long _totalDeleteK = 0;

    public void ValidateQueries(int q)
    {
        if (q < 1 || q > Math.Pow(10, 6))
            throw new ArgumentException($"Constraint Violation: Q ({q}) must be between 1 and {Math.Pow(10, 6)}.");
    }

    public void ValidateAppend(string w)
    {
        if (w.Any(c => c < 'a' || c > 'z'))
            throw new ArgumentException("Constraint Violation: Append string must only contain lowercase English letters.");

        _totalWLength += w.Length;
        if (_totalWLength > Math.Pow(10, 6))
            throw new ArgumentException($"Constraint Violation: Total length of all 'W' exceeds {Math.Pow(10, 6)}.");
    }

    public void ValidateDelete(int k, int currentStringLength)
    {
        if (k < 1 || k > currentStringLength)
            throw new ArgumentException($"Constraint Violation: k ({k}) must be between 1 and the current string length ({currentStringLength}).");

        _totalDeleteK += k;
        if (_totalDeleteK > 2 * Math.Pow(10, 6))
            throw new ArgumentException($"Constraint Violation: Sum of all delete operations exceeds {2 * Math.Pow(10, 6)}.");
    }

    public void ValidateGet(int k, int currentStringLength)
    {
        if (k < 1 || k > currentStringLength)
            throw new ArgumentException($"Constraint Violation: Index {k} is out of bounds for string length {currentStringLength}.");
    }
}
public class TextEditor
{
    private string _currentString = string.Empty;
    private readonly Stack<string> _history = new Stack<string>();

    public int currentLength => _currentString.Length;

    public void Append(string w)
    {
        _history.Push(_currentString);
        _currentString += w;
    }

    public void Delete(int k)
    {
        _history.Push(_currentString);
        _currentString = _currentString.Substring(0, _currentString.Length - k);
    }

    public char GetCharacter(int k)
    {
        return _currentString[k - 1];
    }

    public void Undo()
    {
        if (_history.Count > 0) 
            _currentString = _history.Pop();
    }
}

class Solution
{
    static void Main(string[] arg)
    {
        var editor = new TextEditor();
        var inputValidator = new InputValidator();
        var outputBuffer = new StringBuilder();

        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
        {
            var qLine = reader.ReadLine();
            if (string.IsNullOrEmpty(qLine))
                return;
            var q = int.Parse(qLine);
            inputValidator.ValidateQueries(q);

            for (var i = 0; i < q; i++)
            {
                var line = reader.ReadLine();

                var parts = line.Split(' ');
                var type = int.Parse(parts[0]);

                if (type == 1)
                {
                    inputValidator.ValidateAppend(parts[1]);
                    editor.Append(parts[1]);
                }
                else if (type == 2)
                {
                    inputValidator.ValidateDelete(int.Parse(parts[1]), editor.currentLength);
                    editor.Delete(int.Parse(parts[1]));
                }
                else if (type == 3)
                {
                    inputValidator.ValidateGet(int.Parse(parts[1]), editor.currentLength);
                    outputBuffer.AppendLine(editor.GetCharacter(int.Parse(parts[1])).ToString());
                }
                else if (type == 4)
                    editor.Undo();  

            }
        }

        Console.Write(outputBuffer.ToString());
    }
}