using OneTimeAccessService.Models;

namespace OneTimeAccessService.IServices
{
    public interface IOneTimeAccess
    {
        public string GetNewOneTimeAccessToken();

        public string GetNewOneTimeAccessToken(object seed);

        public void VerifyOneTimeAccessToken(OneTimeAccessToken token);
    }
}
