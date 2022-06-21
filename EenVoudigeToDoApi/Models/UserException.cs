using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EenVoudigeToDoApi.Models
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {

        }
    }

}
