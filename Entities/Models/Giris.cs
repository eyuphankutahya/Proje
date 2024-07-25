namespace Entities.Models;

public class Giris
{
    public int Id { get; set; }// bu olmaz ise migration hata  veriyor
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }

}