namespace Url_shortener.Contracts
{
    public record GetUrlsRequest(int Id,string OriginalUrl, string ShortenedUrl, int UserId, DateTime CreatedAt);
}
