using System;
using System.IO;

public class LookAheadStreamReader : IDisposable
{
    private readonly StreamReader _reader;
    private string _nextLine;

    public LookAheadStreamReader(Stream stream)
    {
        _reader = new StreamReader(stream);
        _nextLine = _reader.ReadLine();
    }

    public bool EndOfStream => _nextLine == null;

    public string ReadLine()
    {
        string currentLine = _nextLine;
        _nextLine = _reader.ReadLine();
        return currentLine;
    }

    public string PeekNextLine()
    {
        return _nextLine;
    }

    public void Dispose()
    {
        _reader.Dispose();
    }
}