using System.Net;

namespace LivrariaTech.Exception
{
    public class NotFoundException : LivrariaTechException
    {
        public NotFoundException (string message) : base(message) { }
        public override List<string> GetErrorMessages () => [Message];

        public override HttpStatusCode GetStatusCode () => HttpStatusCode.NotFound;
    }
}
