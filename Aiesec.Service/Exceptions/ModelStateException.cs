using System;

namespace Aiesec.Service.Exceptions
{
    public class ModelStateException : Exception
    {
        public string Key { get; set; }
        public ModelStateException(string Key, string Message) : base(Message)
        {
            this.Key = Key;
        }
    }
}
