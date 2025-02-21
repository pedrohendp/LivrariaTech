using System.Net;

namespace LivrariaTech.Exception
{
    public abstract class LivrariaTechException : SystemException
    {
        public abstract List<string> GetErrorMessages ();
        public abstract HttpStatusCode GetStatusCode ();
    }
}
