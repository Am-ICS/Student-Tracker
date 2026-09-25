using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using StudentTracker.Models;

namespace StudentTracker.ViewModels;

public interface IMainPageViewModel
{
    ObservableCollection<TaskStudent> StudentTasks { get; }
    ObservableCollection<TaskStudent> FilterStudents { get; } 
    public ICommand FilterStudentCommand { get; }
    public ICommand AddTaskNavPageCommand { get; }
    TaskStudent? SelectTask { get; set; }
    event Action<TaskStudent>? OnTaskSelected;
    
    bool IsVisible { get; set; }
    string NameFilter { get; set; }
    string CourseFilter { get; set; }
    string Description { get; set; }

    Task LoadStudentAsync();
    void CompleteTask(TaskStudent task);
    void NotCompleteTask(TaskStudent task);
    Task<List<TaskStudent>> GetNameTasksAsync(string name);
    Task<List<TaskStudent>> GetCourseTasksAsync(string course);
    Task<List<TaskStudent>> GetDescriptionTasksAsync(string description);
    void FilterSearch();
}