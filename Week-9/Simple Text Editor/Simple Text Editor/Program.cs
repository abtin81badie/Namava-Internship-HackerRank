
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

public abstract class EditorCommand
{
    public abstract void Undo(StringBuilder editorState);
}

public class AppendCommand : EditorCommand
{
    private readonly int _lengthToRemove;

    public AppendCommand(int length)
    {
        _lengthToRemove = length;
    }

    public override void Undo(StringBuilder editorState)
    {
        editorState.Remove(editorState.Length - _lengthToRemove, _lengthToRemove);
    }
}

public class DeleteCommand : EditorCommand
{
    private readonly string _deletedText;

    public DeleteCommand(string deletedText)
    {
        _deletedText = deletedText;
    }

    public override void Undo(StringBuilder editorState)
    {
        editorState.Append(_deletedText);
    }
}

public class TextEditor
{
    private readonly StringBuilder _currentString;
    private readonly Stack<EditorCommand> _history;

    public TextEditor()
    {
        _currentString = new StringBuilder();
        _history = new Stack<EditorCommand>();
    }

    public int CurrentLength => _currentString.Length;

    public void Append(string w)
    {
        _currentString.Append(w);
        _history.Push(new AppendCommand(w.Length));
    }

    public void Delete(int k)
    {
        string deletedSubstring = _currentString.ToString(_currentString.Length - k, k);
        _currentString.Remove(_currentString.Length - k, k);
        _history.Push(new DeleteCommand(deletedSubstring));
    }

    public char GetChar(int k) 
    {
        return _currentString[k - 1];
    }

    public void Undo()
    {
        if (_history.Count > 0) 
        {
            var lastCommand = _history.Pop();
            lastCommand.Undo(_currentString);
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
                    inputValidator.ValidateDelete(int.Parse(parts[1]), editor.CurrentLength);
                    editor.Delete(int.Parse(parts[1]));
                }
                else if (type == 3)
                {
                    inputValidator.ValidateGet(int.Parse(parts[1]), editor.CurrentLength);
                    outputBuffer.AppendLine(editor.GetCharacter(int.Parse(parts[1])).ToString());
                }
                else if (type == 4)
                    editor.Undo();

            }
        }

        Console.Write(outputBuffer.ToString());
    }
}