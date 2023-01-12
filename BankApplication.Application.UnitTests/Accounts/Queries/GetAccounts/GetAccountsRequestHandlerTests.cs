using System;
using BankApplication.Application.Accounts.Commands;
using BankApplication.Application.Accounts.Queries.GetAccounts;
using BankApplication.Application.Accounts.Response.Commands;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Response.Queries;
using BankApplication.Contracts.Adminstrator;
using Moq;
using Shouldly;

namespace BankApplication.Application.UnitTests.Accounts.Queries.GetAccounts;

public class GetAccountsRequestHandlerTests
{

    private readonly Mock<IAccountsRepository> _accountsRepository;
    private readonly GetAccountsQueryHandler _handler;

    public GetAccountsRequestHandlerTests()
    {
        _accountsRepository = new Mock<IAccountsRepository>();
        _handler = new GetAccountsQueryHandler(_accountsRepository.Object);
    }

    Guid userId = Guid.NewGuid();

    //[Fact]
    //public async Task Handle_GivenEmptyUserId_ShouldThrowInvalidUserId()
    //{
    //    // Arrange
    //    var query = new GetAccountsQuery(Guid.NewGuid());
    //    //_accountsRepository.Setup(x => x.GetAccounts(It.IsAny<Guid>())).ReturnsAsync(new List<Account>());
    // //   _accountsRepository
    // //.Setup(x => x.GetAccounts(It.IsAny<Guid>()))
    // //.ReturnsAsync(new[] { (Account)Activator.CreateInstance(typeof(Account)) }.AsEnumerable());
    //    _accountsRepository
    //.Setup(x => x.GetAccounts(It.IsAny<Guid>()))
    //.Returns((Task<IEnumerable<global::Domain.Models.Account>>)new[] { (Account)Activator.CreateInstance(typeof(Account)) }.AsEnumerable());



    //    var expectedAccounts = new List<Account> { (Account)Activator.CreateInstance(typeof(Account), (Account)Activator.CreateInstance(typeof(Account) ))};
    //    _accountsRepository
    //        .Setup(x => x.GetAccounts(It.IsAny<Guid>()))
    //        .ReturnsAsy(expectedAccounts);

    //    // Act
    //    var result = await _handler.Handle(query, CancellationToken.None);

    //    // Assert
    //    Assert.IsType<GetAccountsResult>(result);
    //    Assert.Equal(expectedAccounts, result.Accounts);
    //}

    [Fact]
    public async Task Handle_GivenEmptyUserId_ShouldThrowInvalidUser()
    {
        // Arrange
        var query = new GetAccountsQuery(userId = Guid.Empty);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidUser>(() => _handler.Handle(query, CancellationToken.None));

        // Assert
        Assert.IsType<InvalidUser>(exception);
    }

}

