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
    public async Task<ActionResult> AddEntry(string title, string body)
    {
        var guid = Guid.NewGuid();
        var entry = new StringBinEntry(title, body, guid);

        db.Add(entry);
        await db.SaveChangesAsync();

        var entries = await db.EntrySet.ToListAsync();
        foreach (var e in entries)
            Console.WriteLine($"Id: {e.Id}\nTitle: {e.Title}\nBody: {e.Body}");

        return new AcceptedResult();
    }
}