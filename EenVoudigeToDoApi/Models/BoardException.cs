using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EenVoudigeToDoApi.Models
{
    public class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {

        }
    }

}
