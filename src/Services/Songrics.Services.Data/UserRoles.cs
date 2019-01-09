using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Songrics.Data;
using Songrics.Data.Models;

namespace Songrics.Services.Data
{
    public class UserRoles : IUsersRoles
    {
        private SongricsContext songricsContext;
        private readonly UserManager<SongricsUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRoles(SongricsContext songricsContext,
            UserManager<SongricsUser> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            this.songricsContext = songricsContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IQueryable<IdentityRole> allRoles() => this.roleManager.Roles;

        public IQueryable<IdentityRole> roleById()
        {
            return this.allRoles().OrderBy(id => id.Id);
        }

    }
}
