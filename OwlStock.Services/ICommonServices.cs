namespace OwlStock.Services
{
    public interface ICommonServices
    {
        string GetEnumDescription(Enum enumeration);
        Task<bool> VerifyReCaptcha(string response);
    }
}
