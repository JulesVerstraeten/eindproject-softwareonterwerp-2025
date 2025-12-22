namespace WishList.BL.Exceptions;

public class ServiceException : Exception
{
    public int? ErrorCode { get; }

    public ServiceException(string message, int? errorCode = null) : base(message)
    {
        ErrorCode = errorCode;
    }
    
    public ServiceException(string message, Exception innerException, int? errorCode = null)
        : base(message, innerException)
    {
        ErrorCode = errorCode;
    }
}