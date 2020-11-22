using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Timebox.Account.Domain.Entities;

namespace Timebox.Account.Api.DTOs
{
    public class AccountCreatedDTO
    {
        public string Email { set; get; }
        public string MobileNumber { set; get; }

        public AccountCreatedDTO()
        {
            
        }
        public AccountCreatedDTO(string email, string mobileNumber)
        {
            Email = email;
            MobileNumber = mobileNumber;
        }
        
        public static AccountCreatedDTO FromEntity(AccountEntity accountEntity)
        {
            return new AccountCreatedDTO(accountEntity.Email, accountEntity.MobileNumber);
        }

        public JsonResult ToJsonResult()
        {
            return new JsonResult(this);
        }
    }
}