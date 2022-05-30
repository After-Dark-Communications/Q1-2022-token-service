using OneTimeAccess.Models;
using TokenParser;

namespace OneTimeAccess.Database
{
    public class DatabaseCommunication
    {
        OneTimeAccessTokenContext _context = new OneTimeAccessTokenContext();
        public void AddToken(OneTimeAccessToken token)
        {
            Serializer.WriteToken(token.TokenContent);
            //try
            //{
            //    _context.Add(token);
            //    _context.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
        }

        public string ReadToken(string token)
        {
            return Serializer.ReadToken(token);
            //return _context.Tokens.Where(c => c.TokenContent.Equals(token)).FirstOrDefault();
        }

        public void RemoveToken(string token)
        {
            Serializer.DeleteToken(token);

            //OneTimeAccessToken targetToken = _context.Tokens.Where(c => c.TokenContent.Equals(token)).First();
            //_context.Remove(targetToken);
            //_context.SaveChanges();
        }


    }
}
