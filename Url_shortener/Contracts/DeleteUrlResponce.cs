namespace Url_shortener.Contracts
{
    public record class DeleteUrlResponce (int Id, string OriginalUrl, string ShortenedUrl, Guid UserId, DateTime createdAt);
}
