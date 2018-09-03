using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Validation;
using socialarts.club.Data;
using socialarts.club.ObjectExtensions;

namespace socialarts.club.Controllers
{
    // ~/api/tools
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class ToolsController : ApiControllerBase
    {
        private readonly ApplicationDbContext db;

        public ToolsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        // TODO Use Resource-Based authorization
        // See https://docs.microsoft.com/en-us/aspnet/core/security/authorization/resourcebased
        public async Task<IActionResult> List()
        {
            if (!TryGetClaimValue("sub", out var sub))
            {
                return new UnauthorizedResult();
            }

            var tools = await db.ToolsDocument
                .Where(doc => doc.OwnerId == sub)
                .ToListAsync();

            return Json(tools);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Single(int id)
        {
            if (!TryGetClaimValue("sub", out var sub))
            {
                return new UnauthorizedResult();
            }

            var tool = await db.ToolsDocument.FindAsync(id);

            if (tool.OwnerId != sub)
            {
                return new UnauthorizedResult();
            }

            return Json(tool);
        }

        private bool TryGetClaimValue(string claimType, out string value)
        {
            value = "";
            if (!TryGetClaim(claimType, out var claim))
            {
                return false;
            }

            value = claim.Value;
            return true;
        }

        private bool TryGetClaim(string claimType, out Claim claim)
        {
            claim = null;
            if (!TryGetClaimsIdentity(out var identity))
            {
                return false;
            }

            claim = identity.FindFirst(c => c.Type == claimType);
            return claim != null;
        }

        private bool TryGetClaimsIdentity(out ClaimsIdentity identity)
        {
            identity = User.Identity as ClaimsIdentity;
            return identity != null;
        }
    }
}