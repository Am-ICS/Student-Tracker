using System.Collections.ObjectModel;
using System.Windows.Input;
using StudentTracker.Models;
using StudentTracker.Services;

namespace StudentTracker.ViewModels;

public class AddTaskViewModel : IAddTaskViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Course { get; set; }
    public DateTime DueDate { get; set; }
    public ICommand AddTaskCommand { get; }

    private ITaskService taskService;

    private INavigationService NavigationService { get;  set; }
    

    public AddTaskViewModel(ITaskService taskService, INavigationService navigationService)
    {
        this.taskService = taskService;
        AddTaskCommand = new Command(async() => await AddTask());
        NavigationService = navigationService;
    }

    public async Task AddTask()
    {
        TaskStudent task = new TaskStudent()
        {
            Name = Name,
            Description = Description, 
            Course = Course, 
            DueDate = DueDate
        };
        

        await taskService.Add(task);
        await NavigationService.PopAsync();
    }
}