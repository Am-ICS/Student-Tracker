
namespace StudentTracker.Models;
public class TaskStudent
{

    public String Name
    {
        get;
         set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("name cannot be empty");
            }
            field = value;
        }
    }
    
    public String? Description {get;
         set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("description cannot be empty");
            }
            field = value;
        }
    }
    public String Course
    {
        get;  set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("course cannot be empty");
            }
            field = value;
        }
    }

    public bool IsCompleted { get; private set; } = false;

    public void Complete()
    {
       IsCompleted = true;
    }
    public void NotComplete()
    {
        IsCompleted = false;
    }
    public DateTime DueDate {get; set;}
    
}
