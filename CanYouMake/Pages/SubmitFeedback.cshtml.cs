using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AuroraFeedbackPortal.Data;

namespace AuroraFeedbackPortal.Pages;

[Authorize]
public class SubmitFeedbackModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public SubmitFeedbackModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public List<Course> Courses { get; set; } = new List<Course>();

    [BindProperty]
    public int CourseId { get; set; }

    [BindProperty]
    public int Rating { get; set; }

    [BindProperty]
    public string Comment { get; set; } = string.Empty;

    public string? SuccessMessage { get; set; }
    public string? ErrorMessage { get; set; }

    public async Task OnGetAsync()
    {
        Courses = await _context.Courses.ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Courses = await _context.Courses.ToListAsync();

        if (!ModelState.IsValid)
        {
            ErrorMessage = "Please fill in all required fields.";
            return Page();
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToPage("/Login");
        }

        var feedback = new Feedback
        {
            UserId = user.Id,
            CourseId = CourseId,
            Rating = Rating,
            Comment = Comment,
            SubmittedAt = DateTime.UtcNow
        };

        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        SuccessMessage = "Feedback submitted successfully!";
        ModelState.Clear();

        return Page();
    }
}
