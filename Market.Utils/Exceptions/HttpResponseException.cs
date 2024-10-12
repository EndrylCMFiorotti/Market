namespace Market.Utils.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(string message) : base(message) {
        }
    }
}
