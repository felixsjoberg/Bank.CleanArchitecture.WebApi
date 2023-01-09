using BankApplication.Application.Accounts.Response.Commands;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using Domain.Domains;
using Domain.Models;
using MediatR;

namespace BankApplication.Application.Accounts.Commands;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreateAccountResult>
{
    private readonly IAccountsRepository _accountsRepository;

    public CreateAccountCommandHandler(IAccountsRepository customerRepository)
    {
        _accountsRepository = customerRepository;
    }

    public async Task<CreateAccountResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        if (request.AccountTypesId ==1 && request.Frequency == "")
        {
            throw new RequieredFrequencyForSavingAcc();
        }
        var result = await _accountsRepository.CreateAccount(request.UserId, request.Frequency, request.AccountTypesId);
        if (result is not Account account)
        {
            throw new InvalidFrequency();
        }
        result.User = new User { UserId = request.UserId };
        return new CreateAccountResult(result);
    }
}

