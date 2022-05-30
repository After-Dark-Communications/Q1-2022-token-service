using OneTimeAccess.Database;
using OneTimeAccess.IServices;
using OneTimeAccess.Models;
using System.Security.Cryptography;
using System.Text;

namespace OneTimeAccess.Services
{

    public class OneTimeAccessService : IOneTimeAccessService
    {
        //private static List<string> Tokens = new List<string>();
        DatabaseCommunication db = new DatabaseCommunication(); 

        public string GetNewOneTimeAccessToken()
        {
            return GetNewOneTimeAccessToken(null);
        }

        public string GetNewOneTimeAccessToken(object? seed)
        {
            string oneTimeAccessToken;

            if(seed != null)
            {
                oneTimeAccessToken = GenerateHash(seed.ToString());
            }
            else
            {
                oneTimeAccessToken = GenerateHash(BuildSeed());
            }

            //Save oneTimeAccessToken to database
            db.AddToken(new OneTimeAccessToken { TokenContent = oneTimeAccessToken});

            return oneTimeAccessToken;
        }

        public bool VerifyOneTimeAccessToken(string token)
        {
            //Get token from database
            //Cash result
            //Delete token if found
            //return result

            bool result = (!db.ReadToken(token).Equals(string.Empty));

            if (result)
            {
                db.RemoveToken(token);
            }

            return result;
        }

        private string BuildSeed()
        {
            //Currently there exists a risk of duplicate seed generation.
            //If multiple seeds are generated at the exact same time, they won't be unique, and will result in duplicate hash values.
            return DateTime.Now.ToString() + new Random().Next().ToString();
        }

        private string GenerateHash(string sSourceData)
        {
            byte[] tmpSource;
            byte[] tmpHash;

            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);

            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            StringBuilder sOutput = new StringBuilder(tmpHash.Length);
            for (int i = 0; i < tmpHash.Length; i++)
            {
                sOutput.Append(tmpHash[i].ToString("X2"));
            }

            return sOutput.ToString();
        }
    }
}
