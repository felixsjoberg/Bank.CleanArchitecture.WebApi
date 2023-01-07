using System.Text;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Response.Commands;
using MediatR;

namespace BankApplication.Application.Customers.Commands;

public class TransferCommandHandler : IRequestHandler<TransferCommand, TransferResult>
{
    private readonly ICustomersRepository _customerRepository;

    public TransferCommandHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<TransferResult> Handle(TransferCommand request, CancellationToken cancellationToken)
    {
        var operationId = request.Operation;
        StringBuilder operation = new StringBuilder();
        if (operationId == 1 | operationId ==2)
        {
            if (request.Amount<1)
            {
                throw new InvalidTransferAmount();
            }
            else
            {
                if (operationId == 1)
                {
                    operation.Append("Transfer Between Accounts");
                }
                else
                    operation.Append("Remittance to Another Bank");
            }
        }
        else
        {
            throw new InvalidTransferOperation();
        }
        string Operation = operation.ToString();
        var result =  await _customerRepository.Transfer(request.UserId,request.AccountId, Operation,request.Amount, request.Account);

        return new TransferResult(result);
    }
}

