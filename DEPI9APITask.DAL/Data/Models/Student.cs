namespace DEPI9APITask.DAL;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Grade { get; set; }
    public List<Course> Courses { get; set; }
}