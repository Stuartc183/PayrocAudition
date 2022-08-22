namespace ShortUrlApi.BusinessLogic
{
    public interface IUniqueCodeGenerator
    {
        string NewUniqueCode(int length);
    }
}
