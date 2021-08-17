using System;
using System.Runtime.Serialization;

namespace PlumGuide.PlutoRover.API.Exceptions
{
    [Serializable]
    public class ObstacleDetectedException : Exception
    {
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