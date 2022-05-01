using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sythem.Identity.API.Data
{
    public class AuthContext :IdentityDbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options): base(options) { }
    }
}
