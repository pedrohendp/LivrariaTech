using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaTech.Exception
{
    public class ConflitException : LivrariaTechException
    {
        public ConflitException (string message) : base(message) { }
        public override List<string> GetErrorMessages () => [Message];

        public override HttpStatusCode GetStatusCode () => HttpStatusCode.Conflict;
    }
}
