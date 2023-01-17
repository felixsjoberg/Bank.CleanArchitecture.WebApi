using BankApplication.Application.Adminstrator.Response.Commands;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Domain.Aggregates;
using Domain.Domains;
using BankApplication.Application.Common.Services;
using MediatR;

namespace BankApplication.Application.Customers.Commands.AddAccountCredit;

public class NewCustomerAccountCommandHandler : IRequestHandler<NewCustomerAccountCommand, NewCustomerAccountResult>
{
    private readonly ICustomerRepository _customerRepository;

    public NewCustomerAccountCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<NewCustomerAccountResult> Handle(NewCustomerAccountCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Email = request.Emailaddress.ToLower(),
            Password = PasswordGenerator.RandomPassword(),
            Role = "customer",

        };
        var result = await _customerRepository.NewCustomerAccount(user,request);
        if (result is not NewCustomerAccountAggregate transferDetails)
        {
            throw new InternalServerError();
        }
        return new NewCustomerAccountResult(result);

    }
}

