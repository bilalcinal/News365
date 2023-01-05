using Microsoft.IdentityModel.Tokens;

namespace News365.Core.Utilities.Security.Encyption;
public class SigningCredentialsHelper
{
	public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
	{
		return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
	}
}