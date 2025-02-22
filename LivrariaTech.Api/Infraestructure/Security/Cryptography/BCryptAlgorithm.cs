namespace LivrariaTech.Api.Infraestructure.Security.Cryptography
{
    public class BCryptAlgorithm
    {
        public string HashPassword (string password) => BCrypt.Net.BCrypt.HashPassword(password);
    }
}
