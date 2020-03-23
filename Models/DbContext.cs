using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GalaxiaApi.Models
{
    public class DbContext : IdentityDbContext<MeuUserIdentity, MeuRoleIdentity, string>
    {
        public DbContext(DbContextOptions<DbContext> options) :  base(options)
        {
        }
    }
}