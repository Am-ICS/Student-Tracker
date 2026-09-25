
using System.Collections.ObjectModel;
using StudentTracker.Models;

namespace StudentTracker.Services;

public class TaskService : ITaskService
{
    public ObservableCollection<TaskStudent> Tasks { get; private set; }

    public TaskService(ObservableCollection<TaskStudent> tasks)
    {
        Tasks = tasks;
    }

    public async Task Add(TaskStudent task)
    {
        if (task is null)
        {
            throw new ArgumentNullException("task cannot be null");
        }

        if (Tasks.Any(t => t.Name == task.Name))
            throw new ArgumentException("Name alrewady exists");
        Tasks.Add(task);
        await Storage.Save(Tasks.ToList());

        return;

    }

    public void Delete(TaskStudent task)
    {
        if (task is null)
        {
            throw new ArgumentNullException("task cannot be null");
        }

        TaskStudent? existTask = Tasks.FirstOrDefault(t =>
            t.Name == task.Name
        );

        if (existTask is not null)
        {
            Tasks.Remove(existTask);
        }
        // if(!Tasks.Contains(task))
        // {
        //     throw new ArgumentException("Task doesn not exist");
        // }
        // Tasks.Remove(task);
    }

    public void Complete(TaskStudent task)
    {
        if (task is null)
            throw new ArgumentNullException(nameof(task));

        if (!Tasks.Contains(task))
            throw new ArgumentException(nameof(task));

        task.Complete();
    }

    public void NotComplete(TaskStudent task)
    {
        if (task is null)
            throw new ArgumentNullException(nameof(task));
        if (!Tasks.Contains(task))
            throw new ArgumentException(nameof(task));

        task.NotComplete();
    }

    public async Task LoadStudents()
    {
        Tasks.Clear();
        List<TaskStudent> loaded = await Storage.LoadAsync();
        foreach (var taskStudent in loaded)
        {
            Tasks.Add(taskStudent);
        }
    }

    public async Task<List<TaskStudent>> GetCompletedTasks()
    {
        return Tasks.Where(task => task != null && task.IsCompleted).ToList();
    }
    
    public async Task<List<TaskStudent>> GetIncompletedTasks()
    {
        return Tasks.Where(task => task != null && !task.IsCompleted).ToList();
    }

    public async Task<List<TaskStudent>> GetNameTasks(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Tasks.ToList();

        return Tasks.Where(task => 
            task != null && 
            !string.IsNullOrEmpty(task.Name) && 
            task.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public async Task<List<TaskStudent>> GetCourseTasks(string courseName)
    {
        if (string.IsNullOrWhiteSpace(courseName))
            return Tasks.ToList();

        return Tasks.Where(task => 
            task != null && 
            !string.IsNullOrEmpty(task.Course) && 
            task.Course.Contains(courseName, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public async Task<List<TaskStudent>> GetDescriptionTasks(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return Tasks.ToList();

        return Tasks.Where(task => 
            task != null && 
            !string.IsNullOrEmpty(task.Description) && 
            task.Description.Contains(description, StringComparison.OrdinalIgnoreCase)
        ).ToList(); 
    }
    // public async Task<List<TaskStudent>> GetDueDateTasks()
    // {
    //     return Tasks.Where(task => task.DueDate); 
    // }
}