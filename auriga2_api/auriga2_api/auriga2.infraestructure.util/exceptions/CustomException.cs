using System.Globalization;

namespace auriga2.infraestructure.util.exceptions;

public class CustomException: Exception
{
    public CustomException() : base() { }

    public CustomException(string message) : base(message) { }

    public CustomException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}