using System;
using System.Runtime.Serialization;

namespace PlumGuide.PlutoRover.API
{
    [Serializable]
    public class ObstacleDetectedException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ObstacleDetectedException()
        {
        }

        public ObstacleDetectedException(string message) : base(message)
        {
        }

        public ObstacleDetectedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ObstacleDetectedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}