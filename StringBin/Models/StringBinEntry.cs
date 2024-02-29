using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace StringBin.Models;

[PrimaryKey(nameof(Id))]
public class StringBinEntry
{
    [JsonPropertyName("id")]
    public int? Id { get; } = null;
    [JsonPropertyName("content")]
    public StringBinContent Content { get; }

    private StringBinEntry() 
    {
    }

    public StringBinEntry(string title, string body) : this(new(title, body))
    {
    }

    public StringBinEntry(StringBinContent content)
    {
        Content = content;
    }

    public class StringBinContent(string title, string body)
    {
        [JsonPropertyName("title")]
        public string Title { get; } = title;

        [JsonPropertyName("body")]
        public string Body { get; } = body;
    }
}