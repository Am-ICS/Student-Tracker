
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using StudentTracker.Services;

using StudentTracker.Models;

namespace StudentTracker.ViewModels;

public class MainPageViewModel :IMainPageViewModel,  INotifyPropertyChanged
{
    public ObservableCollection<TaskStudent> StudentTasks { get; private set; }
    public ObservableCollection<TaskStudent> FilterStudents { get; private set; }
    private ITaskService taskService;
    public ICommand FilterStudentCommand { get; }
    public ICommand ClickFilterCommand { get; }
    public ICommand AddTaskNavPageCommand { get; }
    private INavigationService _navigationService { get; set; }
    public ICommand TaskSelectedCommand { get; }
    
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string nameFilter;
    public string NameFilter
    {
        get => nameFilter;
        set
        {
            if (nameFilter == value) return;
            nameFilter = value;
            NotifyPropertyChanged();
        }
    }
    private string description;
    public string Description
    {
        get => description;
        set
        {
            if (description == value) return;
            description = value;
            NotifyPropertyChanged();
        }
    }
    

    private string courseFilter;
    public string CourseFilter
    {
        get => courseFilter;
        set
        {
            if (courseFilter == value) return;
            courseFilter = value;
            NotifyPropertyChanged();
        }
    }
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

    private bool isVisible;
    public bool IsVisible
    {
        get => isVisible;
        set
        {
            if (value == isVisible)
            {
                return;
            }

            isVisible = value;
            NotifyPropertyChanged(); 
        }
    }

    private void TaskSelected(TaskStudent task)
    {
        this._navigationService.GoToTaskDetailAsync(task);
        //await Navigation.PushAsync(new DetailStudentTask(task, detailViewModel, deleteViewModel));
    }

    // public event Action<TaskStudent> OnTaskSelected;
    
    
    public MainPageViewModel(ITaskService taskService, ObservableCollection<TaskStudent> studentTasks, INavigationService navigationService)
    {
        StudentTasks = studentTasks; 
        FilterStudents = new ObservableCollection<TaskStudent>(studentTasks);
        this.taskService = taskService;
        _navigationService  = navigationService;
        FilterStudentCommand = new Command(FilterSearch);
        ClickFilterCommand = new Command(ClickFilter);
        AddTaskNavPageCommand = new Command(async()=> await AddTaskCommndNav());
        TaskSelectedCommand = new Command<TaskStudent>(TaskSelected);
        
    }
    


    public async Task LoadStudentAsync()
    {
        await this.taskService.LoadStudents();
        FilterStudents = new ObservableCollection<TaskStudent>(StudentTasks);
        NotifyPropertyChanged(nameof(FilterStudents));
        return;
    }
    public void CompleteTask(TaskStudent task)
    {
        taskService.Complete(task);
    }

    public void NotCompleteTask(TaskStudent task)
    {
        taskService.NotComplete(task);
    }

    private async void ClickFilter()
    {
        if (IsVisible)
        {
            IsVisible = false;
            return;
        }
        IsVisible = true;
    }

    public async void FilterSearch()
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
            NotifyPropertyChanged(nameof(FilterStudents));
        }
        
    }

    private async Task AddTaskCommndNav()
    {
        await _navigationService.GoToAddNewTask();
    }
}
