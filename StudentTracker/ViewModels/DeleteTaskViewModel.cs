
using System.Windows.Input;
using StudentTracker.Models;
using StudentTracker.Services;

namespace StudentTracker.ViewModels;

public class DeleteTaskViewModel : IDeleteTaskViewModel
{
    private ITaskService taskService;

    public TaskStudent TaskToDelete { get; set; }
    public ICommand DeleteTaskCommand { get; }

    public DeleteTaskViewModel(ITaskService taskService)
    {
        this.taskService = taskService;
        DeleteTaskCommand = new Command(DeleteTask);
    }

    public void DeleteTask()
    {
        taskService.Delete(TaskToDelete);
    }
}
