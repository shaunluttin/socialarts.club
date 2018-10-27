using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using socialarts.club.Data;

public abstract class ToolsPageModel<T> : PageModel
{
    [BindProperty]
    public T Form { get; set; }

    private ApplicationDbContext db { get; }

    protected readonly UserManager<IdentityUser> userManager;

    public ToolsPageModel(
        ApplicationDbContext db,
        UserManager<IdentityUser> userManager)
    {
        this.userManager = userManager;
        this.db = db;
    }

    public bool Disabled { get; set; }

    public async Task OnGetAsync(int id = 0)
    {
        var doc = await GetToolsDocument(id);

        if (doc == null)
        {
            // TODO return 404 not found (or other appropriate status).
            return;
        }

        var currentUserId = GetCurrentUserId();
        if (doc.OwnerId != currentUserId)
        {
            // TODO return 403 forbidden (or other appropriate status).
            return;
        }

        Disabled = true;
        Form = JsonConvert.DeserializeObject<T>(doc.Json);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var doc = await SaveToolsDocument();

        // Post/Redirect/Get to avoid multiple form submission
        return RedirectToPage(HttpContext.Request.Path, new { doc.Id });
    }

    private async Task<ToolsDocument> SaveToolsDocument()
    {
        var currentUserId = GetCurrentUserId();

        // ~/Tools/AssertivenessScorecard
        var razorPage = PageContext.ActionDescriptor.DisplayName;
        var name = razorPage.Split('/').Last();

        var doc = new ToolsDocument
        {
            Name = name,
            TemplateUrlPath = razorPage,
            OwnerId = currentUserId,
            Json = JsonConvert.SerializeObject(Form),
        };

        var result = db.ToolsDocument.Add(doc);
        await db.SaveChangesAsync();

        return doc;
    }

    private async Task<ToolsDocument> GetToolsDocument(int id)
    {
        if (id <= 0) return null;

        var doc = await db.ToolsDocument.FindAsync(id);

        return doc;
    }

    private string GetCurrentUserId()
    {
        return userManager.GetUserId(User) ?? "Anonymous";
    }
}