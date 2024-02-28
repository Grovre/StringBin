using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace StringBin.Models;

[PrimaryKey(nameof(Id))]
public class StringBinEntry
{
    [JsonPropertyName("id")]
    public Guid Id { get; }

    [JsonPropertyName("title")]
    public string Title { get; }
    [JsonPropertyName("body")]
    public string Body { get; }

    private StringBinEntry()
    {
    }

    public StringBinEntry(string title, string body, Guid id)
    {
        Title = title;
        Body = body;
        Id = id;
    }
    
    
}