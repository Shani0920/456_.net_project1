using System.ComponentModel.DataAnnotations;

namespace AuroraFeedbackPortal.Data;

public class Feedback
{
    public int Id { get; set; }
    
    [Required]
    public string UserId { get; set; } = string.Empty;
    
    public ApplicationUser? User { get; set; }
    
    [Required]
    public int CourseId { get; set; }
    
    public Course? Course { get; set; }
    
    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }
    
    [Required]
    public string Comment { get; set; } = string.Empty;
    
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}
