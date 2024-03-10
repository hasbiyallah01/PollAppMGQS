using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAppMGQS.Dtos
{
    public class UserDto
    {
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
    }
}