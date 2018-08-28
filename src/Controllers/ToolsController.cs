using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using socialarts.club.Data;

namespace socialarts.club.Controllers
{
    // ~/api/tools
    public class ToolsController : ApiControllerBase
    {
        private readonly ApplicationDbContext db;

        public ToolsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var tools = await db.ToolsDocument.ToListAsync();
            return Json(tools);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Single(int id)
        {
            var tools = await db.ToolsDocument.FindAsync(id);
            return Json(tools);
        }
    }
}