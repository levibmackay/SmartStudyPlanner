namespace SmartStudyPlanner.Core.Models;

public class Course
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Professor { get; set; } = string.Empty;
    public List<Assignment> Assignments { get; set; } = new();
}

public class Assignment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public double Weight { get; set; }
    public int Difficulty { get; set; }
    public bool IsCompleted { get; set; }
}
