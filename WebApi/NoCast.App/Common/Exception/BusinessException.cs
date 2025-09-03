
namespace NoCast.App.Common.Exception
{
    public class BusinessException : System.Exception
    {
        public int StatusCode { get; }
        public BusinessException(string message, int statusCode = 400) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
