
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentTracker.Services;

using StudentTracker.Models;

namespace StudentTracker.ViewModels;

public partial class MainPageViewModel :ObservableObject,IMainPageViewModel
{
    public ObservableCollection<TaskStudent> StudentTasks { get; private set; }
    private ITaskService taskService;
    private INavigationService _navigationService { get; set; }
    
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(FilterSearchCommand))]
    private string nameFilter;
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(FilterSearchCommand))]
    private string description;

    [ObservableProperty] private ObservableCollection<TaskStudent> filterStudents;

    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(FilterSearchCommand))]
    private string courseFilter;

    public async Task<List<TaskStudent>> GetCourseTasksAsync(string course)
    {
        return await taskService.GetCourseTasks(course);
    }

    public async Task<List<TaskStudent>> GetDescriptionTasksAsync(string description)
    {
        return await taskService.GetDescriptionTasks(description);
    }
    public async Task<List<TaskStudent>> GetNameTasksAsync(string name)
    {

        return await taskService.GetNameTasks(name);
    }

    [ObservableProperty]
    private bool isVisible;

    [RelayCommand]
    private void TaskSelected(TaskStudent task)
    {
        this._navigationService.GoToTaskDetailAsync(task);
   
    }
    
    
    public MainPageViewModel(ITaskService taskService, ObservableCollection<TaskStudent> studentTasks, INavigationService navigationService)
    {
        StudentTasks = studentTasks; 
        FilterStudents = new ObservableCollection<TaskStudent>(studentTasks);
        this.taskService = taskService;
        _navigationService  = navigationService;
    }
    


    public async Task LoadStudentAsync()
    {
        await this.taskService.LoadStudents();
        FilterStudents = new ObservableCollection<TaskStudent>(StudentTasks);
    }
    public void CompleteTask(TaskStudent task)
    {
        taskService.Complete(task);
    }

    public void NotCompleteTask(TaskStudent task)
    {
        taskService.NotComplete(task);
    }
    
    [RelayCommand]
    private void ClickFilter()
    {
        IsVisible = !IsVisible;
    }

    private bool CanSearchFilter()
    {
        if (!string.IsNullOrWhiteSpace(NameFilter))
            return true;
        if(!string.IsNullOrWhiteSpace(CourseFilter))
            return true;
        if (!string.IsNullOrWhiteSpace(Description))
            return true;
        
        //all are empty, dont run
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanSearchFilter))]
    public async Task FilterSearch()
    {
        this.IsVisible = false;
        List<TaskStudent> matches = null;
        
        
        if (!string.IsNullOrWhiteSpace(NameFilter))
        {
            matches = await GetNameTasksAsync(NameFilter);
        }
        else if (!string.IsNullOrWhiteSpace(CourseFilter))
        {
            matches = await GetCourseTasksAsync(CourseFilter);
        }

        else if (!string.IsNullOrWhiteSpace(Description))
        {
            matches = await GetDescriptionTasksAsync(Description);
        }

        if (matches != null)
        {
            FilterStudents = new ObservableCollection<TaskStudent>(matches);
        }
        
    }

    [RelayCommand]
    private async Task AddTaskNavPage()
    {
        await _navigationService.GoToAddNewTask();
    }
}
