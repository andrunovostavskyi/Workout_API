namespace RestFul.Middlewares.Exceptions;

public class NotFoundExceptions : Exception
{
    public NotFoundExceptions(string nameIdentifier, string idIdentifier)
            : base($"{nameIdentifier} with id: {idIdentifier} do not exist")
    {
    }
}
