using OneTimeAccessService.Models;

namespace OneTimeAccessService.IServices
{
    public interface IOneTimeAccess
    {
        public void GetNewOneTimeAccessToken();

        public void GetNewOneTimeAccessToken(object seed);

        public void VerifyOneTimeAccessToken(OneTimeAccessToken token);
    }
}
