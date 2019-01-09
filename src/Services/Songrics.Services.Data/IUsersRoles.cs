using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Songrics.Services.Data
{
    public interface IUsersRoles
    {
        
        IQueryable<IdentityRole> allRoles();

        IQueryable<IdentityRole> roleById();
    }
}