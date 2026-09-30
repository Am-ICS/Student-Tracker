using StudentTracker.Models;

namespace StudentTracker.Services;

public interface INavigationService
{
    void SetNavigation(INavigation navigation);
    Task PopAsync();
    Task GoToTaskDetailAsync(TaskStudent task);
    Task GoToAddNewTask();
}