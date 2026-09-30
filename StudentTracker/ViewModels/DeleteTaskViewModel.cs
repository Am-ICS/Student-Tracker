
using System.Windows.Input;
using StudentTracker.Models;
using StudentTracker.Services;

namespace StudentTracker.ViewModels;

public class DeleteTaskViewModel : IDeleteTaskViewModel
{
    private ITaskService taskService;

    public TaskStudent TaskToDelete { get; set; }
    public ICommand DeleteTaskCommand { get; }
    private INavigationService navigationService;

    public DeleteTaskViewModel(ITaskService taskService, INavigationService navigation)
    {
        this.taskService = taskService;
        DeleteTaskCommand = new Command(async ()=> await DeleteTask());
        this.navigationService = navigation;
    }

    private async Task DeleteTask()
    {
        await taskService.Delete(TaskToDelete);
        await this.navigationService.PopAsync();
    }
}
