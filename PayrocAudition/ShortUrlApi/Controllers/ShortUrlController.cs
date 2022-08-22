using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using ShortUrlApi.BusinessLogic;
using ShortUrlApi.Models;
using ShortUrlApi.Repository;

namespace ShortUrlApi.Controllers
{
    [ApiController]
    [Route("xsl/")]
    public class ShortUrlController : ControllerBase
    {
        public readonly IShortUrlRepository _repository;
        public readonly IDatabaseAccess _databaseAccess;
        public readonly IUniqueCodeGenerator _codeGenerator;

        public ShortUrlController(IShortUrlRepository repository, 
                                  IDatabaseAccess databaseAccess, 
                                  IUniqueCodeGenerator codeGenerator)
        {
            _repository = repository;
            _databaseAccess = databaseAccess;
            _codeGenerator = codeGenerator;
        }

        [HttpGet("{uniqueUrlCode}")]
        public async Task<IActionResult> GetUrl(string uniqueUrlCode)
        {
            var requestedUrl = await _repository.GetByUrlUniqueCode(uniqueUrlCode);
            return requestedUrl == null ? this.NotFound() : this.Ok(requestedUrl.Url);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRecord([FromBody] ShortUrlDto shortUrlDto)
        {
            var uniqueCode = false;
            while (!uniqueCode)
            {
                shortUrlDto.UrlUniqueCode = _codeGenerator.NewUniqueCode(6);
                var record = await _databaseAccess.GetSmallUrlByUniqueUrlCode(shortUrlDto.UrlUniqueCode);
                uniqueCode = record == null ? true : false;
            }

            var urlExists = await _databaseAccess.GetSmallUrlByUrl(shortUrlDto.Url);
            if (urlExists != null)
            {
                return this.Ok(urlExists);
            }
            
            var addShortUrlResult = await _databaseAccess.AddSmallUrl(shortUrlDto);
            return addShortUrlResult == true ? this.Ok(shortUrlDto) : this.BadRequest();
        }
    }
}
