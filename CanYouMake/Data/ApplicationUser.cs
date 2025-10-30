using Microsoft.AspNetCore.Identity;

namespace AuroraFeedbackPortal.Data;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public string? Role { get; set; }
}
