namespace OwlStock.Services.Interfaces
{
    public interface ICommonServices
    {
        string GetEnumDescription(Enum enumeration);
        Task<bool> VerifyReCaptcha(string response);
    }
}
