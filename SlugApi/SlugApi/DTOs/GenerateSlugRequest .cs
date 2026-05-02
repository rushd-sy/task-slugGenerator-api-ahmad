namespace SlugApi.DTOs
{
    public class SlugGenerateRequest
    {
        public string Text { get; set; } = string.Empty;

        public char? Separator { get; set; } = '-';
    }

}