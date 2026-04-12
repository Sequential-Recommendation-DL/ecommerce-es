namespace ShopappES.Application.Common.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message = "You are not authorized.")
            : base(message) { }
    }
}
