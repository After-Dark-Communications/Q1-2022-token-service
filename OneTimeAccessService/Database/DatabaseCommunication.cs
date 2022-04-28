using OneTimeAccess.Models;

namespace OneTimeAccess.Database
{
    public class DatabaseCommunication
    {
        OneTimeAccessTokenContext _context = new OneTimeAccessTokenContext();
        public void AddToken(OneTimeAccessToken token)
        {
            try
            {
                _context.Add(token);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public OneTimeAccessToken ReadToken(string token)
        {
            return _context.Tokens.Where(c => c.TokenContent.Equals(token)).FirstOrDefault();
        }

        public void RemoveToken(string token)
        {
            OneTimeAccessToken targetToken = _context.Tokens.Where(c => c.TokenContent.Equals(token)).First();
            _context.Remove(targetToken);
            _context.SaveChanges();
        }

        public void RemoveToken(int id)
        {
            OneTimeAccessToken targetToken = _context.Tokens.OrderBy(c => c.OneTimeAccessTokenId).First();
            _context.Remove(targetToken);
            _context.SaveChanges();
        }
    }
}
