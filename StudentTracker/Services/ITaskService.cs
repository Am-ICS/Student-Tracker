using System.Collections.ObjectModel;
using StudentTracker.Models;

namespace StudentTracker.Services;

public interface ITaskService
{
    public ObservableCollection<TaskStudent> Tasks { get; }
    public Task Add(TaskStudent task);
    public void Delete(TaskStudent task);
    public void Complete(TaskStudent task);
    public void NotComplete(TaskStudent task);
    public Task LoadStudents();
    public Task<List<TaskStudent>> GetNameTasks(string name);
    public Task<List<TaskStudent>> GetCourseTasks(string courseName);
    public Task<List<TaskStudent>> GetDescriptionTasks(string description);
}