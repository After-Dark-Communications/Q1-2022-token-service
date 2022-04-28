namespace OneTimeAccessService.IServices
{
    public interface IOneTimeAccess
    {
        public string GetNewOneTimeAccessToken();

        public string GetNewOneTimeAccessToken(object seed);

        public bool VerifyOneTimeAccessToken(string token);
    }
}
