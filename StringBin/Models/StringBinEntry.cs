using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace StringBin.Models;

[PrimaryKey(nameof(Id))]
public class StringBinEntry
{
    [JsonPropertyName("id")]
    public Guid Id { get; }
    [JsonPropertyName("content")]
    public StringBinContent Content { get; }

    private StringBinEntry()
    {
    }

    public StringBinEntry(string title, string body, Guid id)
    {
        Content = new StringBinContent(title, body);
        Id = id;
    }

    public class StringBinContent
    {
        [JsonPropertyName("title")]
        public string Title { get; }
        [JsonPropertyName("body")]
        public string Body { get; }

        public StringBinContent(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}