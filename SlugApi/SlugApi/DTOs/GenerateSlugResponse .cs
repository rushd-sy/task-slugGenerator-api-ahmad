namespace SlugApi.DTOs
{ 
    public class SlugGenerateResponse
    {
      public string OriginalText { get; set; } = string.Empty;
      public string Slug { get; set; } = string.Empty;
      public DateTime GeneratedAt { get; set; } 

    }
}
