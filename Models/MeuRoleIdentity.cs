using Microsoft.AspNetCore.Identity;

namespace GalaxiaApi.Models
{
    public class MeuRoleIdentity :IdentityRole
    {
        public string Descricao { get; set; }
    }
}