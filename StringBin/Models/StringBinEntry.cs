using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace StringBin.Models;

public class StringBinEntry
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonPropertyName("id")]
    public int Id { get; }
    [JsonPropertyName("content")]
    public StringBinContent Content { get; }

    private StringBinEntry()
    {
    }

    public StringBinEntry(string title, string body, int id) : this(new(title, body), id)
    {
    }

    public StringBinEntry(StringBinContent content, int id)
    {
        Content = content;
        Id = id;
    }

    public class StringBinContent(string title, string body)
    {
        [JsonPropertyName("title")]
        public string Title { get; } = title;

        [JsonPropertyName("body")]
        public string Body { get; } = body;
    }
}