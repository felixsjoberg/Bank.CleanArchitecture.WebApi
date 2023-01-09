using System.ComponentModel.DataAnnotations;
using BankApplication.Application.Adminstrator.Response.Commands;
using BankApplication.Application.Customers.Response.Commands;
using MediatR;

namespace BankApplication.Application.Customers.Commands.AddAccountCredit;

public record NewCustomerAccountCommand(
    string Gender,
    string Givenname,
    string Surname,  
    string Streetaddress,
    string City,
    string Zipcode,
    string Country,
    string CountryCode,
    DateTime? Birthday,
    string? Telephonecountrycode,
    string? Telephonenumber,
    string Emailaddress,
    CustomerAccount CustomerAccount

    ) : IRequest<NewCustomerAccountResult>;

public record CustomerAccount(
    [Required]
    int AccountTypesId,
    string? Frequency);