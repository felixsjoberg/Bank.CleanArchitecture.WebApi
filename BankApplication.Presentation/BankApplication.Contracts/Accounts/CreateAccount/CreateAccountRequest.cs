using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Accounts;

public record CreateAccountRequest(
    int AccountTypesId,
    string Frequency);


