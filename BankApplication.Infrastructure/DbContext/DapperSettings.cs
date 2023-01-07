using System;
namespace BankApplication.Infrastructure.Presistence;

public class DapperSettings
{
    public const string SectionName = "ConnectionStrings";

    public string SqlServer { get; set; } = null!;
}

