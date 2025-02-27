using System.Net;

namespace LivrariaTech.Exception
{
    public abstract class LivrariaTechException : SystemException
    {
        protected LivrariaTechException (string message) : base(message) { }
        public abstract List<string> GetErrorMessages ();
        public abstract HttpStatusCode GetStatusCode ();
    }
}
