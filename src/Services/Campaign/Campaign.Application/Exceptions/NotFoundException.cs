namespace Campaign.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException()
        : base("Entity is not found")
    {
    }
}
