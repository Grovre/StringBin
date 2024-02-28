using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StringBin.Models;
using StringBin.Repository;

namespace StringBin.Controller.api.v1;

[Route("api/v1")]
[ApiController]
public class StringBinController(StringBinDbContext db) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddEntry(StringBinEntry.StringBinContent content)
    {
        var guid = Guid.NewGuid();
        var entry = new StringBinEntry(content, guid);

        db.Add(entry);
        await db.SaveChangesAsync();

        var entries = await db.EntrySet.ToListAsync();
        foreach (var e in entries)
            Console.WriteLine($"Id: {e.Id}\nTitle: {e.Content.Title}\nBody: {e.Content.Body}");

        return new AcceptedResult();
    }
}