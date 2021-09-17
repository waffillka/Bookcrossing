using Newtonsoft.Json;

namespace Bookcrossing.Contracts.Exceptions.ModelExceptions
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
