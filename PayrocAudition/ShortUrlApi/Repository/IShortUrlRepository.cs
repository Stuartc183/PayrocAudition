using ShortUrlApi.Data.Entities;

namespace ShortUrlApi.Repository
{
    public interface IShortUrlRepository
    {
        Task<ShortUrlRecordEntity?> GetByUrlUniqueCode(string code);
        Task<ShortUrlRecordEntity?> GetByUrl(string url);
        Task<bool> AddShortUrlRecord(ShortUrlRecordEntity newRecord);
    }
}
