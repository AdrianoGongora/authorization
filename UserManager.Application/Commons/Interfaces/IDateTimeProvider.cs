namespace UserManager.Application.Commons.Interfaces;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}