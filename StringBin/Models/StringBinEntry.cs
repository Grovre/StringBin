using System.Text.Json.Serialization;

namespace StringBin.Models;

public class StringBinEntry
{
    [JsonPropertyName("title")]
    public string Title { get; }
    [JsonPropertyName("body")]
    public string Body { get; }

    public StringBinEntry(string title, string body)
    {
        Title = title;
        Body = body;
    }
}