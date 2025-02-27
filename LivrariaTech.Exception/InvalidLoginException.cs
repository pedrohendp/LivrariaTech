using System.Net;

namespace LivrariaTech.Exception
{
    public class InvalidLoginException : LivrariaTechException
    {
        public InvalidLoginException () : base("Email ou senha inválidos") { }

        public override List<string> GetErrorMessages () => [Message];
        public override HttpStatusCode GetStatusCode () => HttpStatusCode.Unauthorized;
    }
}