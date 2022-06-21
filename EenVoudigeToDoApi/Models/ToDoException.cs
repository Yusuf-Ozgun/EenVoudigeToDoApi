using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EenVoudigeToDoApi.Models
{
    public class ToDoException : Exception
    {
        public ToDoException(string message) : base(message)
        {

        }
    }

}
