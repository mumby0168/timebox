using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Timebox.Account.Domain.Entities;

namespace Timebox.Account.Api.DTOs
{
    public class AccountCreatedDto
    {
        public string Email { get; }
        public string MobileNumber { get; }

        [JsonConstructor]
        public AccountCreatedDto(string email, string mobileNumber)
        {
            Email = email;
            MobileNumber = mobileNumber;
        }
        
        public static AccountCreatedDto FromEntity(AccountEntity accountEntity)
        {
            return new AccountCreatedDto(accountEntity.Email, accountEntity.MobileNumber);
        }
    }
}