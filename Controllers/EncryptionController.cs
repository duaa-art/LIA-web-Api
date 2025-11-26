using Microsoft.AspNetCore.Mvc;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class EncryptionController : ControllerBase
{
    private const int Shift = 3; // Caesar-chiffer skiftvärde

    [HttpGet("encrypt/{text}")]
    public IActionResult Encrypt(string text)
    {
        return Ok(CaesarCipher(text, Shift));
    }

    [HttpGet("decrypt/{text}")]
    public IActionResult Decrypt(string text)
    {
        return Ok(CaesarCipher(text, -Shift));
    }

    private string CaesarCipher(string input, int shift)
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char d = char.IsUpper(c) ? 'A' : 'a';
                result.Append((char)(((c + shift - d + 26) % 26) + d));
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
}
