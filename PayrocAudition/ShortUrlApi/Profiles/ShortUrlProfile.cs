using AutoMapper;

namespace ShortUrlApi.Profiles
{
    public class ShortUrlProfile : Profile
    {
        public ShortUrlProfile()
        {
            CreateMap<Data.Entities.ShortUrlRecordEntity, Models.ShortUrlDto>().ReverseMap();
        }
    }
}
