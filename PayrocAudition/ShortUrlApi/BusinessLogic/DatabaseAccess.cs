using AutoMapper;
using ShortUrlApi.Data.Entities;
using ShortUrlApi.Models;
using ShortUrlApi.Repository;

namespace ShortUrlApi.BusinessLogic
{
    public class DatabaseAccess : IDatabaseAccess
    {
        private readonly IShortUrlRepository _shortUrlRepository;
        private readonly IMapper _mapper;

        public DatabaseAccess(IShortUrlRepository shortUrlRepository,
                              IMapper mapper)
        {
            _shortUrlRepository = shortUrlRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddSmallUrl(ShortUrlDto smallUrl)
        {
            var shortUrlEntity = _mapper.Map<ShortUrlRecordEntity>(smallUrl);
            return await _shortUrlRepository.AddShortUrlRecord(shortUrlEntity);
        }

        public async Task<ShortUrlDto?> GetSmallUrlByUniqueUrlCode(string uniqueUrlCode)
        {
            var urlObject = await _shortUrlRepository.GetByUrlUniqueCode(uniqueUrlCode);
            return urlObject == null ? null : _mapper.Map<ShortUrlDto>(urlObject);

        }

        public async Task<ShortUrlDto?> GetSmallUrlByUrl(string url)
        {
            var urlObject = await _shortUrlRepository.GetByUrl(url);
            return urlObject == null ? null : _mapper.Map<ShortUrlDto>(urlObject);
        }
    }
}
