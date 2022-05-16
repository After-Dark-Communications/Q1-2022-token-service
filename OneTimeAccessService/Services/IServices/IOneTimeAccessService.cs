namespace OneTimeAccess.IServices
{
    public interface IOneTimeAccessService
    {
        public string GetNewOneTimeAccessToken();

        public string GetNewOneTimeAccessToken(object seed);

        public bool VerifyOneTimeAccessToken(string token);
    }
}
