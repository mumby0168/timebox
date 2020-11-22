using System;
using System.Collections.Generic;
using PhoneNumbers;
using Timebox.Account.Application.Interfaces.Services;

namespace Timebox.Account.Application.Services
{
    public class PhoneService : IPhoneService
    {
        
        public const string UkRegionCode = "+44";
        private readonly PhoneNumberUtil _phoneNumberUtility;

        public PhoneService()
        {
            _phoneNumberUtility = PhoneNumberUtil.GetInstance();
        }
        
        public bool IsValidPhoneNumber(string mobileNumber)
        {
            try
            {
                _phoneNumberUtility.Parse(mobileNumber, UkRegionCode);
            }
            catch (NumberParseException)
            {
                return false;
            }

            return true;
        }
    }
}