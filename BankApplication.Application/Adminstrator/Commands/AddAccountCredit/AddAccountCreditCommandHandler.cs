using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Response.Commands;
using BankApplication.Domain.Aggregates;
using Domain.Domains;
using Domain.Models;
using MediatR;

namespace BankApplication.Application.Customers.Commands.AddAccountCredit;

public class AddAccountCreditCommandHandler : IRequestHandler<AddAccountCreditCommand, AddAccountCreditResult>
{
    private readonly IAdminstratorRepository _adminstratorRepository;

    public AddAccountCreditCommandHandler(IAdminstratorRepository adminstratorRepository)
    {
        _adminstratorRepository = adminstratorRepository;
    }

    public async Task<AddAccountCreditResult> Handle(AddAccountCreditCommand request, CancellationToken cancellationToken)
    {
        var result = await _adminstratorRepository.AddAccountCredit(request.AccountId,request.Amount);
        if (result is not TransferAggregate transferDetails)
        {
            throw new InternalServerError();
        }
        return new AddAccountCreditResult(result);
    }
}

