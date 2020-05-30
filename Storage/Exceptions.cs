namespace LAB1.Storage
{
    [System.Serializable]
    public class IncorrectLAB1DataException : System.Exception
    {
        public IncorrectLAB1DataException() { }
        public IncorrectLAB1DataException(string message) : base(message) { }
        public IncorrectLAB1DataException(string message, System.Exception inner) : base(message, inner) { }
        protected IncorrectLAB1DataException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}