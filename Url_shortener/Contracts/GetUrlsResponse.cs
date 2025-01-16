namespace Url_shortener.Contracts
{
    public record GetUrlsResponse(int Id,string OriginalUrl, string ShortenedUrl, Guid UserId, DateTime CreatedAt);
}
