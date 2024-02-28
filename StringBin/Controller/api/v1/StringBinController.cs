using Microsoft.AspNetCore.Mvc;

namespace StringBin.Controller.api.v1;

[Route("/")]
[ApiController]
public class StringBinController : ControllerBase
{
    [HttpPost("add-entry")]
    public void AddEntry(string title, string body)
    {
        Console.WriteLine($"Title: {title}\nBody:\n{body}");
    }
}