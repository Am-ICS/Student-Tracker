using StudentTracker.Models;

namespace StudentTracker.Services;

public interface INavigationService
{
    Task PopAsync();
    Task GoToTaskDetailAsync(TaskStudent task);
    Task GoToAddNewTask();
}