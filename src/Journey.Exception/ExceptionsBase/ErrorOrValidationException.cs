using System.Net;

namespace Journey.Exception.ExceptionsBase;

public class ErrorOrValidationException : JourneyException
{
    private readonly IList<string> _errors;

    public ErrorOrValidationException(IList<string> messages) : base(string.Empty)
    {
        _errors = messages;
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }

    public override IList<string> GetErrorMessages()
    {
        return _errors;
    }
}
