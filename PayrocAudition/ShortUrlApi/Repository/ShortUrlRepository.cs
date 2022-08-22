using Microsoft.EntityFrameworkCore;
using ShortUrlApi.Data.Contexts;
using ShortUrlApi.Data.Entities;

namespace ShortUrlApi.Repository
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly ShortUrlDbContext _context;

        public ShortUrlRepository(ShortUrlDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddShortUrlRecord(ShortUrlRecordEntity newRecord)
        {
            try
            {
                await _context.AddAsync(newRecord);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ShortUrlRecordEntity?> GetByUrl(string url)
        {
             return await _context.ShortUrlRecords.Where(s => s.Url == url)
                                 .FirstOrDefaultAsync();
        }

        public async Task<ShortUrlRecordEntity?> GetByUrlUniqueCode(string code)
        {
            return await _context.ShortUrlRecords.Where(s => s.UrlUniqueCode == code)
                          .FirstOrDefaultAsync();
        }
    }
}
