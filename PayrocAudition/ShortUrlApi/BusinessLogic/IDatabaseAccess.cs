using ShortUrlApi.Models;

namespace ShortUrlApi.BusinessLogic
{
    public interface IDatabaseAccess
    {
        Task<ShortUrlDto?> GetSmallUrlByUniqueUrlCode(string uniqueUrlCode);
        Task<ShortUrlDto?> GetSmallUrlByUrl(string url);
        Task<bool> AddSmallUrl(ShortUrlDto smallUrl);
    }
}
