namespace DEPI9APITask.DAL;

public class Course
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public List<Student> Students { get; set; }
}