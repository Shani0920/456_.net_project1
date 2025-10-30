using System.ComponentModel.DataAnnotations;

namespace AuroraFeedbackPortal.Data;

public class Course
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string FacultyName { get; set; } = string.Empty;
    
    public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
