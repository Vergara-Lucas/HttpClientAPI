namespace HttpClientApi.Models;

public class Book
{
    public int id { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public string publication_year { get; set; }

    public string?[] genre { get; set; }
    public string description { get; set; }
    public string cover_image { get; set; }
}