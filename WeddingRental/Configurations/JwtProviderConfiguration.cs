using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WeddingRental.Configurations
{
    public class JwtProviderConfiguration
    {
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
        public string Audience { get; set; }

        public SecurityKey GetSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        }
    }
}