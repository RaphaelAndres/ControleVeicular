using System;
using Microsoft.AspNetCore.Identity;

namespace ControleVeicular.Domain.Model.Identity
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}