using BankApplication.Application.Accounts.Commands;
using BankApplication.Application.Accounts.Response.Commands;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Infrastructure.Presistence;
using Domain.Models;
using Moq;
namespace BankApplication.Application.UnitTests.Accounts.Commands.CreateAccount;

public class CreateAccountCommandHandlerTests
{
    private readonly Mock<IAccountsRepository> _accountsRepository;
    private readonly Mock<IDispositionRepository> _dispositionRepository;
    private readonly CreateAccountCommandHandler _handler;
 
    public CreateAccountCommandHandlerTests()
    {
        _accountsRepository = new Mock<IAccountsRepository>();
        _dispositionRepository = new Mock<IDispositionRepository>();
        _handler = new CreateAccountCommandHandler(_accountsRepository.Object, _dispositionRepository.Object); 

    }

    [Fact]
    public async Task Handle_GivenFrequencyIsEmpty_ShouldThrowRequieredFrequencyForSavingAcc()
    {
        // Arrange
        var command = new CreateAccountCommand(Guid.NewGuid(), "", 1);

        // Act
        var exception = await Assert.ThrowsAsync<RequieredFrequencyForSavingAcc>(() => _handler.Handle(command, CancellationToken.None));

        // Assert
        Assert.IsType<RequieredFrequencyForSavingAcc>(exception);
    }
    [Fact]
    public async Task Handle_GivenValidFrequency_ShouldReturnCreateAccountResult()
    {
        //Arrange
        var command = new CreateAccountCommand(Guid.NewGuid(), "Monthly", 1);
        int result = 1;
        _dispositionRepository.Setup(x => x.GetCustomerIdFromDisposition(It.IsAny<Guid>()).ReturnsAsync(It.IsAny<int>));

        _accountsRepository.Setup(x => x.CreateAccount(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new Account());

        //Act
        var result = await _handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.IsType<CreateAccountResult>(result);
    }
}


    //[Fact]
    //public async Task Handle_GivenInvalidFrequency_ShouldThrowInvalidFrequency()
    //{
    //    Guid userId = Guid.NewGuid();
    //    string frequency = "";
    //    int AccountTypesId = 1;
    //    string AccountId = "1";
    //    DateTime created = DateTime.Now;
    //    int balance = 0;
    //    //mockRepo.Setup(x => x.CreateAccount(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new Account());
    //    _accountsRepository.Setup(x => x.CreateAccount(userId, frequency, AccountTypesId)).ReturnsAsync(account);

    //    var command = new CreateAccountCommand(Guid.NewGuid(), "Ra", 1);

    //    await Assert.ThrowsAsync<InvalidFrequency>(() => _handler.Handle(command, CancellationToken.None));
    //}




