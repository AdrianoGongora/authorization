using UserManager.Application.Commons.Interfaces;

namespace UserManage.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}