namespace OwlStock.Services.Interfaces
{
    public interface ICommonServices
    {
        Task<bool> VerifyReCaptcha(string response);
    }
}
