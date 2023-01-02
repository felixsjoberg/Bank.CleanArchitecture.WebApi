using System;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Queries;
using BankApplication.Application.Customers.Response.Commands;
using MediatR;

namespace BankApplication.Application.Customers.Commands;

public class PostTransactionCommandHandler : IRequestHandler<PostTransactionCommand, PostTransactionResult>
{
    private readonly ICustomersRepository _customerRepository;

    public PostTransactionCommandHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<PostTransactionResult> Handle(PostTransactionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

