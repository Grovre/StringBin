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
        var entry = new StringBinEntry(content);

        db.Add(entry);
        await db.SaveChangesAsync();

        var count = await db.EntrySet.CountAsync();
        Console.WriteLine($"{count} entries exist now");

        return new JsonResult(new
        {
            id = entry.Id
        });
    }

    [HttpGet]
    public async Task<ActionResult> GetEntry(int id)
    {
        var entry = await db.EntrySet.FindAsync(id);

        if (entry == null)
            return new NotFoundObjectResult(null);

        return new JsonResult(entry);
    }
}