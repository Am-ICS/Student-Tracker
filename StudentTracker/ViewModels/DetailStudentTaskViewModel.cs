using System.Collections.ObjectModel;
using StudentTracker.Models;

namespace StudentTracker.ViewModels;

public class DetailStudentTaskViewModel :IDetailStudentTaskViewModel
{
    public TaskStudent TaskStudent { get; }
    public DetailStudentTaskViewModel(TaskStudent taskStudent)
    {
        TaskStudent = taskStudent;
    }
}