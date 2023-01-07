using BankApplication.Application.Adminstrator.Response.Commands;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Response.Commands;
using BankApplication.Domain.Aggregates;
using Domain.Domains;
using Domain.Models;
using MediatR;

namespace BankApplication.Application.Customers.Commands.AddAccountCredit;

public class NewCustomerAccountCommandHandler : IRequestHandler<NewCustomerAccountCommand, NewCustomerAccountResult>
{
    private readonly IAdminstratorRepository _adminstratorRepository;

    public NewCustomerAccountCommandHandler(IAdminstratorRepository adminstratorRepository)
    {
        _adminstratorRepository = adminstratorRepository;
    }

    public async Task<NewCustomerAccountResult> Handle(NewCustomerAccountCommand request, CancellationToken cancellationToken)
    {
        var result = await _adminstratorRepository.AddAccountCredit(request.AccountId,request.Amount);
        if (result is not TransferAggregate transferDetails)
        {
            throw new InternalServerError();
        }
        return new NewCustomerAccountResult(result);
    }
}

