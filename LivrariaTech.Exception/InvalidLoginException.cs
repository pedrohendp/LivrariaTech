using System.Net;

namespace LivrariaTech.Exception
{
    public class InvalidLoginException : LivrariaTechException
    {
        public override List<string> GetErrorMessages ()
        {
            return ["Email ou senha inválidos"];
        }
        public override HttpStatusCode GetStatusCode () => HttpStatusCode.Unauthorized;
    }
}