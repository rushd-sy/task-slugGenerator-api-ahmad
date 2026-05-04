namespace SlugApi.DTOs
{
    public class GenerateSlugRequest
    {
        public string Text { get; set; } = string.Empty;

        public char Separator { get; set; } = '-';
    }

}