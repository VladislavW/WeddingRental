using Microsoft.AspNetCore.Identity;

namespace Entities.Identity
{
    public sealed class User: IdentityUser<int>
    {   
        public int? TerritoryId { get; set; }
        public Territory Territory { get; set; }
    }
}