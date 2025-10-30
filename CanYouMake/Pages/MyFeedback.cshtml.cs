using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AuroraFeedbackPortal.Data;

namespace AuroraFeedbackPortal.Pages;

[Authorize]
public class MyFeedbackModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public MyFeedbackModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public async Task OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            Feedbacks = await _context.Feedbacks
                .Include(f => f.Course)
                .Where(f => f.UserId == user.Id)
                .OrderByDescending(f => f.SubmittedAt)
                .ToListAsync();
        }
    }
}
