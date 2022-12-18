using System;
using BankApplication.Application.Common.Interfaces.Services;

namespace BankApplication.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

