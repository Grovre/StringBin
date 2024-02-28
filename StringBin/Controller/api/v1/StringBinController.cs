using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StringBin.Models;
using StringBin.Repository;

namespace StringBin.Controller.api.v1;

[Route("/")]
[ApiController]
public class StringBinController(StringBinDbContext db) : ControllerBase
{
    [HttpPost("add-entry")]
    public async Task<ActionResult> AddEntry(string title, string body)
    {
        var guid = Guid.NewGuid();
        var entry = new StringBinEntry(title, body, guid);

        db.Add(entry);
        await db.SaveChangesAsync();

        // ToListAsync errors because IQueryable can't be used with async?
        var entries = db.EntrySet.ToList();
        foreach (var e in entries)
            Console.WriteLine($"Id: {e.Id}\nTitle: {e.Title}\nBody:\n{e.Body}");

        return new CreatedAtActionResult(
            nameof(AddEntry), 
            nameof(StringBinController), 
            null, 
            null);
    }
}