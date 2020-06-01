using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ControleVeicular.Domain.Model.Identity
{
    public class Role : IdentityRole<Guid>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}