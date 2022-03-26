
namespace JWT.TokenService
{
    public interface ITokenService
    {
        string CreateToken(string codigoUsuario, int idUsuario);
    }
}